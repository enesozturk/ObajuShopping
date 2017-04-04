using System.Linq;
using System.Web.Mvc;
using ObajuShopping.Models;
using ObajuShopping.ViewModels;

namespace ObajuShopping.Controllers
{
    public class HomeController : Controller
    {
        ObajuEntities db = new ObajuEntities();
        public ActionResult Index()
        {
            HomeViewModel hvm = new HomeViewModel();
            hvm.Posts = db.Blog.Take(2).ToList();
            hvm.LatestProducts = db.Product.OrderByDescending(p => p.id).ToList();
            hvm.Sliders = db.Slider.OrderBy(p => p.id).ToList();
            hvm.FeaturedProducts = db.Product.Where(p => p.specials == true).ToList();
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
