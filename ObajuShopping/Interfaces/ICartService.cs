using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace ObajuShopping.Interfaces
{
    public partial interface ICartService
    {
        BasketModel basketmodel();
        void AddToCart(int? id, int quantity);
        void DeleteItemFromCart(int id);
        void UpdateCart(System.Web.Mvc.FormCollection formc);
    }
}
