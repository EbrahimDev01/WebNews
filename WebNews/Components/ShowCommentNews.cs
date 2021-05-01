using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNews.Data;
using WebNews.Models.ViewModels.CommentViewModel;
using WebNews.Utility.MyConvert;
using WebNews.Utility.MyPath;

namespace WebNews.Components
{
    public class ShowCommentNews : ViewComponent
    {
        private readonly WebNewsContext _context;

        public ShowCommentNews(WebNewsContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id, int take )
        {

            return await Task.Run(() =>
            {
                var comments = _context.Comments
                    .Where(c => c.NewsId == id)
                    .OrderByDescending(c => c.CreateDate)
                    .Take(take)
                    .Select(
                        c =>
                        new ShowCommentViewModel()
                        {
                            Body = c.Body,
                            CreateDate = c.CreateDate.ToSolarShort(),
                            Image = "/ImagesNews/" + c.User.Media.Name,
                            Title = c.Title,
                            UserName = c.User.UserNaem,
                            CommentId=c.CommentId
                        });

                return View("~/Views/Components/ShowCommentNews.cshtml", comments);
            });
        }
    }
}
