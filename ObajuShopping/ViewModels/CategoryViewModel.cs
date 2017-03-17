using ObajuShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObajuShopping.ViewModels
{
    public class CategoryViewModel
    {
        public List<Category> menClothing;
        public List<Category> menShoes;
        public List<Category> menAccessories;
        public List<Category> LadyClothing;
        public List<Category> LadyShoes;
        public List<Category> LadyAccessories;
    }
}