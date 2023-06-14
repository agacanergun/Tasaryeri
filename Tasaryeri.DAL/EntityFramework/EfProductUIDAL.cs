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
        public EfProductUIDAL(IRepository<ProductCategory> repoProductCategory, IRepository<Product> repoProduct)
        {
            this.repoProductCategory = repoProductCategory;
            this.repoProduct = repoProduct;
        }
        public IEnumerable<Product> GetAll(int CategoryId)
        {
            List<Product> products = new List<Product>();
            var response = repoProductCategory.GetAll(x => x.CategoryID == CategoryId);
            foreach (var item in response)
            {
                var responseProduct = repoProduct.GetAll(x=>item.ProductID);
                Product product = new Product
                {

                };
            }
        }
    }
}
