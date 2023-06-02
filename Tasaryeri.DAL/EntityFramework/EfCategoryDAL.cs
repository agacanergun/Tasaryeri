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
    public class EfCategoryDAL : IEfCategoryDAL
    {
        IRepository<MainCategory> repoMainCategory;
        IRepository<SubCategory> repoSubCategory;
        public EfCategoryDAL(IRepository<MainCategory> repoMainCategory, IRepository<SubCategory> repoSubCategory)
        {
            this.repoMainCategory = repoMainCategory;
            this.repoSubCategory = repoSubCategory;
        }
        public bool Add(MainCategory entity)
        {
            throw new NotImplementedException();
        }

        public bool Add(SubCategory entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(MainCategory entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(SubCategory entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MainCategory> GetAllMainCategories()
        {
            return repoMainCategory.GetAll().OrderBy(x=>x.DisplayIndex).Include(x => x.subCategories).OrderBy(x=>x.DisplayIndex);
        }

        public IEnumerable<SubCategory> GetAllSubCategories()
        {
            return repoSubCategory.GetAll().OrderBy(x => x.DisplayIndex).Include(x=>x.MainCategory).OrderBy(x => x.DisplayIndex);
        }

        public bool Update(MainCategory entity)
        {
            throw new NotImplementedException();
        }

        public bool Update(SubCategory entity)
        {
            throw new NotImplementedException();
        }
    }
}
