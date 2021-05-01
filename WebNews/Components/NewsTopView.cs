using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNews.Data;
using WebNews.Models.ViewModels;
using WebNews.Utility.MyConvert;
using WebNews.Utility.MyPath;

namespace WebNews.Components
{
    public class NewsTopView : ViewComponent
    {

        private readonly WebNewsContext _context;

        public NewsTopView(WebNewsContext context)
        {
            _context = context;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {


            return await Task.Run(() =>
            {
                var newsTopView = _context.News.
                   OrderByDescending(n => n.Views)
                   .Take(5)
                   .Select(n =>
                   new PreviewNewsViewModel()
                   {
                       CreateDate = n.CreateDate.ToSolarShort(),
                       Id = n.NewsId,
                       Title = n.Title,
                       ImagesName = n.Medias.Select(m => m.Name).ToList()

                   });
                //"/ImagesNews/" + n.Medias.FirstOrDefault().Name

                return View("/Views/Components/NewsTopView.cshtml", newsTopView);

            });
        }
    }
}
