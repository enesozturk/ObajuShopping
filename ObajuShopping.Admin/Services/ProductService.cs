using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ObajuShopping.Admin.Models;

namespace ObajuShopping.Admin.Services
{
    public class ProductService : IDisposable
    {
        private static bool UpdateDatabase = false;
        private ObajuShoppingAdmin db = new ObajuShoppingAdmin();
        

        public IList<Product> GetAll()
        {
            IList<Product> result = new List<Product>();
            result = db.Product.ToList();
            return result;
        }

        public IEnumerable<Product> Read()
        {
            return GetAll();
        }

        public void Create(Product product)
        {
            if (!UpdateDatabase)
            {
                var first = GetAll().OrderByDescending(p => p.id).FirstOrDefault();
                var id = (first != null) ? first.id : 0;

                product.id = id + 1;
                GetAll().Insert(0, product);
            }
            else
            {
                var entity = new Product();
                entity.id = product.id;
                entity.name = product.name;
                entity.quantity = product.quantity;
                entity.description = product.description;
                entity.photo = product.photo;
                entity.price = product.price;
                entity.specials = product.specials;
                entity.status = product.status;

                db.Product.Add(entity);
                db.SaveChanges();

                product.id = entity.id;
            }
        }

        public void Destroy(Product product)
        {
            if (!UpdateDatabase)
            {
                var target = GetAll().FirstOrDefault(p => p.id == product.id);
                if (target != null)
                {
                    GetAll().Remove(target);
                }
            }
            else
            {
                var entity = new Product();
                entity.id = product.id;
                db.Product.Attach(entity);
                db.Product.Remove(entity);
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}