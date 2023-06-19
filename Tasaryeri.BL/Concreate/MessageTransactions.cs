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
    public class MessageTransactions : IMessageTransactions
    {
        IEfMessageDAL efMessageDAL;
        public MessageTransactions(IEfMessageDAL efMessageDAL)
        {
            this.efMessageDAL = efMessageDAL;
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
    }
}
