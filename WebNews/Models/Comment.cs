using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebNews.Consts.Messages;

namespace WebNews.Models
{
    public class Comment
    {
        [Key]
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

        #region CreateDate
        [DataType(DataType.DateTime)]
        [Display(Name = "تاریخ ثبت")]
        [DisplayFormat(DataFormatString = "yyyy/MM/dd")]
        [Required(ErrorMessage = ErrMsg.RequiredMsg)]
        public DateTime CreateDate { set; get; }
        #endregion 

        #region Relationship
        public int? UserId { set; get; }
        [Display(Name = "کاربر")]
        public User User { set; get; }



        public int? NewsId { set; get; }
        [Display(Name = "خبر")]
        public News News { set; get; }
        #endregion
    }
}
