using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ObajuShopping.Interfaces;

namespace ObajuShopping.Models
{
    public class AppManager : Controller
    {
        public ICartService _cartService = new CartVisitor();

        public AppManager()
        {
            control();
        }

        void control()
        {

            if (System.Web.HttpContext.Current.User != null)
            {
                if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated == true)
                {
                    _cartService = new CartMember();
                }
            }
        }
    }
}