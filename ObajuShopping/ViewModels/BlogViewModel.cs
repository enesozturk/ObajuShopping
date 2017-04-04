using System.Collections.Generic;
using ObajuShopping.Models;

namespace ObajuShopping.ViewModels
{
    public class BlogViewModel
    {
        public Blog post { get; set; }
        public List<Blog> LatestPosts { get; set; }
    }
}
