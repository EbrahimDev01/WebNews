using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNews.Areas.Admin.Models.ViewModels;
using WebNews.Data;
using WebNews.Models;
using WebNews.Utility.MyConvert;
using System.IO;
using WebNews.Utility.MyPath;

namespace WebNews.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class NewsController : Controller
    {


        private WebNewsContext _context;

        public NewsController(WebNewsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var news = _context.News.Select(
                n =>
                new ShowNewsViewModel()
                {
                    CreateDate = n.CreateDate.ToSolarShort(),
                    GroupName = "/ImagesNews/" + n.Group.Name ?? "گروهی ندارد",
                    ImageName = n.Medias.FirstOrDefault().Name ?? "تصویری ندار",
                    NewsId = n.NewsId,
                    Title = n.Title,
                    Views = n.Views
                });

            return View(news);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .Include(n => n.Group)
                .Include(n => n.Medias)
                .Include(n => n.User)
                .Include(n => n.Comments)
                .SingleOrDefaultAsync(n => n.NewsId == id);

            if (news == null)
            {
                return NotFound();
            }

            var newsResult = new NewsDetailsViewModel()
            {
                CreateDate = news.CreateDate.ToSolar(),

                Description = news.Description,

                GroupName = news.Group?.Name ?? "بدون گروه",

                InSlider = "در اسلایدر " + ((news.InSlider) ? "است" : "نیست"),

                NameMedias = news.Medias.Select(m => m.Name).ToList(),

                NewsId = news.NewsId,

                NumberOfComments = news.Comments.Count(),

                Tages = news.Tages.Split(",").ToList(),

                Text = news.Text,

                Title = news.Title,

                UserName = news.User.UserNaem ?? "مشخص نشده یا کاربر پاک شده است",

                Views = news.Views
            };

            return View(newsResult);
        }

        #region Delete

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .Include(n => n.User)
                .Include(n => n.Group)
                .SingleOrDefaultAsync(n => n.NewsId == id);

            if (news == null)
            {
                return NotFound();
            }

            var newsReuslt = new NewsDeleteViewModel()
            {
                CreateDate = news.CreateDate.ToSolar(),
                NewsId = news.NewsId,
                GroupName = news.Group?.Name ?? "بدون گروه",
                Title = news.Title,
                UserName = news.User?.UserNaem ?? "مشخص نشده یا کاربر پاک شده است",
            };


            return View(newsReuslt);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _context.News
                .Include(n => n.Medias)
                .Include(n => n.Comments)
                .SingleOrDefaultAsync(n => n.NewsId == id);

            _context.Remove(news);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        #endregion


        #region Add

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(NewsAddViewModel newsVM)
        {
            if (!ModelState.IsValid)
            {
                return View(newsVM);
            }

            var news = new News()
            {
                CreateDate = DateTime.Now,
                Description = newsVM.Description,
                GroupId = newsVM.Group,
                InSlider = newsVM.InSlider,
                Tages = newsVM.Tages,
                Text = newsVM.Text,
                Title = newsVM.Title,
                Views = 0,
                UserId = 1
            };

            await _context.AddAsync(news);

            foreach (var item in newsVM.Media)
            {

                if (item.Length > 0)
                {
                    string getExtensionMedia = Path.GetExtension(item.FileName);

                    string newNameMedia = Guid.NewGuid().ToString();

                    string filePath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        "ImagesNews",
                        newNameMedia +
                        getExtensionMedia);


                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        item.CopyTo(stream);
                    }

                    var media = new Media()
                    {
                        MediaFileType = MediaFileType.Img,
                        Name = newNameMedia + getExtensionMedia,
                        News = news,
                    };


                    news.Medias.Add(media);

                    _context.Add(media);

                }

            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        #endregion


    }
}
