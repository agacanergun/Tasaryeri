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
    public class EfProductPictureDAL : IEfProductPictureDAL
    {
        IRepository<ProductPicture> repoProductPicture;
        public EfProductPictureDAL(IRepository<ProductPicture> repoProductPicture)
        {
            this.repoProductPicture = repoProductPicture;
        }
        public bool Add(ProductPicture productPicture)
        {
            var response = repoProductPicture.Add(productPicture);
            if (response == 1)
                return true;
            return false;
        }

        public bool Delete(ProductPicture productPicture)
        {
            var response = repoProductPicture.Delete(productPicture);
            if (response == 1)
                return true;
            return false;
        }

        public IEnumerable<ProductPicture> GetAll(int id)
        {
            return repoProductPicture.GetAll(x => x.ProductID == id);
        }

        public ProductPicture GetById(int id)
        {
            return repoProductPicture.GetBy(x => x.Id == id);
        }

        public bool Update(ProductPicture productPicture)
        {
            var response = repoProductPicture.Update(productPicture);
            if (response == 1)
                return true;
            return false;
        }
    }
}
