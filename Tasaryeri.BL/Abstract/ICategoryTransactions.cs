using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.BL.Dtos;

namespace Tasaryeri.BL.Abstract
{
    public interface ICategoryTransactions
    {
        public bool Update(MainCategoryDTO dto);
        public bool Update(SubCategoryDTO dto);
        public bool Add(MainCategoryDTO dto);
        public bool Add(SubCategoryDTO dto);
        public bool Delete(MainCategoryDTO dto);
        public bool Delete(SubCategoryDTO dto);
    }
}
