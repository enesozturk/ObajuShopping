using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataTables.AspNet.Core;
using ObajuShopping.Admin.Models;
using DataTables.AspNet.Mvc5;
using Kendo;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;


namespace ObajuShopping.Admin.Controllers
{
    public class ProductController : Controller
    {
        ObajuShoppingAdmin db = new ObajuShoppingAdmin();

        public ActionResult List()
        {
            return View();
        }
        public ActionResult ProductList()
        {
            var products = db.Product.OrderBy(p => p.name).ToList();
            return Json(products, JsonRequestBehavior.AllowGet);

        }

        //public ActionResult PageData(IDataTablesRequest request)
        //{
        //    var data = db.Product.ToList();
        //    var filteredData = db.Product.Where(p => p.name.Contains(request.Search.Value));
        //    var dataPage = filteredData.Skip(request.Start).Take(request.Length);
        //    var response = DataTablesResponse.Create(request, data.Count(), filteredData.Count(), dataPage);
        //    return new DataTablesJsonResult(response, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            db.Product.Add(product);
            db.SaveChanges();

            return RedirectToAction("List", "Product");
        }

        public static IEnumerable<Product> GetProducts()
        {
            var db = new ObajuShoppingAdmin();
            return db.Product.ToList();
        }

        public ActionResult Products_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetProducts().ToDataSourceResult(request));
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