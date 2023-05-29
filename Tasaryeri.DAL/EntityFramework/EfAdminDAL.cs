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

        //kayıtlı admin varsa true yoksa false
        public bool AdminLogin(Admin admin)
        {
            var response = repoAdmin.GetAll(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (response.Any())
                return true;
            return false;
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
