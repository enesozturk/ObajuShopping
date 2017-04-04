using System.Linq;
using System.Web.Mvc;
using ObajuShopping.Models;
using ObajuShopping.Interfaces;

namespace ObajuShopping.Controllers
{
    public class CartController : Controller
    {
        ObajuEntities db = new ObajuEntities();
        public ICartService _cartService;

        static string currentUserId;

        public CartController()
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated == true)
            {
                _cartService = new CartMember();
            }
            else
            {
                _cartService = new CartVisitor();
            }
            AspNetUsers currentUser = db.AspNetUsers.FirstOrDefault(x => x.Id == currentUserId);
        }
        public ActionResult Index()
        {
            var bms = _cartService.basketmodel();
            return View(bms);
        }

        // GET: /Store/AddToCart/5
        public ActionResult AddtoCart(int? id, int quantity)
        {
            _cartService.AddToCart(id, quantity);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _cartService.DeleteItemFromCart(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UpdateCart(System.Web.Mvc.FormCollection formc)
        {
            _cartService.UpdateCart(formc);

            return RedirectToAction("Index");
        }
    }
}