using ObajuShopping.Models;
using System.Collections.Generic;

namespace ObajuShopping.ViewModels
{
    public class CategoryDetailViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Product_Category_Rel> categories { get; set; }
    }
}