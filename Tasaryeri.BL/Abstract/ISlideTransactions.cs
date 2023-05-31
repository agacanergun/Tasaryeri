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
        public IEnumerable<SlideDTO> GetAll();
        public bool Delete(int id);
        public bool Add(SlideDTO slideDTO);
        public bool Update(SlideDTO slideDTO);
    }
}
