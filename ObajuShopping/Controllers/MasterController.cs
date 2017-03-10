using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ObajuShopping.Models;

namespace ObajuShopping.Controllers
{
    public class MasterController : Controller
    {
        AaadbEntities db = new AaadbEntities();
        public List<Category> menClothing()
        {
            return db.Categories.Where(p => p.topCategory == 2).ToList();
        }
        public PartialViewResult _navbarCategories()
        {
            var model = menClothing();
            return PartialView(model);
        }
    }
}