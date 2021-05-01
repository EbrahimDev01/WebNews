using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebNews.Consts.Messages;

namespace WebNews.Models
{
    public class Group
    {

        public Group()
        {
            News = new HashSet<News>();
        }

        [Key]
        public int GroupId { get; set; }

        #region Name 

        [Display(Name = "نام گروه")]
        [Required(ErrorMessage = ErrMsg.RequiredMsg)]
        [MaxLength(150, ErrorMessage = ErrMsg.MaxLengthMsg)]
        [MinLength(3, ErrorMessage = ErrMsg.MinLengthMsg)]
        public string Name { get; set; }

        #endregion


        #region Relationship
        public virtual ICollection<News> News { set; get; }
        #endregion
    }
}
