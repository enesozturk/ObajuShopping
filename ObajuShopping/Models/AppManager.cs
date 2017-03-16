using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using ObajuShopping.Interfaces;

namespace ObajuShopping.Models
{
    public class AppManager : Controller
    {
        public ICartService _cartService = new CartVisitor();

        AaadbEntities db = new AaadbEntities();
        

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
                    string currentUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();

                    _cartService = new CartMember();
                }
            }
        }
    }
}