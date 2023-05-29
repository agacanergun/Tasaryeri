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
    public class EfAdminDAL : IEfAdminDAL
    {
        IRepository<Admin> repoAdmin;

        public EfAdminDAL(IRepository<Admin> repoAdmin)
        {
            this.repoAdmin = repoAdmin;
        }

        //kayıtlı admin varsa gelir yoksa null
        public Admin AdminLogin(Admin admin)
        {
            var response = repoAdmin.GetBy(x => x.UserName == admin.UserName && x.Password == admin.Password);
            return response;
        }

        //admin kaydetme başarılıysa true değilse false
        public bool AdminRegister(Admin admin)
        {
            var response = repoAdmin.Add(admin);
            if (response == 1)
                return true;
            return false;
        }

    }
}
