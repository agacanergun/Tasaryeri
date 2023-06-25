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
    public class EfProductUIDAL : IEfProductUIDAL
    {
        IRepository<ProductCategory> repoProductCategory;
        IRepository<Product> repoProduct;
        IRepository<ProductPicture> repoProductPicture;
        public EfProductUIDAL(IRepository<ProductCategory> repoProductCategory, IRepository<Product> repoProduct, IRepository<ProductPicture> repoProductPicture)
        {
            this.repoProductCategory = repoProductCategory;
            this.repoProduct = repoProduct;
            this.repoProductPicture = repoProductPicture;
        }
        public IEnumerable<Product> GetAll(int CategoryId)
        {
            try
            {
                List<Product> products = new List<Product>();
                var response = repoProductCategory.GetAll(x => x.CategoryID == CategoryId);
                foreach (var item in response)
                {
                    var responseProduct = repoProduct.GetBy(x => x.Id == item.ProductID);
                    var responseProductPictures = repoProductPicture.GetAll(x => x.ProductID == item.ProductID).ToList();
                    Product product = new Product
                    {
                        Id = responseProduct.Id,
                        Description = responseProduct.Description,
                        Detail = responseProduct.Detail,
                        Name = responseProduct.Name,
                        Price = responseProduct.Price,
                        Stock = responseProduct.Stock,
                        SalerId = responseProduct.SalerId,
                        ProductPictures = responseProductPictures,
                    };
                    products.Add(product);
                }
                return products;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Product GetProduct(int id)
        {
            try
            {
                var response = repoProduct.GetAll(x => x.Id == id).Include(x => x.ProductPictures);
                Product product = new Product();
                foreach (var item in response)
                {
                    product.Id = item.Id;
                    product.Name = item.Name;
                    product.Description = item.Description;
                    product.Detail = item.Detail;
                    product.Price = item.Price;
                    product.Stock = item.Stock;
                    product.SalerId = item.SalerId;
                    product.ProductPictures = item.ProductPictures;
                }
                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Product> GetRandom()
        {
            try
            {
                List<Product> products = new List<Product>();
                var response = repoProduct.GetAll().Include(x => x.ProductPictures).OrderBy(o => Guid.NewGuid()).Take(42);
                foreach (var item in response)
                {
                    Product product = new Product
                    {
                        Id = item.Id,
                        Description = item.Description,
                        Detail = item.Detail,
                        Name = item.Name,
                        Price = item.Price,
                        SalerId = item.SalerId,
                        Stock = item.Stock,
                        ProductPictures = item.ProductPictures,
                    };
                    products.Add(product);
                }
                return products;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
