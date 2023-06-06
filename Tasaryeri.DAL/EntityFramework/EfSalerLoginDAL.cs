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
    public class EfSalerLoginDAL : IEfSalerLoginDAL
    {
        IRepository<Saler> repoSaler;
        public EfSalerLoginDAL(IRepository<Saler> repoSaler)
        {
            this.repoSaler = repoSaler;
        }
        public Saler SalerLogin(Saler saler)
        {
            var response = repoSaler.GetBy(x => x.Username == saler.Username && x.Password == saler.Password);
            if (response == null)
            {
                Saler badResponse = new Saler();
                badResponse.Id = 0;
                return badResponse;
            }
            return response;
        }


        public bool SalerRegister(Saler saler)
        {
            var CheckSaler = repoSaler.GetBy(x => x.Username == saler.Username || x.Email == saler.Email);
            if (CheckSaler != null)
            {
                return false;
            }
            var response = repoSaler.Add(saler);
            if (response == 1)
                return true;
            return false;
        }
    }
}
