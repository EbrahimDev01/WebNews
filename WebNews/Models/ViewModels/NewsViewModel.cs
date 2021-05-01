using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebNews.Models.ViewModels.CommentViewModel;

namespace WebNews.Models.ViewModels
{
    public class NewsViewModel : PreviewNewsViewModel
    {
        public string GroupName { set; get; }

        public int GroupId { get; set; }

        public int View { set; get; }

        public List<string> Tags { set; get; }

        public int CountComment { set; get; }

        public AddEditCommentViewModel AddEditComment { set; get; }
        //public List<ShowCommentViewModel> Comments { set; get; }
    }
}
