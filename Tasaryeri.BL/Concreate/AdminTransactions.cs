using AutoMapper;
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
            if (response.ID != 0)
            {
                adminLoginDTO.Id = response.ID;
                adminLoginDTO.UserName = response.UserName;
                adminLoginDTO.Password = response.Password;
                return adminLoginDTO;
            }
            else
            {
                adminLoginDTO.Id = response.ID;
                return adminLoginDTO;
            }

        }

        public IEnumerable<AdminDTO> GetAll()
        {
            IEnumerable<Admin> admins = efAdminDal.GetAll();
            List<AdminDTO> adminDTOs = new List<AdminDTO>();

            foreach (Admin admin in admins)
            {
                AdminDTO adminDTO = new AdminDTO
                {
                    ID = admin.ID,
                    UserName = admin.UserName,
                    Password = admin.Password,
                    Name = admin.Name,
                    Surname = admin.Surname,
                };
                adminDTOs.Add(adminDTO);
            }
            return adminDTOs;
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

        public bool Delete(int id)
        {
            Admin adminDelete = new Admin
            {
                ID = id,
            };
            return efAdminDal.Delete(adminDelete);

        }

        public bool Add(AdminDTO adminDTO)
        {
            Admin admin = new Admin
            {
                Name = adminDTO.Name,
                Password = adminDTO.Password,
                Surname = adminDTO.Surname,
                UserName = adminDTO.UserName,
            };
            return efAdminDal.Add(admin);

        }
    }
}
