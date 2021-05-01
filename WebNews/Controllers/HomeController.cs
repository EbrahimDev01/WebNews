using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebNews.Data;
using WebNews.Models;
using WebNews.Models.ViewModels;
using WebNews.Utility.MyConvert;

namespace WebNews.Controllers
{
    public class HomeController : Controller
    {

        private readonly WebNewsContext _context;

        public HomeController(WebNewsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var lastNews = _context.News
                .OrderByDescending(n => n.CreateDate)
                .Take(10)
                .Select(n =>
                new PreviewNewsViewModel()
                {
                    CreateDate = n.CreateDate.ToSolarShort(),
                    Text = n.Description,
                    Id = n.NewsId,
                    ImagesName = new List<string>() { "/ImagesNews/" + n.Medias.FirstOrDefault().Name },
                    Title = n.Title
                });

            return View(lastNews);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
