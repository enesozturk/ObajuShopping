//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ObajuShopping.Admin.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Blog
    {
        public int id { get; set; }
        public string yazar { get; set; }
        public System.DateTime tarih { get; set; }
        public string baslik { get; set; }
        public string baslikresim { get; set; }
        public string icerik { get; set; }
    }
}
