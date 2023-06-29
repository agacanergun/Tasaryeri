using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.DAL.Entities;

namespace Tasaryeri.DAL.EntityFramework.Abstract
{
    public interface IEfAdminDAL
    {
        Admin AdminLogin(Admin admin);
        IEnumerable<Admin> GetAll();
        bool Delete(Admin entity);
        bool Add(Admin entity);
        bool Update(Admin admin);
    }
}
