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
        public AdminLoginDTO Login(AdminLoginDTO adminLoginDTO);
        public IEnumerable<AdminDTO> GetAll();
        public bool Delete(int id);
        public bool Add(AdminDTO adminDTO);
        public bool Update(AdminDTO adminDTO);
    }
}
