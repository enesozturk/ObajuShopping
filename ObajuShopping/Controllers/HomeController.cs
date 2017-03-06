using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ObajuShopping.Models;
using ObajuShopping.ViewModels;

namespace Obaju.Controllers
{
    public class HomeController : Controller
    {
        AaadbEntities db = new AaadbEntities();
        public ActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel();
            hvm.Posts = db.Blogs.Take(2).ToList();
            hvm.LatestProducts = db.Products.OrderByDescending(p => p.id).ToList();
            hvm.Sliders = db.Sliders.OrderBy(p => p.id).ToList();
            hvm.FeaturedProducts = db.Products.Where(p => p.specials == true).ToList();
            return View(hvm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
