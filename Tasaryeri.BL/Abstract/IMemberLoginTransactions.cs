using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.BL.Dtos;

namespace Tasaryeri.BL.Abstract
{
    public interface IMemberLoginTransactions
    {
        MemberLoginDTO Login(MemberLoginDTO memberLoginDTO);
        bool Register(MemberLoginDTO memberLoginDTO);
    }
}
