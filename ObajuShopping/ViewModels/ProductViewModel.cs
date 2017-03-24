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
        ObajuEntities db = new ObajuEntities();

        public Product Product { get; set; }
        public List<Product> LatestProducts()
        {
            return db.Product.OrderByDescending(p => p.id).ToList();
        }
        public List<Product> SpecialProducts()
        {
            return db.Product.Where(p => p.specials == true).ToList();
        }

        public List<Product_Category_Rel> RelatedProducts(int id)
        {
            var product = db.Product_Category_Rel.FirstOrDefault(p => p.productId == id && p.isOrigin == true);

            return db.Product_Category_Rel.Where(p => p.isOrigin == true && p.productId != product.productId && p.categoryId == product.categoryId).ToList();
        }
    }
}
