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
      
    

        public CartController()
        {
           
        }

        AaadbEntities db = new AaadbEntities();

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

        //[ChildActionOnly]
        //[Route("UpdateCart/{id}/{quantity}")]
        //[HttpPost, ActionName("Index")]
        [HttpPost]
        public ActionResult UpdateCart(FormCollection formc)
        {

            string[] quantities = formc.GetValues("quantity");
            List<Basket> cart = (List<Basket>) Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].quantity == 0)
                {
                    cart.Remove(cart[i]);
                }
                else
                {
                    cart[i].quantity = Convert.ToInt32(quantities[i]);
                    cart[i].total = cart[i].price * Convert.ToInt32(quantities[i]);
                }
            }

            Session["cart"] = cart;

            return RedirectToAction("Index");
        }
    }
}