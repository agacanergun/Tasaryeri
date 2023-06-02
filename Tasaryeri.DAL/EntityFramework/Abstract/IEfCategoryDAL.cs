using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.DAL.Entities;

namespace Tasaryeri.DAL.EntityFramework.Abstract
{
    public interface IEfCategoryDAL
    {
        IEnumerable<MainCategory> GetAllMainCategories();
        IEnumerable<SubCategory> GetAllSubCategories();
        bool Update(MainCategory entity);
        bool Update(SubCategory entity);
        bool Add(MainCategory entity);
        bool Add(SubCategory entity);
        bool Delete(MainCategory entity);
        bool Delete(SubCategory entity);
    }
}
