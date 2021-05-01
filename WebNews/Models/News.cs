using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebNews.Consts.Messages;

namespace WebNews.Models
{
    public class News
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

        #region CreateDate


        [Display(Name = "تاریخ ساخت")]
        [DisplayFormat(DataFormatString = "yyyy/MM/dd")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = ErrMsg.RequiredMsg)]
        public DateTime CreateDate { set; get; }

        #endregion

        #region Views

        [Display(Name = "تعداد نمایش")]
        public int Views { get; set; }

        #endregion

        #region InSlider

        [Display(Name = "نمایش در اسلایدر")]
        public bool InSlider { set; get; }

        #endregion



        #region Relationship
        public int? GroupId { get; set; }

        [Display(Name = "گروه")]
        public virtual Group Group { get; set; }

        public int? UserId { get; set; }
        [Required(ErrorMessage = ErrMsg.RequiredMsg)]
        [Display(Name = "کاربر")]
        public virtual User User { get; set; }

        public virtual ICollection<Media> Medias { set; get; }

        public virtual ICollection<Comment> Comments { set; get; }
        #endregion
    }
}
