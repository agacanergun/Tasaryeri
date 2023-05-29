using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
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
        public AdminLoginDTO Login(AdminLoginDTO adminLoginDTO)
        {
            CryptoBase b = new CryptoBase();
            adminLoginDTO.Password = b.getMD5(adminLoginDTO.Password);
            Admin admin = new Admin
            {
                UserName = adminLoginDTO.UserName,
                Password = adminLoginDTO.Password,
            };
            var response = efAdminDal.AdminLogin(admin);
            adminLoginDTO.Id = response.ID;
            adminLoginDTO.UserName = response.UserName;
            adminLoginDTO.Password = response.Password;
            return adminLoginDTO;
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
