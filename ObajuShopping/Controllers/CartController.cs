using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ObajuShopping.Interfaces;
using ObajuShopping.Models;
using ObajuShopping.ViewModels;

namespace ObajuShopping.Controllers
{
    public class CartController : Controller
    {
        ICartService _cartService = new CartVisitor();
        AaadbEntities db = new AaadbEntities();
        public CartController()
        {
            if (System.Web.HttpContext.Current.User != null)
            {
                if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated == true)
                {
                    _cartService = new CartMember();
                }
            }
        }
        public ActionResult Index()
        {
            var bms = _cartService.basketmodel();

            return View(bms);
        }

        // GET: /Store/AddToCart/5
        public ActionResult AddtoCart(int? id, int quantity)
        {
            _cartService.AddToCart(id,quantity);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _cartService.DeleteItemFromCart(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        //[System.Web.Mvc.AllowAnonymous]
        public ActionResult UpdateCart(System.Web.Mvc.FormCollection formc)
        {
            _cartService.UpdateCart(formc);

            return RedirectToAction("Index");
        }
    }
}