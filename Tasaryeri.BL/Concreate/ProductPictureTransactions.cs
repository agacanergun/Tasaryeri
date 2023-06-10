using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.DAL.EntityFramework.Abstract;

namespace Tasaryeri.BL.Concreate
{
    public class ProductPictureTransactions : IProductPictureTransactions
    {
        IEfProductPictureDAL efProductPictureDAL;
        public ProductPictureTransactions(IEfProductPictureDAL efProductPictureDAL)
        {
            this.efProductPictureDAL = efProductPictureDAL;
        }
        public bool Add(ProductPictureDTO productPictureDTO)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductPictureDTO> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public ProductPictureDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ProductPictureDTO productPictureDTO)
        {
            throw new NotImplementedException();
        }
    }
}
