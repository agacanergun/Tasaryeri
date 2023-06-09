using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.Core.Interfaces;
using Tasaryeri.DAL.Entities;
using Tasaryeri.DAL.EntityFramework.Abstract;

namespace Tasaryeri.DAL.EntityFramework
{
    public class EfProductDAL : IEfProductDAL
    {
        IRepository<Product> repoProduct;
        IRepository<Saler> repoSaler;
        IRepository<SubCategory> repoSubCategories;
        IRepository<ProductCategory> repoProductCategory;
        public EfProductDAL(IRepository<Product> repoProduct, IRepository<Saler> repoSaler, IRepository<SubCategory> repoSubCategories, IRepository<ProductCategory> repoProductCategory)
        {
            this.repoProduct = repoProduct;
            this.repoSaler = repoSaler;
            this.repoSubCategories = repoSubCategories;
            this.repoProductCategory = repoProductCategory;
        }

        public bool Add(Product entity, int[] CategoriyIDs)
        {
            var response = repoProduct.Add(entity);
            if (response == 1)
            {
                var addedProductId = entity.Id;
                List<ProductCategory> productCategories = new List<ProductCategory>();
                foreach (var id in CategoriyIDs)
                {
                    ProductCategory productCategory = new ProductCategory
                    {
                        ProductID = addedProductId,
                        CategoryID = id,
                    };
                    productCategories.Add(productCategory);
                }
                var responseProductCategory = repoProductCategory.AddRange(productCategories);
                if (responseProductCategory != 0)
                    return true;
                return false;

            }
            return false;
        }

        public bool Delete(Product entity)
        {
            var response = repoProduct.Delete(entity);
            if (response == 1)
                return true;
            return false;
        }

        public IEnumerable<Product> GetAll(int id)
        {
            var saler = repoSaler.GetBy(x => x.Id == id);
            var response = repoProduct.GetAll(x => x.SalerId == id);


            foreach (var item in response)
            {
                item.ProductCategories = repoProductCategory.GetAll(x => x.ProductID == item.Id).ToList();
                item.saler = saler;
            }

            foreach (var item in response)
            {
                foreach (var item1 in item.ProductCategories)
                {
                    var responseSubCategories = repoSubCategories.GetBy(x => x.Id == item1.CategoryID);
                    item1.CategoryName = responseSubCategories.Name;
                }

            }

            return response;
        }

        public Product GetById(int id)
        {
            return repoProduct.GetBy(x => x.Id == id);
        }

        public IEnumerable<SubCategory> GetSubCategories()
        {
            return repoSubCategories.GetAll().OrderBy(x => x.Name);
        }

        public bool Update(Product entity)
        {
            var response = repoProduct.Update(entity);
            if (response == 1)
                return true;
            return false;
        }
    }
}
