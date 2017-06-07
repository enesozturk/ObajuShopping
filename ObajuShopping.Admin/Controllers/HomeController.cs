using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ObajuShopping.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult About()
        {
            return Json(new
            {
                Name = "Enes",
                Surname = "Ozturk",
                Description = "Bilgisayar Mühendisi Öğrencisi. Yamaçparaşütü pilotu"
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}