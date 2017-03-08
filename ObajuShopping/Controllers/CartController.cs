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
            var cart = (List<Basket>) Session["cart"];
            //var viewModel = new CartViewModel()
            //{
            //    CartItems = cart.GetCartItems(),
            //    CartTotal = cart.GetTotal()
            //};
            //return View(viewModel);
            return View(cart);
        }

        // GET: /Store/AddToCart/5
        public ActionResult AddtoCart(int? id,int quantity)
        {
            try
            {
                var urun = db.Products.Find(id);

                if (Session["cart"] == null) // cart session'u yoksa list turunden session olustur
                {
                    List<Basket> cart = new List<Basket>();
                   
                    var basket = new Basket();
                    basket.count = quantity;
                    basket.discount = 0;
                    basket.resim = urun.photo;
                    basket.price = (decimal)urun.price;
                    basket.productid = urun.id;
                    basket.productname = urun.name;
                    basket.total = (decimal)urun.price * quantity;
                    cart.Add(basket);

                    Session["cart"] = cart;
                }
                else
                {
                    var cart = (List<Basket>)Session["cart"];

                    

                    var isExist = cart.Where(p => p.productid == id).FirstOrDefault();
                    if (isExist == null)
                    {
                        var basket = new Basket();
                        basket.count = quantity;
                        basket.discount = 0;
                        basket.resim = urun.photo;
                        basket.price = (decimal)urun.price;
                        basket.productid = urun.id;
                        basket.productname = urun.name;
                        basket.total = (decimal)urun.price * quantity;
                        cart.Add(basket);

                    }
                    else
                    {
                        isExist.price = (decimal)urun.price;
                        isExist.total = (decimal) urun.price * quantity;

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
            var removedItem = cart.First(p => p.productid == id);
            cart.Remove(removedItem);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }
    }
}