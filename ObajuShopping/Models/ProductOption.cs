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
    
    public partial class ProductOption
    {
        public int id { get; set; }
        public int productiId { get; set; }
        public int optionId { get; set; }
        public int priceIncrement { get; set; }
        public int optionGroupId { get; set; }
    
        public virtual Option Option { get; set; }
        public virtual Product Product { get; set; }
    }
}