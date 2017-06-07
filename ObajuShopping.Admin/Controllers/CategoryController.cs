using System.Web.Mvc;
using ObajuShopping.Admin.Models;
using ObajuShopping.Admin.ViewModels;
using ObajuShopping.Admin.Services;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace ObajuShopping.Admin.Controllers
{
    public class CategoryController : Controller
    {
        ObajuShoppingAdmin db = new ObajuShoppingAdmin();
        private CategoryService categoryService = new CategoryService();

        public ActionResult List()
        {
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(categoryService.Read().ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult Create([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null && ModelState.IsValid) categoryService.Create(category);
            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null && ModelState.IsValid) categoryService.Update(category);
            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null) categoryService.Destroy(category);
            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }
    }
}