using Azure;
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
    public class EfSlideDAL : IEfSlideDAL
    {
        IRepository<Slide> repoSlide;
        public EfSlideDAL(IRepository<Slide> repoSlide)
        {
            this.repoSlide = repoSlide;
        }
        public bool Add(Slide entity)
        {
            try
            {
                var response = repoSlide.Add(entity);
                if (response == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Slide entity)
        {
            try
            {
                var response = repoSlide.Delete(entity);
                if (response == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Slide> GetAll()
        {
            try
            {
                return repoSlide.GetAll().OrderBy(x => x.DisplayIndex);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Slide admin)
        {
            try
            {
                var response = repoSlide.Update(admin);
                if (response == 1)
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
