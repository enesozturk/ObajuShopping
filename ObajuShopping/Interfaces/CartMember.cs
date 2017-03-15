using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using ObajuShopping.Interfaces;

namespace ObajuShopping.Models
{
    public class CartMember : ICartService
    {
        static AaadbEntities db = new AaadbEntities();
       
        static string currentUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
        AspNetUser currentUser = db.AspNetUsers.FirstOrDefault(x => x.Id == currentUserId);

        public BasketModel basketmodel()
        {
            BasketModel bm = new BasketModel();
            var cart =
                    db.Carts.Where(c => c.memberId == currentUserId)
                        .Select(s => new Basket
                        {
                            productId = s.productId,
                            resim = s.Product.photo,
                            price = s.price,
                            total = s.total,
                            quantity = s.quantity,
                            productName = s.Product.name
                        })
                        .ToList();
            bm.basket = cart;
            bm.totalprice = cart.Sum(t => t.total);
            bm.productCount = cart.Count;

            return bm;
        }

        public void AddToCart(int? id, int quantity)
        {
            var urun = db.Products.Find(id);

            Cart yeniSepet = new Cart();
            yeniSepet.memberId = currentUserId;
            yeniSepet.productId = urun.id;
            yeniSepet.price = (decimal)urun.price;
            yeniSepet.productCount++;
            yeniSepet.quantity = quantity;
            yeniSepet.total = (decimal)urun.price * quantity;

            db.Carts.Add(yeniSepet);
            db.SaveChanges();

        }

        public void DeleteItemFromCart(int id)
        {
            var cartRow = db.Carts.FirstOrDefault(c => c.productId == id);
            db.Carts.Remove(cartRow);
            db.SaveChanges();
        }

        [System.Web.Mvc.AllowAnonymous]
        public void UpdateCart(System.Web.Mvc.FormCollection formc)
        {
            string[] quantities = (string[])formc.GetValues("quantity");

            var cart = db.Carts.Where(c => c.memberId == currentUserId).ToList();
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
            db.SaveChanges();
        }
    }
}
