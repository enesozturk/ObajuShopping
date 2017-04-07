using ObajuShopping.Admin.Models;
using System.Linq;
using System.Web.Mvc;

namespace ObajuShopping.Admin.Controllers
{
    public class ProductController : Controller
    {
        ObajuEntities db = new ObajuEntities();
        public ActionResult List()
        {
            var data = db.list_products_reg().ToList();
            ViewBag.products = data;
            return View();
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