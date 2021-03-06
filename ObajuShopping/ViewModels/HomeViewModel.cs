﻿using System.Collections.Generic;
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
