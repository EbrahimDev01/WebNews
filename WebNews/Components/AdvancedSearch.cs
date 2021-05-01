using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNews.Data;
using WebNews.Models.ViewModels;

namespace WebNews.Components
{
    public class AdvancedSearch : ViewComponent
    {
        private readonly WebNewsContext _context;

        public AdvancedSearch(WebNewsContext context)
        {
            _context = context;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.Run(() =>
            {
                var news = _context.Groups
                .Select(
                    g =>
                    new GroupShowViewModel()
                    {
                        Id = g.GroupId,
                        Name = g.Name
                    });

                return View("/Views/Components/AdvancedSearch.cshtml", news);
            });


        }

    }
}
