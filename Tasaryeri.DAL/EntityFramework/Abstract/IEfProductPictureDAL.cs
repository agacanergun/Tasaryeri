using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.DAL.Entities;

namespace Tasaryeri.DAL.EntityFramework.Abstract
{
    public interface IEfProductPictureDAL
    {
        bool Add(ProductPicture productPicture);
        bool Update(ProductPicture productPicture);
        bool Delete(ProductPicture productPicture);

        IEnumerable<ProductPicture> GetAll(int id);
        ProductPicture GetById(int id);
    }
}
