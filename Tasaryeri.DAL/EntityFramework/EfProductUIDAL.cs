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

        public IEnumerable<Product> GetRandom()
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
    }
}
