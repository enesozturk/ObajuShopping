using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ObajuShopping.Admin.Models
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [UIHint("Integer")]
        public int UnitsInStock { get; set; }

        public decimal ProductPrice { get; set; }
        public bool ProductStatus { get; set; }
        public string ProductPhoto { get; set; }
        public bool ProductSpecials { get; set; }
        public string ProductDescription { get; set; }
    }
}