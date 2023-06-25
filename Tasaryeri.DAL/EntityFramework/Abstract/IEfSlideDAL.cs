using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.DAL.Entities;

namespace Tasaryeri.DAL.EntityFramework.Abstract
{
    public interface IEfSlideDAL
    {
        public IEnumerable<Slide> GetAll();
        public bool Delete(Slide entity);
        public bool Add(Slide entity);
        public bool Update(Slide admin);
    }
}
