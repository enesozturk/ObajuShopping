using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ObajuShopping.Models;
using ObajuShopping.ViewModels;

namespace ObajuShopping.Controllers
{
    public class MasterController : Controller
    {
        ObajuEntities db = new ObajuEntities();
        
        public CategoryViewModel NavbarCategories()
        {
            CategoryViewModel cvm = new CategoryViewModel();
            cvm.menClothing = db.Category.Where(p => p.topCategory == 4).ToList();
            cvm.menShoes = db.Category.Where(p => p.topCategory == 5).ToList();
            cvm.menAccessories = db.Category.Where(p => p.topCategory == 6).ToList();
            cvm.LadyClothing = db.Category.Where(p => p.topCategory == 16).ToList();
            cvm.LadyShoes = db.Category.Where(p => p.topCategory == 17).ToList();
            cvm.LadyAccessories = db.Category.Where(p => p.topCategory == 18).ToList();
            return cvm;
        }
        public PartialViewResult _navbarCategories()
        {
            var model = NavbarCategories();
            return PartialView(model);
        }
    }
}