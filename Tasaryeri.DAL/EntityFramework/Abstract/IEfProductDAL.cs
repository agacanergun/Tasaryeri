using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.DAL.Entities;

namespace Tasaryeri.DAL.EntityFramework.Abstract
{
    public interface IEfProductDAL
    {
        IEnumerable<Product> GetAll(int id);
        bool Delete(Product entity);
        bool Add(Product entity, int[] CategoriyIDs);
        bool Update(Product entity, List<ProductCategory> productCategories);
        Product GetById(int id);
        IEnumerable<SubCategory> GetSubCategories();
    }
}
