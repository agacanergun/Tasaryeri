using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.DAL.Entities;

namespace Tasaryeri.DAL.EntityFramework.Abstract
{
    public interface IEfMessageDAL
    {
        Saler GetSaler(int id);
        IEnumerable<Message> GetMessages(int salerId, int memberId, int productId);
        bool SendMessage(Message message);
        Product GetProduct(int id);
    }
}
