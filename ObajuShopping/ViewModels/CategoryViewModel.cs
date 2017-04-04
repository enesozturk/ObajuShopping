using ObajuShopping.Models;
using System.Collections.Generic;

namespace ObajuShopping
{
    public class CategoryViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Category> category { get; set; }
    }
}