using ObajuShopping.Admin.Models;
using System.Linq;
using System.Web.Mvc;

namespace ObajuShopping.Admin.Controllers
{
    public class ProductController : Controller
    {
        ObajuEntitiesAdmin db = new ObajuEntitiesAdmin();

        public ActionResult List()
        {
            return View();
        }
        public ActionResult ProductList()
        {
            var products = db.Product.OrderBy(p => p.name).ToList();
            return Json(products, JsonRequestBehavior.AllowGet);

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