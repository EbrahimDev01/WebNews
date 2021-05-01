using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebNews.Consts.Messages;

namespace WebNews.Models.ViewModels.CommentViewModel
{
    public class AddEditCommentViewModel : CommentViewModel
    {
        public int NewsId { set; get; }
    }
}
