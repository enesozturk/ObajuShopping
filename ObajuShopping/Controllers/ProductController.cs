﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ObajuShopping.Models;
using ObajuShopping.ViewModels;
using ProductViewModel = ObajuShopping.ViewModels.ProductViewModel;

namespace Obaju.Controllers
{
    public class ProductController : Controller
    {
        AaadbEntities db = new AaadbEntities();
        //private ProductViewModel _pvm = new ProductViewModel();
        ProductViewModel pvm = new ProductViewModel();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category(int id)
        {
            return View();
        }

        public ActionResult Latest()
        {
            var latestProducts = pvm.LatestProducts();
            return View(latestProducts);
        }
        public ActionResult Special()
        {
            var specialProducts = pvm.SpecialProducts();
            return View(specialProducts);
        }
        public ActionResult Detail(int id)
        {
            Product product = db.Products.Find(id);
            ViewBag.relatedProducts = pvm.RelatedProducts(product, 4);

            return View(product);
        }
    }
}