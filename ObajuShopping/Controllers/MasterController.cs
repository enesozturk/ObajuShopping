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
        AaadbEntities db = new AaadbEntities();
        
        public CategoryViewModel NavbarCategories()
        {
            CategoryViewModel cvm = new CategoryViewModel();
            cvm.menClothing = db.Categories.Where(p => p.topCategory == 4).ToList();
            cvm.menShoes = db.Categories.Where(p => p.topCategory == 5).ToList();
            cvm.menAccessories = db.Categories.Where(p => p.topCategory == 6).ToList();
            cvm.LadyClothing = db.Categories.Where(p => p.topCategory == 16).ToList();
            cvm.LadyShoes = db.Categories.Where(p => p.topCategory == 17).ToList();
            cvm.LadyAccessories = db.Categories.Where(p => p.topCategory == 18).ToList();
            return cvm;
        }
        public PartialViewResult _navbarCategories()
        {
            var model = NavbarCategories();
            return PartialView(model);
        }
    }
}