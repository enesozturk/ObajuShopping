﻿using System.Collections.Generic;
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

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(productService.Read().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Create([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        {
            if (product != null && ModelState.IsValid)
            {
                productService.Create(product);
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
            

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        {
            if (product != null && ModelState.IsValid)
            {
                productService.Update(product);
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, ProductViewModel product)
        {
            if (product != null)
            {
                productService.Destroy(product);
            }

            return Json(new[] { product }.ToDataSourceResult(request, ModelState));
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