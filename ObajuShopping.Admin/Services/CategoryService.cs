using ObajuShopping.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ObajuShopping.Admin.Services
{
    public class CategoryService : IDisposable
    {
        private static bool UpdateDatbase = true;
        private ObajuShoppingAdmin db = new ObajuShoppingAdmin();

        public IList<CategoryViewModel> GetAll()
        {
            IList<CategoryViewModel> result = new List<CategoryViewModel>();

            result = db.Category.Select(category => new CategoryViewModel
            {
                CategoryID = category.id,
                CategoryName = category.name,
                CategoryTopCat = category.topCategory,
                CategoryIsActive = category.isActive
            }).ToList();

            return result;
        }

        public IEnumerable<CategoryViewModel> Read()
        {
            return GetAll();
        }

        public void Create(CategoryViewModel category)
        {
            if (!UpdateDatbase)
            {
                var first = GetAll().OrderByDescending(c => c.CategoryID).FirstOrDefault();
                var id = (first != null) ? first.CategoryID : 0;

                category.CategoryID = id + 1;
                GetAll().Insert(0, category);
            }
            else
            {
                var entity = new Category();
                entity.id = category.CategoryID;
                entity.name = category.CategoryName;
                entity.topCategory = category.CategoryTopCat;
                entity.isActive = category.CategoryIsActive;

                db.Category.Add(entity);
                db.SaveChanges();

                category.CategoryID = entity.id;
            }
        }

        public void Update(CategoryViewModel category)
        {
            if (!UpdateDatbase)
            {
                var target = One(e => e.CategoryID == category.CategoryID);

                if (target != null)
                {
                    target.CategoryName = category.CategoryName;
                    target.CategoryTopCat = category.CategoryTopCat;
                }
            }
            else
            {
                var entity = new Category();
                entity.id = category.CategoryID;
                entity.name = category.CategoryName;
                entity.topCategory = category.CategoryTopCat;
                entity.isActive = category.CategoryIsActive;

                db.Category.Attach(entity);
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Destroy(CategoryViewModel category)
        {
            if (!UpdateDatbase)
            {
                var target = GetAll().FirstOrDefault(c => c.CategoryID == category.CategoryID);
                if (target != null)
                {
                    GetAll().Remove(target);
                }
            }
            else
            {
                var entity = new Category();
                entity.id = category.CategoryID;

                db.Category.Attach(entity);
                db.Category.Remove(entity);
                db.SaveChanges();
            }
        }

        public CategoryViewModel One(Func<CategoryViewModel, bool> predicate)
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