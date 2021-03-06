﻿using System.Collections.Generic;
using System.Linq;
using ObajuShopping.Models;

namespace ObajuShopping.ViewModels
{
    public class ProductViewModel
    {
        ObajuEntities db = new ObajuEntities();

        public int id { get; set; }
        public string name { get; set; }
        public List<Product> product { get; set; }

        public Product Product { get; set; }

        public List<Product> LatestProducts()
        {
            return db.Product.OrderByDescending(p => p.id).ToList();
        }
        public List<Product> SpecialProducts()
        {
            return db.Product.Where(p => p.specials == true).ToList();
        }
        public List<Product_Category_Rel> CategoryProducts(int categoryid)
        {
            return db.Product_Category_Rel.Where(w => w.id == categoryid).ToList();
        }
        public List<Product_Category_Rel> RelatedProducts(int id)
        {
            var product = db.Product_Category_Rel.FirstOrDefault(p => p.productId == id && p.isOrigin == true);

            return db.Product_Category_Rel.Where(p => p.isOrigin == true && p.productId != product.productId && p.categoryId == product.categoryId).ToList();
        }
    }
}
