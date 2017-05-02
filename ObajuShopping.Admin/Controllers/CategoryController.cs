using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ObajuShopping.Admin.Models;

namespace ObajuShopping.Admin.Controllers
{
    public class CategoryController : Controller
    {
        ObajuShoppingAdmin db = new ObajuShoppingAdmin();

        public ActionResult List()
        {
            return View();
        }
        public ActionResult CategoryList()
        {
            var categories = db.Category.Select(s=> new { s.id, s.name, s.isActive }).OrderBy(p => p.name);
            return Json(categories, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        public ActionResult UpdateProduct()
        {
            return View();
        }
    }
}