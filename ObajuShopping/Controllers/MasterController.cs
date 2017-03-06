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
        public List<Category> menCategories()
        {
            return db.Categories.ToList();
        }
        public PartialViewResult _navbarCategories()
        {
            var model = menCategories();
            return PartialView(model);
        }
    }
}