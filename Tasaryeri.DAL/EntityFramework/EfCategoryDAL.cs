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
            try
            {
                var response = repoMainCategory.Add(entity);
                if (response == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Add(SubCategory entity)
        {
            try
            {
                var response = repoSubCategory.Add(entity);
                if (response == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(MainCategory entity)
        {
            try
            {
                var response = repoMainCategory.Delete(entity);
                if (response == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(SubCategory entity)
        {
            try
            {
                var response = repoSubCategory.Delete(entity);
                if (response == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<MainCategory> GetAllMainCategories()
        {
            try
            {
                return repoMainCategory.GetAll().OrderBy(x => x.DisplayIndex).Include(x => x.subCategories).OrderBy(x => x.DisplayIndex);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<SubCategory> GetAllSubCategories()
        {
            try
            {
                return repoSubCategory.GetAll().OrderBy(x => x.DisplayIndex).Include(x => x.MainCategory).OrderBy(x => x.MainCategory.Name);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(MainCategory entity)
        {
            try
            {
                var respone = repoMainCategory.Update(entity);
                if (respone == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(SubCategory entity)
        {
            try
            {
                var respone = repoSubCategory.Update(entity);
                if (respone == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
