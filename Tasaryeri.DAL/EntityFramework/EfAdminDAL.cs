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
            try
            {
                var response = repoAdmin.GetBy(x => x.UserName == admin.UserName && x.Password == admin.Password);
                if (response == null)
                {
                    Admin badResponse = new Admin();
                    badResponse.ID = 0;
                    return badResponse;
                }
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Admin admin)
        {
            try
            {
                var response = repoAdmin.Update(admin);
                if (response == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Admin entity)
        {
            try
            {
                var response = repoAdmin.Delete(entity);
                if (response == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Admin> GetAll()
        {
            try
            {
                return repoAdmin.GetAll();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Add(Admin entity)
        {
            try
            {
                var response = repoAdmin.Add(entity);
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
