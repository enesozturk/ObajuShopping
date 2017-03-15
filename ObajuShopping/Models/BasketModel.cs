using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObajuShopping
{
    public class BasketModel
    {
        public List<Basket> basket { get; set; }
        public decimal totalprice { get; set; }
        public int productCount { get; set; }
    }
}
