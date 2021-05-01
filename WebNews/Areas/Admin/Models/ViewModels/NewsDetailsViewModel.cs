using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebNews.Areas.Admin.Models.ViewModels
{
    public class NewsDetailsViewModel : NewsViewModel
    {
        [Display(Name = "متن خبر")]
        public string Text { get; set; }


        [Display(Name = "شرح خبر")]
        public string Description { get; set; }

        [Display(Name = "کلمات کلیدی")]
        public List<string> Tages { set; get; }


        [Display(Name = "نمایش در اسلایدر")]
        public string InSlider { set; get; }

        [Display(Name = "نویسنده خبر")]
        public string UserName { get; set; }

        [Display(Name = "رسانه ها")]
        public List<string> NameMedias { set; get; }

        [Display(Name = "تعداد کامنت ها")]
        public int NumberOfComments { set; get; }
    }
}
