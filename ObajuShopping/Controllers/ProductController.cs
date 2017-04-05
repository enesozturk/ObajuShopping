using System.Web.Mvc;
using ObajuShopping.Models;
using ProductViewModel = ObajuShopping.ViewModels.ProductViewModel;
using System.Linq;
using ObajuShopping.ViewModels;

namespace ObajuShopping.Controllers
{
    public class ProductController : Controller
    {
        ObajuEntities db = new ObajuEntities();
        ProductViewModel pvm = new ProductViewModel();
        CategoryDetailViewModel cdvm = new CategoryDetailViewModel();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category(int categoryid)
        {
            var urun = db.Product_Category_Rel.Where(w => w.categoryId == categoryid).ToList();
            var names = db.Category.Where(w => w.id == categoryid).Select(s => s.name).FirstOrDefault();
            cdvm.categories = urun;
            cdvm.id = categoryid;
            cdvm.name = names;
            return View(cdvm);
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