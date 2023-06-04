using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.BL.Abstract;
using Tasaryeri.DAL.EntityFramework.Abstract;

namespace Tasaryeri.BL.Concreate
{
    public class FooterTransactions : IFooterTransactions
    {
        IEfFooterDAL efFooterDAL;
        public FooterTransactions(IEfFooterDAL efFooterDAL)
        {
            this.efFooterDAL = efFooterDAL;
        }
    }
}
