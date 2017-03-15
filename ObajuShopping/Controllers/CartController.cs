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
    public class CartController : AppManager
    {
        //ICartService _cartService = new CartVisitor();
        AaadbEntities db = new AaadbEntities();
        public CartController()
        {
           
        }
        public ActionResult Index()
        {
            var bms = _cartService.basketmodel();
            ViewBag.productCounts = bms.productCount;
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