using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNews.Models.ViewModels
{
    public class PreviewNewsViewModel
    {
        public PreviewNewsViewModel()
        {
            ImagesName = new List<string>();
        }

        public int Id { set; get; }

        public string Title { set; get; }

        public List<string> ImagesName { set; get; }

        public string Text { set; get; }

        public string CreateDate { set; get; }
    }
}
