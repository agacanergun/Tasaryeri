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
            Product product = new Product
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                Detail = productDTO.Detail,
                Price = productDTO.Price,
                Stock = productDTO.Stock,
                SalerId = productDTO.SalerId,
            };
            return efProductDAL.Add(product);
        }

        public bool Delete(int id)
        {
            Product product = new Product
            {
                Id = id
            };
            return efProductDAL.Delete(product);
        }


        public bool Update(ProductDTO productDTO)
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
            return efProductDAL.Update(product);
        }


        public IEnumerable<ProductDTO> GetAll(int id)
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
                };
                result.Add(productDTO);
            }
            return result;
        }


    }
}
