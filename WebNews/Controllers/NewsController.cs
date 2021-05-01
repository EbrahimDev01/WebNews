using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNews.Components;
using WebNews.Data;
using WebNews.Models.ViewModels;
using WebNews.Models.ViewModels.CommentViewModel;
using WebNews.Utility.MyConvert;
using WebNews.Utility.MyPath;

namespace WebNews.Controllers
{
    //News/ShowComments
    public class NewsController : Controller
    {

        private readonly WebNewsContext _context;

        public NewsController(WebNewsContext context)
        {
            _context = context;
        }


        [Route("News/{id}")]
        public async Task<IActionResult> News(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var news = await _context.News
                .Include(n => n.Medias)
                .Include(n => n.Group)
                .Include(n => n.Comments)
                .SingleOrDefaultAsync(n => n.NewsId == id);

            if (news == null)
            {
                return NotFound();
            }


            news.Views++;
            await _context.SaveChangesAsync();

            var newsRes = new NewsViewModel()
            {
                CreateDate = news.CreateDate.ToSolarShort(),
                GroupId = news.GroupId.Value,
                GroupName = news.Group.Name,
                Id = news.NewsId,
                //ImageName = await PathImage.GetPathImage(news.Medias.FirstOrDefault()?.Name),
                ImagesName = news.Medias?.Select(m => m.Name).ToList(),
                Text = news.Text,
                Title = news.Title,
                Tags = news.Tages.Split(',').ToList(),
                View = news.Views,
                CountComment = news.Comments.Count()
            };


            return View(newsRes);
        }





    }
}
