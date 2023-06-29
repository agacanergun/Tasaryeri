using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.BL.Dtos;

namespace Tasaryeri.BL.Abstract
{
    public interface IAdminTransactions
    {
        AdminLoginDTO Login(AdminLoginDTO adminLoginDTO);
        IEnumerable<AdminDTO> GetAll();
        bool Delete(int id);
        bool Add(AdminDTO adminDTO);
        bool Update(AdminDTO adminDTO);
    }
}
