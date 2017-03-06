using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ObajuShopping.Controllers
{
    public class AboutUsController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ActionName = "About Us";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.ActionName = "Contact";
            return View();
        }

        public ActionResult FAQ()
        {
            ViewBag.ActionName = "Frequendly Asked Questions";
            return View();
        }
    }
}