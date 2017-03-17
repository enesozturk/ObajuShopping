using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ObajuShopping.Models;
using ObajuShopping.ViewModels;

namespace ObajuShopping.Interfaces
{
    public class CartVisitor : ICartService
    {
        AaadbEntities db = new AaadbEntities();
      
        public BasketModel basketmodel()
        {
            BasketModel bm = new BasketModel();

            var cart = (List<Basket>)HttpContext.Current.Session["cart"];
            List<Basket> lm = new List<Basket>(); //If there is no product in cart this object will show empty cart.
            if (cart != null)
            {
                if(cart.Count == 0)
                {
                    
                }
                bm.basket = cart;
                bm.totalprice = cart.Sum(t => t.total);
                bm.productCount = cart.Count;
            }
            else
            {
                bm.basket = lm;
            }

            return bm;

        }
        public void AddToCart(int? id, int quantity)
        {
            try
            {
                var urun = db.Products.Find(id);

                if (HttpContext.Current.Session["cart"] == null) // cart session'u yoksa list turunden session olustur
                {
                    List<Basket> cart = new List<Basket>();
                    var basket = new Basket();
                    basket.quantity = quantity;
                    basket.resim = urun.photo;
                    basket.price = (decimal)urun.price;
                    basket.productId = urun.id;
                    basket.productName = urun.name;
                    basket.total = (decimal)urun.price * quantity;

                    cart.Add(basket);

                    HttpContext.Current.Session["cart"] = cart;
                }
                else
                {
                    var cart = (List<Basket>)HttpContext.Current.Session["cart"];

                    var isExist = cart.Where(p => p.productId == id).FirstOrDefault();

                    if (isExist == null)
                    {
                        var basket = new Basket();
                        basket.quantity = quantity;
                        basket.resim = urun.photo;
                        basket.price = (decimal)urun.price;
                        basket.productId = urun.id;
                        basket.productName = urun.name;
                        basket.total = (decimal)urun.price * quantity;
                        cart.Add(basket);
                    }
                    else
                    {
                        isExist.price = (decimal)urun.price;
                        isExist.quantity++;
                        isExist.total = (decimal)urun.price * isExist.quantity;
                    }
                    HttpContext.Current.Session["cart"] = cart;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void DeleteItemFromCart(int id)
        {
            var cart = (List<Basket>)HttpContext.Current.Session["cart"];
            var removedItem = cart.First(p => p.productId == id);
            cart.Remove(removedItem);
            HttpContext.Current.Session["cart"] = cart;
        }

        public void UpdateCart(System.Web.Mvc.FormCollection formc)
        {
            string[] quantities = (string[])formc.GetValues("quantity");
            List<Basket> cart = (List<Basket>)HttpContext.Current.Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                cart[i].quantity = Convert.ToInt32(quantities[i]);

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

            HttpContext.Current.Session["cart"] = cart;
        }
    }
}
