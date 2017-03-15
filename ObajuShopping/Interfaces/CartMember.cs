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

            var cart = db.Carts.Where(c => c.Product.id == id).ToList();

            if (cart == null)
            {
                List<Cart> cart1 = new List<Cart>();

                var yeniSatir = new Cart();

                yeniSatir.memberId = currentUserId;
                yeniSatir.productId = urun.id;
                yeniSatir.price = (decimal)urun.price;
                yeniSatir.productCount++;
                yeniSatir.quantity = quantity;
                yeniSatir.total = (decimal)urun.price * quantity;

                db.Carts.Add(yeniSatir);
            }
            else
            {
                var isExist = cart.Where(p => p.productId == id).FirstOrDefault(); //kartın içinde var

                if (isExist == null) //yoksa
                {
                    Cart yeniSatir = new Cart();

                    yeniSatir.memberId = currentUserId;
                    yeniSatir.productId = urun.id;
                    yeniSatir.price = (decimal)urun.price;
                    yeniSatir.productCount++;
                    yeniSatir.quantity = quantity;
                    yeniSatir.total = (decimal)urun.price * quantity;

                    db.Carts.Add(yeniSatir);
                }
                else
                {
                    isExist.price = (decimal)urun.price;
                    isExist.quantity++;
                    isExist.total = (decimal)urun.price * isExist.quantity;

                }
            }
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
                cart[i].quantity = Convert.ToInt32(quantities[i]);
                db.SaveChanges();
                if (cart[i].quantity == 0)
                {
                    db.Carts.Remove(cart[i]);
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
