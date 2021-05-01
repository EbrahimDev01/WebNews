using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNews.Models.ViewModels.CommentViewModel
{
    public class ShowCommentViewModel : CommentViewModel
    {
        public string UserName { get; set; }

        public string Image { get; set; }

        public string CreateDate { get; set; }
    }
}
