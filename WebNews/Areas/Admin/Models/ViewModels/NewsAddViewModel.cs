using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebNews.Consts.Messages;
using WebNews.Models;
using static System.Net.WebRequestMethods;

namespace WebNews.Areas.Admin.Models.ViewModels
{
    public class NewsAddViewModel
    {
        [Key]
        public int NewsId { get; set; }

        #region Text

        [Required(ErrorMessage = ErrMsg.RequiredMsg)]
        [Display(Name = "متن خبر")]
        [MinLength(100, ErrorMessage = ErrMsg.MinLengthMsg)]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        #endregion

        #region Title

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = ErrMsg.RequiredMsg)]
        [MinLength(6, ErrorMessage = ErrMsg.MinLengthMsg)]
        [MaxLength(150, ErrorMessage = ErrMsg.MaxLengthMsg)]
        public string Title { get; set; }

        #endregion

        #region Description

        [Display(Name = "شرح خبر")]
        [Required(ErrorMessage = ErrMsg.RequiredMsg)]
        [MinLength(50, ErrorMessage = ErrMsg.MinLengthMsg)]
        [MaxLength(600, ErrorMessage = ErrMsg.MaxLengthMsg)]
        public string Description { get; set; }

        #endregion

        #region Tages
        [Display(Name = "کلمات کلیدی")]
        [Required(ErrorMessage = ErrMsg.RequiredMsg)]
        [MinLength(4, ErrorMessage = ErrMsg.MinLengthMsg)]
        public string Tages { set; get; }
        #endregion

        #region InSlider

        [Display(Name = "نمایش در اسلایدر")]
        public bool InSlider { set; get; }

        #endregion



        [Display(Name = "گروه")]
        public int Group { get; set; }

        [Display(Name = "تصاویر")]
        public List<IFormFile> Media { set; get; }
    }
}
