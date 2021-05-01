using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNews.Data;
using WebNews.Models.ViewModels;
using WebNews.Utility.MyConvert;

namespace WebNews.Components
{
    public class SliderPageIndex : ViewComponent
    {
        private readonly WebNewsContext _context;

        public SliderPageIndex(WebNewsContext context)
        {
            _context = context;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.Run(() =>
            {
                var newsInSlider = _context.News.Where(n => n.InSlider)
               .OrderByDescending(n => n.CreateDate)
               .Select(n =>
               new PreviewNewsViewModel()
               {
                   CreateDate = n.CreateDate.ToSolarShort(),
                   Id = n.NewsId,
                   Text = n.Description,
                   ImageName = n.Medias.FirstOrDefault().Name,
                   Title = n.Title
               }).ToList();

                return View("/Views/Components/Slider.cshtml", newsInSlider);

            });
        }
    }
}
