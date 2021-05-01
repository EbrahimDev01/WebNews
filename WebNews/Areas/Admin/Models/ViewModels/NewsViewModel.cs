using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebNews.Areas.Admin.Models.ViewModels
{
    public class NewsViewModel
    {
        public int NewsId { set; get; }

        [Display(Name = "عنوان")]
        public string Title { set; get; }

        [Display(Name = "تاریخ انتشار")]
        public string CreateDate { set; get; }

        [Display(Name = "بازدید")]
        public int Views { set; get; }

        [Display(Name = "نام گروه")]
        public string GroupName { get; set; }
    }
}
