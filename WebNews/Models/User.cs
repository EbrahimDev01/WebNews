using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebNews.Consts.Messages;

namespace WebNews.Models
{
    public class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            News = new HashSet<News>();
        }

        [Key]
        public int UserId { get; set; }

        #region User Name
        [Required(ErrorMessage = ErrMsg.RequiredMsg)]
        [MaxLength(20, ErrorMessage = ErrMsg.MaxLengthMsg)]
        [MinLength(5, ErrorMessage = ErrMsg.MinLengthMsg)]
        public string UserNaem { get; set; }
        #endregion

        #region Email

        [EmailAddress(ErrorMessage = ErrMsg.RegexMsg)]
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = ErrMsg.RequiredMsg)]
        public string Email { set; get; }
        #endregion

        #region Passowrd 
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = ErrMsg.RequiredMsg)]
        [MaxLength(20, ErrorMessage = ErrMsg.MaxLengthMsg)]
        [MinLength(8, ErrorMessage = ErrMsg.MinLengthMsg)]
        [DataType(DataType.Password)]
        public string Password { set; get; }
        #endregion


        #region IsAdmin

        [Display(Name = "آیا ادمین است")]
        public string IsAdmin { set; get; }

        #endregion


        #region Relationship 

        public virtual Media Media { set; get; }

        public virtual ICollection<News> News { set; get; }

        public virtual ICollection<Comment> Comments { set; get; }

        #endregion
    }
}
