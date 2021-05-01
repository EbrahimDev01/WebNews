using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebNews.Areas.Admin.Models.ViewModels
{
    public class ShowNewsViewModel : NewsViewModel
    {

        [Display(Name = "تصویر")]
        public string ImageName { set; get; }
    }
}
