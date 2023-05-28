using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.Core.Helpers;
using Tasaryeri.DAL.Entities;
using Tasaryeri.DAL.EntityFramework.Abstract;

namespace Tasaryeri.BL.Concreate
{
    public class AdminTransactions : IAdminTransactions
    {
        IEfUsersDAL efuserdal;
        public AdminTransactions(IEfUsersDAL efuserdal)
        {
            this.efuserdal = efuserdal;
        }

        public bool Register(AdminDTO dto)
        {
            CryptoBase b = new CryptoBase();
            dto.Password = b.getMD5(dto.Password);

            //entitye çevirdik
            Admin admin = new Admin
            {
                ID = dto.ID,
                Name = dto.Name,
                Password = dto.Password,
                Surname = dto.Surname,
                UserName = dto.UserName
            };
            //entityi gönderdik
            return efuserdal.AdminRegister(admin);
        }
    }
}
