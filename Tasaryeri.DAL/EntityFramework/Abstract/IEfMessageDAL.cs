﻿using System;
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
        Member GetMember(int id);
        IEnumerable<Message> GetMessages(int salerId, int memberId, int productId);
        bool SendMessage(Message message);
        Product GetProduct(int id);
        IEnumerable<Message> GetOldMessagesForMember(int memberId);
        IEnumerable<Message> GetOldMessagesForSaler(int salerId);
    }
}
