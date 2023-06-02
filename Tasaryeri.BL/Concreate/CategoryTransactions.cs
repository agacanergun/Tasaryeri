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
    public class CategoryTransactions : ICategoryTransactions
    {
        IEfCategoryDAL efCategoryDAL;
        public CategoryTransactions(IEfCategoryDAL efCategoryDAL)
        {
            this.efCategoryDAL = efCategoryDAL;
        }

        public bool Add(MainCategoryDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Add(SubCategoryDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(MainCategoryDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(SubCategoryDTO dto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MainCategoryDTO> GetAllMainCategories()
        {
            IEnumerable<MainCategory> mainCategories = efCategoryDAL.GetAllMainCategories();
            List<MainCategoryDTO> mainCategoryDTOs = new List<MainCategoryDTO>();
            foreach (var item in mainCategories)
            {
                MainCategoryDTO mainCategoryDTO = new MainCategoryDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    DisplayIndex = item.DisplayIndex,
                    subCategories = item.subCategories,
                };
                mainCategoryDTOs.Add(mainCategoryDTO);
            }
            return mainCategoryDTOs;
        }

        public IEnumerable<SubCategoryDTO> GetAllSubCategories()
        {
            IEnumerable<SubCategory> subCategories = efCategoryDAL.GetAllSubCategories();
            List<SubCategoryDTO> subCategoryDTOs = new List<SubCategoryDTO>();
            foreach (var item in subCategories)
            {
                SubCategoryDTO subCategoryDTO = new SubCategoryDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    DisplayIndex = item.DisplayIndex,
                    MainCategory = item.MainCategory,
                    MainCategoryId = item.MainCategoryId,
                };
                subCategoryDTOs.Add(subCategoryDTO);
            }
            return subCategoryDTOs;
        }

        public bool Update(MainCategoryDTO dto)
        {
            throw new NotImplementedException();
        }

        public bool Update(SubCategoryDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
