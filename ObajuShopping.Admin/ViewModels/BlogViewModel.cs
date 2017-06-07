using System;

namespace ObajuShopping.Admin.ViewModels
{
    public class BlogViewModel
    {
        public int BlogID { get; set; }
        public string BlogAuthor { get; set; }
        public DateTime BlogDate { get; set; }
        public string BlogTitle { get; set; }
        public string BlogImage { get; set; }
        public string BlogContent { get; set; }
    }
}