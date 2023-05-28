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
    public class EfUsersDAL : IEfUsersDAL
    {
        IRepository<Admin> repoUsers;

        public EfUsersDAL(IRepository<Admin> repoUsers)
        {
            this.repoUsers = repoUsers;
        }

        public bool AdminRegister(Admin admin)
        {
            var x = repoUsers.Add(admin);
            if (x == 1)
                return true;
            return false;
        }

    }
}
