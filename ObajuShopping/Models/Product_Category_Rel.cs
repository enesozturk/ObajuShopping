//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ObajuShopping.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product_Category_Rel
    {
        public int id { get; set; }
        public int productId { get; set; }
        public int categoryId { get; set; }
        public bool isOrigin { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Product Product { get; set; }
    }
}