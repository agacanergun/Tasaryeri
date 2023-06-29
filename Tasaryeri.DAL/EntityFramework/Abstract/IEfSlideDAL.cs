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
       IEnumerable<Slide> GetAll();
       bool Delete(Slide entity);
       bool Add(Slide entity);
       bool Update(Slide admin);
    }
}
