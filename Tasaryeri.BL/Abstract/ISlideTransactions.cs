using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.BL.Dtos;

namespace Tasaryeri.BL.Abstract
{
    public interface ISlideTransactions
    {
        IEnumerable<SlideDTO> GetAll();
        bool Delete(SlideDTO slideDTO);
        bool Add(SlideDTO slideDTO);
        bool Update(SlideDTO slideDTO);
    }
}
