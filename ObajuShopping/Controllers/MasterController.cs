using System.Linq;
using System.Web.Mvc;
using ObajuShopping.Models;
using ObajuShopping.ViewModels;
using System.Collections.Generic;

namespace ObajuShopping.Controllers
{
    public class MasterController : Controller
    {
        ObajuEntities db = new ObajuEntities();

        public List<CategoryViewModel> NavbarCategories()
        {
            var name = db.Category.Where(p => p.topCategory == null).Select(s=>new CategoryViewModel { id= s.id, name =s.name,category = (List<Category>) s.Category1 }).ToList();
            return name;
        }
        public PartialViewResult _navbarCategories()
        {
            var model = NavbarCategories();
            return PartialView(model);
        }
    }
}