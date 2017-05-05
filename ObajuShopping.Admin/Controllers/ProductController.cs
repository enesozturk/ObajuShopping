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
using ObajuShopping.Admin.Services;


namespace ObajuShopping.Admin.Controllers
{
    public class ProductController : Controller
    {
        ObajuShoppingAdmin db = new ObajuShoppingAdmin();
        private ProductService productService = new ProductService();


        public ActionResult List()
        {
            return View();
        }
        public ActionResult ProductList()
        {
            var products = db.Product.OrderBy(p => p.name).ToList();
            return Json(products, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Get([DataSourceRequest] DataSourceRequest request)
        {
            var products = db.Product.ToList();

            return this.Json(productService.Read().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Create([DataSourceRequest] DataSourceRequest request, Models.Product product)
        {

            if (product != null && ModelState.IsValid)
            {
                var productToCreate = new Product
                {
                    id = product.id,
                    name = product.name,
                    price = product.price,
                    quantity = product.quantity,
                    description = product.description,
                    photo = product.photo,
                    status = product.status,
                    specials = product.specials
                };

                db.Product.Add(productToCreate);
                db.SaveChanges();

            }

            return Json(ModelState.IsValid ? true : ModelState.ToDataSourceResult());

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