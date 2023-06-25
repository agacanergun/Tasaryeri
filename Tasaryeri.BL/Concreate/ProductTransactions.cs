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
    public class ProductTransactions : IProductTransactions
    {
        IEfProductDAL efProductDAL;
        public ProductTransactions(IEfProductDAL efProductDAL)
        {
            this.efProductDAL = efProductDAL;
        }

        public bool Add(ProductDTO productDTO)
        {
            try
            {
                Product product = new Product
                {
                    Name = productDTO.Name,
                    Description = productDTO.Description,
                    Detail = productDTO.Detail,
                    Price = productDTO.Price,
                    Stock = productDTO.Stock,
                    SalerId = productDTO.SalerId,
                };
                return efProductDAL.Add(product, productDTO.CategoriyIDs);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                Product product = new Product
                {
                    Id = id
                };
                return efProductDAL.Delete(product);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool Update(ProductDTO productDTO)
        {
            try
            {
                Product product = new Product
                {
                    Id = productDTO.Id,
                    Name = productDTO.Name,
                    Description = productDTO.Description,
                    Detail = productDTO.Detail,
                    Price = productDTO.Price,
                    Stock = productDTO.Stock,
                    SalerId = productDTO.SalerId,

                };
                List<ProductCategory> productCategories = new List<ProductCategory>();

                foreach (var item in productDTO.CategoriyIDs)
                {
                    ProductCategory productCategory = new ProductCategory
                    {
                        ProductID = productDTO.Id,
                        CategoryID = item,
                    };
                    productCategories.Add(productCategory);
                }

                return efProductDAL.Update(product, productCategories);
            }
            catch (Exception)
            {

                throw;
            }
        }


        public IEnumerable<ProductDTO> GetAll(int id)
        {
            try
            {
                var response = efProductDAL.GetAll(id);
                List<ProductDTO> result = new List<ProductDTO>();
                foreach (var item in response)
                {
                    ProductDTO productDTO = new ProductDTO
                    {
                        Description = item.Description,
                        Detail = item.Detail,
                        Id = item.Id,
                        Name = item.Name,
                        Price = item.Price,
                        saler = item.saler,
                        SalerId = item.SalerId,
                        Stock = item.Stock,
                        ProductPictures = item.ProductPictures,
                        ProductCategories = item.ProductCategories,
                    };
                    result.Add(productDTO);
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ProductDTO GetById(int id)
        {
            try
            {
                var response = efProductDAL.GetById(id);
                ProductDTO productDTO = new ProductDTO
                {
                    Id = id,
                    Description = response.Description,
                    Detail = response.Detail,
                    Name = response.Name,
                    Price = response.Price,
                    SalerId = response.SalerId,
                    Stock = response.Stock,
                    ProductPictures = response.ProductPictures,
                    saler = response.saler,
                };
                return productDTO;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<SubCategoryDTO> GetSubCategories()
        {
            try
            {
                var response = efProductDAL.GetSubCategories();
                List<SubCategoryDTO> subCategoryDTOs = new List<SubCategoryDTO>();
                foreach (var item in response)
                {
                    SubCategoryDTO subCategoryDTO = new SubCategoryDTO
                    {
                        Id = item.Id,
                        Name = item.Name,
                        DisplayIndex = item.DisplayIndex,
                        MainCategoryId = item.MainCategoryId,
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
    }
}
