using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
   public class ProductCategoryRepository
    {

        private ObjectCache cache = MemoryCache.Default;
        private List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = cache["ProductCategory"] as List<ProductCategory> ?? new List<ProductCategory>();
        }

        public void Commit()
        {
            cache["ProductCategory"] = productCategories;
        }

        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);
        }

        public void Update(ProductCategory productCategory)
        {
            ProductCategory producCategoryToUpdate = productCategories.Find(p => p.Id == productCategory.Id);

            if (producCategoryToUpdate != null)
            {
                producCategoryToUpdate = productCategory;
            }
            else
            {
                throw new Exception("Product category no Found");
            }
        }

        public ProductCategory Find(string Id)
        {
            ProductCategory product = productCategories.Find(p => p.Id == Id);

            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product Category no Found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(string id)
        {
            ProductCategory producCategoryToDelete = productCategories.Find(p => p.Id == id);

            if (producCategoryToDelete != null)
            {
                productCategories.Remove(producCategoryToDelete);
            }
            else
            {
                throw new Exception("Product Category no Found");
            }
        }
    }
}
