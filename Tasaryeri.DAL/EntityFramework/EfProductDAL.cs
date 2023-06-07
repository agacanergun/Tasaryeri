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
        public EfProductDAL(IRepository<Product> repoProduct, IRepository<Saler> repoSaler)
        {
            this.repoProduct = repoProduct;
            this.repoSaler = repoSaler;
        }

        public bool Add(Product entity)
        {
            var response = repoProduct.Add(entity);
            if (response == 1)
                return true;
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
            var response = repoProduct.GetAll(x => x.SalerId == id).Include(x => x.ProductPictures);
            foreach (var item in response)
            {
                item.saler = saler;
            }
            return response;
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
