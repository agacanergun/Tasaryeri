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
        public EfProductDAL(IRepository<Product> repoProduct)
        {
            this.repoProduct = repoProduct;
        }
        public IEnumerable<Product> GetAll(int id)
        {
            return repoProduct.GetAll(x => x.SalerId == id).Include(x => x.ProductPictures);
        }
    }
}
