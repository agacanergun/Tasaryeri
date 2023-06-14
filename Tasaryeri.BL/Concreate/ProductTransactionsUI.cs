using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.DAL.EntityFramework.Abstract;

namespace Tasaryeri.BL.Concreate
{
    public class ProductTransactionsUI : IProductTransactionsUI
    {
        IEfProductUIDAL efProductUIDAL;
        public ProductTransactionsUI(IEfProductUIDAL efProductUIDAL)
        {
            this.efProductUIDAL = efProductUIDAL;
        }
        public IEnumerable<ProductDTO> GetAll(int CategoryId)
        {
            throw new NotImplementedException();
        }
    }
}
