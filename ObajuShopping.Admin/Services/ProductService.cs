using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using ObajuShopping.Admin.Models;

namespace ObajuShopping.Admin.Services
{
    public class ProductService : IDisposable
    {
        private static bool UpdateDatabase = true;
        private ObajuShoppingAdmin db = new ObajuShoppingAdmin();

        public IList<ProductViewModel> GetAll()
        {
            IList<ProductViewModel> result = new List<ProductViewModel>();

            result = db.Product.Select(product => new ProductViewModel
            {
                ProductID = product.id,
                ProductName = product.name,
                UnitsInStock = product.quantity,
                ProductPrice = product.price,
                ProductSpecials = product.specials,
                ProductPhoto = product.photo,
                ProductDescription = product.description,
                ProductStatus = product.status
            }).ToList();

            return result;
        }

        public IEnumerable<ProductViewModel> Read()
        {
            return GetAll();
        }

        public void Create(ProductViewModel product)
        {
            if (!UpdateDatabase)
            {
                var first = GetAll().OrderByDescending(p => p.ProductID).FirstOrDefault();
                var id = (first != null) ? first.ProductID : 0;

                product.ProductID = id + 1;
                GetAll().Insert(0, product);
            }
            else
            {
                var entity = new Product();
                entity.id = product.ProductID;
                entity.name = product.ProductName;
                entity.quantity = product.UnitsInStock;
                entity.description = product.ProductDescription;
                entity.photo = product.ProductPhoto;
                entity.price = product.ProductPrice;
                entity.specials = product.ProductSpecials;
                entity.status = product.ProductStatus;

                db.Product.Add(entity);
                db.SaveChanges();

                product.ProductID = entity.id;
            }
        }

        public void Update(ProductViewModel product)
        {
            if (!UpdateDatabase)
            {
                //var target = One(e => e.ProductID == product.ProductID);

                //if (target != null)
                //{
                //    target.ProductName = product.ProductName;
                //    target.UnitsInStock = product.UnitsInStock;
                //}
            }
            else
            {
                var entity = new Product();
                entity.id = product.ProductID;
                entity.name = product.ProductName;
                entity.quantity = product.UnitsInStock;
                entity.description = product.ProductDescription;
                entity.price = product.ProductPrice;
                entity.specials = product.ProductSpecials;
                entity.status = product.ProductStatus;
                entity.photo = product.ProductPhoto;

                db.Product.Attach(entity);
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Destroy(ProductViewModel product)
        {
            if (!UpdateDatabase)
            {
                //var target = GetAll().FirstOrDefault(p => p.ProductID == product.ProductID);
                //if (target != null)
                //{
                //    GetAll().Remove(target);
                //}
            }
            else
            {
                var entity = new Product();
                entity.id = product.ProductID;
                db.Product.Attach(entity);
                db.Product.Remove(entity);
                db.SaveChanges();
            }
        }

        public ProductViewModel One(Func<ProductViewModel, bool> predicate)
        {
            var result = GetAll().FirstOrDefault();
            return GetAll().FirstOrDefault(predicate);
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}