using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObajuShopping
{
    [Serializable]
    public class Basket
    {
        public int productId { get; set; }
        public string resim { get; set; }
        public string productName { get; set; }
        public decimal price { get; set; }
        public decimal total { get; set; }
        public int quantity { get; set; }
        public int productCount { get; set; }
    }
}