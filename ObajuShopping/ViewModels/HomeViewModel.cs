using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObajuShopping.Models;

namespace ObajuShopping.ViewModels
{
    public class HomeViewModel
    {
        public List<Blog> Posts { get; set; }
        public List<Product> LatestProducts { get; set; }
        public List<Product> FeaturedProducts { get; set; }
        public List<Slider> Sliders { get; set; }
    }
}
