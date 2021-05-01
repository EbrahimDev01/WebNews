using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebNews.Consts.Messages;

namespace WebNews.Models.ViewModels.CommentViewModel
{
    public class CommentViewModel
    {
        public int CommentId { set; get; }

        #region Title
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = ErrMsg.RequiredMsg)]
        [MaxLength(160, ErrorMessage = ErrMsg.MaxLengthMsg)]
        [MinLength(4, ErrorMessage = ErrMsg.MinLengthMsg)]
        public string Title { set; get; }
        #endregion

        #region Body
        [Display(Name = "متن اصلی")]
        [Required(ErrorMessage = ErrMsg.RequiredMsg)]
        [MaxLength(650, ErrorMessage = ErrMsg.MaxLengthMsg)]
        [MinLength(10, ErrorMessage = ErrMsg.MinLengthMsg)]
        [DataType(DataType.MultilineText)]
        public string Body { set; get; }
        #endregion
    }
}
