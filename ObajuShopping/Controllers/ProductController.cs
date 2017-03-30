using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ObajuShopping.Interfaces;
using ObajuShopping.Models;
using ObajuShopping.ViewModels;
using ProductViewModel = ObajuShopping.ViewModels.ProductViewModel;

namespace ObajuShopping.Controllers
{
    public class ProductController : Controller
    {
        ObajuEntities db = new ObajuEntities();
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
            ProductViewModel pvm = new ProductViewModel();
            //pvm.RelatedProducts(id);
            pvm.Product = db.Product.Find(id);

            return View(pvm);
        }
    }
}