using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.BL.Dtos;

namespace Tasaryeri.BL.Abstract
{
    public interface IProductPictureTransactions
    {
        bool Add(ProductPictureDTO productPictureDTO);
        bool Update(ProductPictureDTO productPictureDTO);
        bool Delete(int id);

        IEnumerable<ProductPictureDTO> GetAll(int id);
        ProductPictureDTO GetById(int id);
    }
}
