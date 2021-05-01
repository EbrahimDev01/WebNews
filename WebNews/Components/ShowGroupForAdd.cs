using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNews.Data;

namespace WebNews.Components
{
    public class ShowGroupForAdd : ViewComponent
    {
        private WebNewsContext _context;

        public ShowGroupForAdd(WebNewsContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/ShowGroupForAdd.cshtml",
                await _context.Groups
                .ToListAsync());
        }

    }
}
