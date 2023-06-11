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
    public class ProductPictureTransactions : IProductPictureTransactions
    {
        IEfProductPictureDAL efProductPictureDAL;
        public ProductPictureTransactions(IEfProductPictureDAL efProductPictureDAL)
        {
            this.efProductPictureDAL = efProductPictureDAL;
        }
        public bool Add(ProductPictureDTO productPictureDTO)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductPictureDTO> GetAll(int id)
        {
            var response = efProductPictureDAL.GetAll(id);
            List<ProductPictureDTO> productDTOs = new List<ProductPictureDTO>();
            foreach (var item in response)
            {
                ProductPictureDTO productPictureDTO = new ProductPictureDTO
                {
                    Id = item.Id,
                    DisplayIndex = item.DisplayIndex,
                    Name = item.Name,
                    Picture = item.Picture,
                    ProductID = item.ProductID,
                    Product = item.Product,
                };
                productDTOs.Add(productPictureDTO);
            }

            return productDTOs;
        }

        public ProductPictureDTO GetById(int id)
        {
            var response = efProductPictureDAL.GetById(id);
            ProductPictureDTO productPictureDTO = new ProductPictureDTO
            {
                Id = response.Id,
                DisplayIndex = response.DisplayIndex,
                Name = response.Name,
                Picture = response.Picture,
                Product = response.Product,
                ProductID = response.ProductID,
            };
            return productPictureDTO;
        }

        public bool Update(ProductPictureDTO productPictureDTO)
        {
            ProductPicture productPicture = new ProductPicture
            {
                ProductID = productPictureDTO.ProductID,
                Id = productPictureDTO.Id,
                DisplayIndex = productPictureDTO.DisplayIndex,
                Name = productPictureDTO.Name,
                Picture = productPictureDTO.Picture,
            };
            return efProductPictureDAL.Update(productPicture);
        }
    }
}
