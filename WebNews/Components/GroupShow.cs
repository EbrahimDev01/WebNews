using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNews.Data;
using WebNews.Models.ViewModels;

namespace WebNews.Components
{
    public class GroupShow : ViewComponent
    {
        private readonly WebNewsContext _context;

        public GroupShow(WebNewsContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.Run(() =>
            {
                var groups = _context.Groups
                .OrderBy(g => g.Name)
                .Select(g =>
                new GroupShowViewModel()
                {
                    Name = g.Name,
                    Count = g.News.Count(),
                    Id = g.GroupId
                });

                return View("/Views/Components/GroupShow.cshtml", groups);
            });
        }
    }
}
