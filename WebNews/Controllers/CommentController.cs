using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNews.Data;
using WebNews.Models;
using WebNews.Models.ViewModels.CommentViewModel;

namespace WebNews.Controllers
{
    public class CommentController : Controller
    {

        public WebNewsContext _context;

        public CommentController(WebNewsContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult ShowComments(int id, int take = 5)
        {

            var res = ViewComponent("ShowCommentNews", new { id, take });

            return res;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int id, AddEditCommentViewModel comment)
        {
            if (id != comment.NewsId)
            {
                return Json("مشکلی پیش آمده لطفا بعدا تلاش کنید");
            }

            if (ModelState.IsValid)
            {
                var commentConverted = new Comment()
                {
                    Body = comment.Body,
                    Title = comment.Title,
                    NewsId = comment.NewsId,
                    CreateDate = DateTime.Now,
                    UserId = 1
                };

                await _context.Comments.AddAsync(commentConverted);
                await _context.SaveChangesAsync();

                return Json(true);
            }

            return Json(ModelState);

        }


        [HttpPost]
        public async Task<IActionResult> EditComment(int id, AddEditCommentViewModel comment)
        {
            if (comment.CommentId > 0 && id != comment.NewsId)
            {
                return Json("مشکلی پیش آمده لطفا بعدا تلاش کنید");
            }

            if (ModelState.IsValid)
            {

                var result = _context.Comments.Find(comment.CommentId);

                if (result == null)
                {
                    return Json("مشکلی پیش آمده لطفا بعدا تلاش کنید");

                }

                result.Body = comment.Body;
                result.Title = comment.Title;

                await _context.SaveChangesAsync();

                return Json(true);
            }

            return Json(ModelState);

        }

        public async Task<IActionResult> EditComment(int id)
        {
            if (id < 1)
            {
                return Json(false);
            }
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return Json(false);
            }

            return Json(new CommentViewModel
            {
                Body = comment.Body,
                Title = comment.Title
            });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment(int id)
        {

            try
            {

                var comment = await _context.Comments.FindAsync(id);
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();

                return Json(true);

            }
            catch
            {
                return Json(false);
            }

        }
    }
}
