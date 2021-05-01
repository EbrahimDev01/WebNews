using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebNews.Models
{
    public class Media
    {
        [Key]
        public int MediaId { get; set; }

        #region Name

        [Display(Name = "نام تصویر")]
        [Required]
        public string Name { get; set; }

        #endregion

        #region Media File Type
        [Display(Name = "نوع فایل")]
        [Range(1, 3)]
        public MediaFileType MediaFileType { set; get; }
        #endregion


        #region Relationship

        public int? NewsId { get; set; }
        public virtual News News { get; set; }


        public int? UserId { get; set; }
        public virtual User User { get; set; }

        #endregion
    }

    public enum MediaFileType
    {
        [Display(Name = "تصویر")]
        Img = 1,

        [Display(Name = "ویدیو")]
        Video = 2,

        [Display(Name = "صدا")]
        Sound = 3
    }
}
