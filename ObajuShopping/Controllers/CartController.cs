using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ObajuShopping.Models;
using ObajuShopping.ViewModels;


namespace ObajuShopping.Controllers
{
    public class CartController : Controller
    {

        AaadbEntities db = new AaadbEntities();

        public ActionResult Index()
        {
            BasketModel bm = new BasketModel();
            var cart = (List<Basket>)Session["cart"];

            bm.basket = cart;
            bm.totalprice = cart.Sum(t => t.total);
            bm.productCount = cart.Count;

            return View(bm);
        }

        // GET: /Store/AddToCart/5
        public ActionResult AddtoCart(int? id, int quantity)
        {
            try
            {
                var urun = db.Products.Find(id);

                if (Session["cart"] == null) // cart session'u yoksa list turunden session olustur
                {
                    List<Basket> cart = new List<Basket>();
                    var basket = new Basket();
                    basket.productCount++;
                    basket.quantity = quantity;
                    basket.resim = urun.photo;
                    basket.price = (decimal)urun.price;
                    basket.productId = urun.id;
                    basket.productName = urun.name;
                    basket.total = (decimal)urun.price * quantity;
                    
                    cart.Add(basket);

                    Session["cart"] = cart;
                }
                else
                {
                    var cart = (List<Basket>)Session["cart"];
                    var isExist = cart.Where(p => p.productId == id).FirstOrDefault();

                    if (isExist == null)
                    {
                        var basket = new Basket();
                        basket.productCount = 0;
                        basket.quantity = quantity;
                        basket.resim = urun.photo;
                        basket.price = (decimal)urun.price;
                        basket.productId = urun.id;
                        basket.productName = urun.name;
                        basket.total = (decimal)urun.price * quantity;
                        basket.productCount++;
                        cart.Add(basket);
                    }
                    else
                    {
                        isExist.price = (decimal)urun.price;
                        isExist.quantity++;
                        isExist.total = (decimal)urun.price * isExist.quantity;
                    }
                    Session["cart"] = cart;

                }
            }
            catch (Exception e)
            {

                throw;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var cart = (List<Basket>)Session["cart"];
            var removedItem = cart.First(p => p.productId == id);
            removedItem.productCount--;
            cart.Remove(removedItem);
            Session["cart"] = cart;
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