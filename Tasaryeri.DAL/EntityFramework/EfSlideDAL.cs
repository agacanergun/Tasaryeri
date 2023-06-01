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
            var response = repoSlide.Add(entity);
            if (response == 1)
                return true;
            return false;
        }

        public Admin AdminLogin(Slide admin)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Slide entity)
        {
            var response = repoSlide.Delete(entity);
            if (response == 1)
                return true;
            return false;
        }

        public IEnumerable<Slide> GetAll()
        {
            return repoSlide.GetAll().OrderBy(x => x.DisplayIndex);
        }

        public bool Update(Slide admin)
        {
            var response = repoSlide.Update(admin);
            if (response == 1)
                return true;
            return false;
        }
    }
}
