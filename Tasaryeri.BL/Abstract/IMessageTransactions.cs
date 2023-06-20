using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.BL.Dtos;

namespace Tasaryeri.BL.Abstract
{
    public interface IMessageTransactions
    {
        SalerDTO GetSaler(int id);
        IEnumerable<MessageDTO> GetMessages(int salerId, int memberId, int productId);
        bool SendMessage(MessageDTO messageDTO);
        ProductDTO GetProduct(int id);
        IEnumerable<MessageDTO> GetOldMessagesForMember(int memberId);
        IEnumerable<MessageDTO> GetOldMessagesForSaler(int salerId);
    }
}
