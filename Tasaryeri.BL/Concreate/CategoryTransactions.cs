﻿using System;
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
            MainCategory mainCategory = new MainCategory
            {
                Name = dto.Name,
                DisplayIndex = dto.DisplayIndex,
            };

            return efCategoryDAL.Add(mainCategory);
        }

        public bool Add(SubCategoryDTO dto)
        {
            SubCategory subCategory = new SubCategory
            {
                Name = dto.Name,
                DisplayIndex = dto.DisplayIndex,
                MainCategoryId = dto.MainCategoryId,
            };
            return efCategoryDAL.Add(subCategory);
        }

        public bool Delete(MainCategoryDTO dto)
        {
            MainCategory mainCategory = new MainCategory
            {
                Id = dto.Id,
            };
            return efCategoryDAL.Delete(mainCategory);
        }

        public bool Delete(SubCategoryDTO dto)
        {
            SubCategory subCategory = new SubCategory
            {
                Id = dto.Id,
            };
            return efCategoryDAL.Delete(subCategory);
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

        public bool Update(MainCategoryDTO dto)
        {
            MainCategory mainCategory = new MainCategory
            {
                Id = dto.Id,
                Name = dto.Name,
                DisplayIndex = dto.DisplayIndex,
            };
            return efCategoryDAL.Update(mainCategory);
        }

        public bool Update(SubCategoryDTO dto)
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
    }
}
