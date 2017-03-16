using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ObajuShopping.Interfaces;
using ObajuShopping.Models;
using ObajuShopping.ViewModels;

namespace ObajuShopping.Controllers
{
    public class CartController : Controller
    {
        AaadbEntities db = new AaadbEntities();
        public ICartService _cartService = new CartVisitor();

        //static string currentUserId;
        public CartController()
        {
            if (User != null)
            {
                if (User.Identity.IsAuthenticated == true)
                {
                    //currentUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                    _cartService = new CartMember();
                }
            }
            //AspNetUser currentUser = db.AspNetUsers.FirstOrDefault(x => x.Id == currentUserId);
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