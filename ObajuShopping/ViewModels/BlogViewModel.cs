using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObajuShopping.Models;

namespace ObajuShopping.ViewModels
{
    public class BlogViewModel
    {
        public Blog post { get; set; }
        public List<Blog> LatestPosts { get; set; }
    }
}
