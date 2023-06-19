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
    public class EfMessageDAL : IEfMessageDAL
    {
        IRepository<Saler> repoSaler;
        public EfMessageDAL(IRepository<Saler> repoSaler)
        {
            this.repoSaler = repoSaler;
        }
        public Saler GetSaler(int id)
        {
            return repoSaler.GetBy(x => x.Id == id);
        }
    }
}
