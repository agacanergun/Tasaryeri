using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.Core.Helpers;
using Tasaryeri.DAL.Entities;
using Tasaryeri.DAL.EntityFramework.Abstract;

namespace Tasaryeri.BL.Concreate
{
    public class AdminTransactions : IAdminTransactions
    {
        IEfAdminDAL efAdminDal;
        public AdminTransactions(IEfAdminDAL efAdminDal)
        {
            this.efAdminDal = efAdminDal;
        }

        //admin paneline giriş yaparken md5 formatlama ve giriş için veritabanı kontrolü
        public bool Login(AdminLoginDTO adminLoginDTO)
        {
            CryptoBase b = new CryptoBase();
            adminLoginDTO.Password = b.getMD5(adminLoginDTO.Password);
            Admin admin = new Admin
            {
                UserName = adminLoginDTO.UserName,
                Password = adminLoginDTO.Password,
            };
            return efAdminDal.AdminLogin(admin);
        }

        //admin panelinden admin kayıt etme işlemi
        public bool Register(AdminDTO dto)
        {
            CryptoBase b = new CryptoBase();
            dto.Password = b.getMD5(dto.Password);

            Admin admin = new Admin
            {
                ID = dto.ID,
                Name = dto.Name,
                Password = dto.Password,
                Surname = dto.Surname,
                UserName = dto.UserName
            };

            return efAdminDal.AdminRegister(admin);
        }
    }
}
