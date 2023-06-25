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
            try
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
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Product entity)
        {
            try
            {
                var response = repoProduct.Delete(entity);
                if (response == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Product> GetAll(int id)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }

        public Product GetById(int id)
        {
            try
            {
                return repoProduct.GetBy(x => x.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<SubCategory> GetSubCategories()
        {
            try
            {
                return repoSubCategories.GetAll().OrderBy(x => x.Name);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Product entity, List<ProductCategory> productCategories)
        {
            try
            {
                var response = repoProduct.Update(entity);
                if (response == 1)
                {
                    var responseProductCategories = repoProductCategory.GetAll(x => x.ProductID == entity.Id);
                    repoProductCategory.DeleteRange(responseProductCategories);
                    repoProductCategory.AddRange(productCategories);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}