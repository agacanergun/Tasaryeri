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
    public class EfMessageDAL : IEfMessageDAL
    {
        IRepository<Saler> repoSaler;
        IRepository<Message> repoMessage;
        public EfMessageDAL(IRepository<Saler> repoSaler, IRepository<Message> repoMessage)
        {
            this.repoSaler = repoSaler;
            this.repoMessage = repoMessage;

        }

        public IEnumerable<Message> GetMessages(int salerId, int memberId, int productId)
        {
            return repoMessage.GetAll(x => x.MemberId == memberId && x.ProductId == productId && x.SalerId == salerId).OrderBy(x => x.Timestamp);
        }

        public Saler GetSaler(int id)
        {
            return repoSaler.GetBy(x => x.Id == id);
        }
    }
}
