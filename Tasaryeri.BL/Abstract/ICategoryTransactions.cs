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
       IEnumerable<MainCategoryDTO> GetAllMainCategories();
       IEnumerable<SubCategoryDTO> GetAllSubCategories();
       bool Update(MainCategoryDTO dto);
       bool Update(SubCategoryDTO dto);
       bool Add(MainCategoryDTO dto);
       bool Add(SubCategoryDTO dto);
       bool Delete(MainCategoryDTO dto);
       bool Delete(SubCategoryDTO dto);
    }
}
