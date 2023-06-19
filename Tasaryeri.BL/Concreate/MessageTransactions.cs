using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.DAL.Entities;
using Tasaryeri.DAL.EntityFramework.Abstract;

namespace Tasaryeri.BL.Concreate
{
    public class MessageTransactions : IMessageTransactions
    {
        IEfMessageDAL efMessageDAL;
        public MessageTransactions(IEfMessageDAL efMessageDAL)
        {
            this.efMessageDAL = efMessageDAL;
        }

        public IEnumerable<MessageDTO> GetMessages(int salerId, int memberId, int productId)
        {
            var response = efMessageDAL.GetMessages(salerId, memberId, productId);
            List<MessageDTO> messages = new List<MessageDTO>();
            foreach (var item in response)
            {
                MessageDTO messageDTO = new MessageDTO
                {
                    Content = item.Content,
                    Id = item.Id,
                    MemberId = memberId,
                    ProductId = productId,
                    SalerId = salerId,
                    Sender = item.Sender,
                    Timestamp = item.Timestamp,
                };
                messages.Add(messageDTO);
            }
            return messages;
        }

        public SalerDTO GetSaler(int id)
        {
            var saler = efMessageDAL.GetSaler(id);
            SalerDTO salerDTO = new SalerDTO
            {
                Id = saler.Id,
                Name = saler.Name,
                Surname = saler.Surname,
            };
            return salerDTO;
        }

        public bool SendMessage(MessageDTO messageDTO)
        {
            Message message = new Message
            {
                Content = messageDTO.Content,
                MemberId = messageDTO.MemberId,
                ProductId = messageDTO.ProductId,
                SalerId = messageDTO.SalerId,
                Timestamp = messageDTO.Timestamp,
                Sender = messageDTO.Sender,
            };
            return efMessageDAL.SendMessage(message);
        }
    }
}
