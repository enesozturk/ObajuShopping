using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ObajuShopping.Models;

namespace ObajuShopping.ViewModels
{
    public class ProductViewModel
    {
        AaadbEntities db = new AaadbEntities();

        public Product Product { get; set; }
        public List<Product> LatestProducts()
        {
            return db.Products.OrderByDescending(p => p.id).ToList();
        }
        public List<Product> SpecialProducts()
        {
            return db.Products.Where(p => p.specials == true).ToList();
        }

        public List<Product_CatgoryRel> RelatedProducts(int id)
        {
            var product = db.Product_CatgoryRel.FirstOrDefault(p => p.productId == id && p.isOrigin == true);

            return db.Product_CatgoryRel.Where(p => p.isOrigin == true && p.productId != product.productId && p.categoryId == product.categoryId).ToList();
        }
    }
}
