using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            try
            {
                MainCategory mainCategory = new MainCategory
                {
                    Name = dto.Name,
                    DisplayIndex = dto.DisplayIndex,
                };

                return efCategoryDAL.Add(mainCategory);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Add(SubCategoryDTO dto)
        {
            try
            {
                SubCategory subCategory = new SubCategory
                {
                    Name = dto.Name,
                    DisplayIndex = dto.DisplayIndex,
                    MainCategoryId = dto.MainCategoryId,
                };
                return efCategoryDAL.Add(subCategory);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(MainCategoryDTO dto)
        {
            try
            {
                MainCategory mainCategory = new MainCategory
                {
                    Id = dto.Id,
                };
                return efCategoryDAL.Delete(mainCategory);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(SubCategoryDTO dto)
        {
            try
            {
                SubCategory subCategory = new SubCategory
                {
                    Id = dto.Id,
                };
                return efCategoryDAL.Delete(subCategory);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<MainCategoryDTO> GetAllMainCategories()
        {
            try
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
                    };
                    mainCategoryDTOs.Add(mainCategoryDTO);
                }
                return mainCategoryDTOs;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<SubCategoryDTO> GetAllSubCategories()
        {
            try
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
                        MainCategoryId = item.MainCategoryId,
                        MainCategoryDTO = new MainCategoryDTO()
                        {
                            Id = item.MainCategory.Id,
                            DisplayIndex = item.MainCategory.DisplayIndex,
                            Name = item.MainCategory.Name,
                        },
                    };
                    subCategoryDTOs.Add(subCategoryDTO);
                }
                return subCategoryDTOs;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(MainCategoryDTO dto)
        {
            try
            {
                MainCategory mainCategory = new MainCategory
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    DisplayIndex = dto.DisplayIndex,
                };
                return efCategoryDAL.Update(mainCategory);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(SubCategoryDTO dto)
        {
            try
            {
                SubCategory subCategory = new SubCategory
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    DisplayIndex = dto.DisplayIndex,
                    MainCategoryId = dto.MainCategoryId,
                };
                return efCategoryDAL.Update(subCategory);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
