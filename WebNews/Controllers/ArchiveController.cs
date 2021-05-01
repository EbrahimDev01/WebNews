using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNews.Data;
using WebNews.Models;
using WebNews.Models.ViewModels;
using WebNews.Utility.MyConvert;
using WebNews.Utility.Optimization;

namespace WebNews.Controllers
{
    public class ArchiveController : Controller
    {
        private readonly WebNewsContext _context;

        public ArchiveController(WebNewsContext context)
        {
            _context = context;
        }


        [Route("/Group/{groupId}/{groupName}")]
        public IActionResult ShowGroupInArchive(int groupId, string groupName, int take = 10, int skip = 0)
        {
            var news = SearchInArchive(null, groupId, skip, take);


            if (groupId < 1)
            {
                ViewData["Title"] = _context.Groups.Find(groupId).Name;
                ViewData["GroupId"] = groupId;
            }
            else
            {
                ViewData["Title"] = "همه گروه ها";
                ViewData["GroupId"] = 0;
            }

            return View(news);
        }



        [Route("/Archive")]
        public IActionResult ArchiveAll(int take = 10, int skip = 0)
        {
            ViewData["MaxCount"] = (int)Math.Ceiling((double)_context.News.Count() / take);
            ViewData["skip"] = skip;
            ViewData["take"] = take;

            ViewData["Title"] = "آرشیو اخبار";
            var news = SearchInArchive(skip: skip, take: take);

            return View(news);
        }



        [Route("/Search")]
        public IActionResult SearchInGroup(int groupId, string q, string groupName, int take = 10, int skip = 0)
        {

            ViewData["Search"] = q;

            ViewData["Title"] = "  جست و جو برای - " + q;

            if (groupId > 0)
            {
                ViewData["Group"] = _context.Groups.Find(groupId).Name;

                ViewData["GroupId"] = groupId;
            }
            else
            {
                ViewData["Group"] = "همه گروه ها";

                ViewData["GroupId"] = 0;
            }

            var news = SearchInArchive(q, groupId, skip, take);


            return View(news);
        }

        private List<PreviewNewsViewModel> SearchInArchive(string q = null, int groupId = 0, int skip = 0, int take = 10)
        {

            try
            {
                List<News> news = _context.News.ToList();

                if (news == null)
                { return null; }

                if (groupId > 0)
                {
                    news = news
                        .Where(n => n.GroupId == groupId).ToList();
                }

                if (q != null)
                {
                    q = q.ToNoSpaceAndLower();

                    news = news
                        .Where(
                        n =>
                        n.Title.ToNoSpaceAndLower().Contains(q) ||
                        n.Tages.ToNoSpaceAndLower().Contains(q) ||
                        n.Text.ToNoSpaceAndLower().Contains(q) ||
                        n.Description.ToNoSpaceAndLower().Contains(q)
                        ).ToList();
                }



                if (news == null)
                { return null; }



                var newsVM = news
                    .Skip(skip * take)
                    .Take(take)
                    .Select(n =>
                   new PreviewNewsViewModel()
                   {
                       CreateDate = n.CreateDate.ToSolarShort(),
                       Text = n.Description,
                       Id = n.NewsId,
                       ImageName = n.Medias?.FirstOrDefault()?.Name,
                       Title = n.Title
                   })
                    .ToList();

                ViewData["MaxCount"] = (int)Math.Ceiling((double)news.Count() / take);
                ViewData["skip"] = skip;
                ViewData["take"] = take;

                return newsVM;
            }
            catch
            {
                return null;
            }
        }
    }
}
