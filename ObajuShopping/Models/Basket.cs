using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObajuShopping
{
    [Serializable]
    public class Basket
    {
        public int productid { get; set; }
        public string resim { get; set; }
        public string productname { get; set; }
        public decimal price { get; set; }
        public decimal discount { get; set; }

        public decimal total { get; set; }
        public int count { get; set; }
    }
}