using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasaryeri.DAL.Enums
{
    public enum EOrderStatus
    {
        Hazırlanıyor = 1,
        Paketlendi,
        KargoyaVerildi,
        TeslimEdildi,
        İptalEdildi,
    }
}
