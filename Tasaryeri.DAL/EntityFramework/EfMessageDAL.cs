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
        IRepository<Member> repoMember;
        IRepository<Message> repoMessage;
        IRepository<Product> repoProduct;
        public EfMessageDAL(IRepository<Saler> repoSaler, IRepository<Message> repoMessage, IRepository<Product> repoProduct, IRepository<Member> repoMember)
        {
            this.repoSaler = repoSaler;
            this.repoMessage = repoMessage;
            this.repoProduct = repoProduct;
            this.repoMember = repoMember;
        }

        public Member GetMember(int id)
        {
            try
            {
                return repoMember.GetBy(x => x.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Message> GetMessages(int salerId, int memberId, int productId)
        {
            try
            {
                return repoMessage.GetAll(x => x.MemberId == memberId && x.ProductId == productId && x.SalerId == salerId).OrderBy(x => x.Timestamp);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Message> GetOldMessagesForMember(int memberId)
        {
            try
            {
                var response = repoMessage.GetAll(m => m.MemberId == memberId).Include(x => x.Product).Include(x => x.Saler);
                var firstMessages = response
               .GroupBy(m => new { m.ProductId, m.SalerId })
               .Select(g => g.First()).ToList();

                return firstMessages;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Message> GetOldMessagesForSaler(int salerId)
        {
            try
            {
                var response = repoMessage.GetAll(x => x.SalerId == salerId).Include(x => x.Product).Include(x => x.Member);
                var firstMessages = response
                 .GroupBy(m => new { m.ProductId, m.MemberId })
              .Select(g => g.First()).ToList();
                return firstMessages;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Product GetProduct(int id)
        {
            try
            {
                return repoProduct.GetBy(x => x.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Saler GetSaler(int id)
        {
            try
            {
                return repoSaler.GetBy(x => x.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool SendMessage(Message message)
        {
            try
            {
                var response = repoMessage.Add(message);
                if (response == 1)
                    return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
