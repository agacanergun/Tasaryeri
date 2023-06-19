using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        IRepository<Product> repoProduct;
        public EfMessageDAL(IRepository<Saler> repoSaler, IRepository<Message> repoMessage, IRepository<Product> repoProduct)
        {
            this.repoSaler = repoSaler;
            this.repoMessage = repoMessage;
            this.repoProduct = repoProduct;
        }

        public IEnumerable<Message> GetMessages(int salerId, int memberId, int productId)
        {
            return repoMessage.GetAll(x => x.MemberId == memberId && x.ProductId == productId && x.SalerId == salerId).OrderBy(x => x.Timestamp);
        }

        public IEnumerable<Message> GetOldMessages(int memberId)
        {
            var response = repoMessage.GetAll(m => m.MemberId == memberId).Include(x => x.Product).Include(x => x.Saler);
            var firstMessages = response
           .GroupBy(m => new { m.ProductId, m.SalerId })
           .Select(g => g.First()).ToList();

            return firstMessages;
        }

        public Product GetProduct(int id)
        {
            return repoProduct.GetBy(x => x.Id == id);
        }

        public Saler GetSaler(int id)
        {
            return repoSaler.GetBy(x => x.Id == id);
        }

        public bool SendMessage(Message message)
        {
            var response = repoMessage.Add(message);
            if (response == 1)
                return true;
            return false;
        }
    }
}
