using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.Core.Abstract;
using Tasaryeri.DAL.EntityFramework.Abstract;

namespace Tasaryeri.BL.Concreate
{
    public class ProductTransactionsUI : IProductTransactionsUI
    {
        IEfProductUIDAL efProductUIDAL;
        public ProductTransactionsUI(IEfProductUIDAL efProductUIDAL)
        {
            this.efProductUIDAL = efProductUIDAL;
        }
        public IEnumerable<ProductDTO> GetAll(int CategoryId)
        {
            try
            {
                var response = efProductUIDAL.GetAll(CategoryId);
                List<ProductDTO> result = new List<ProductDTO>();

                foreach (var item in response)
                {
                    ProductDTO productDTO = new ProductDTO
                    {
                        Id = item.Id,
                        Description = item.Description,
                        Detail = item.Detail,
                        Name = item.Name,
                        Price = item.Price,
                        Stock = item.Stock,
                        SalerId = item.SalerId,
                        ProductPictures = item.ProductPictures,
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

        public ProductDTO GetProduct(int id)
        {
            try
            {
                var response = efProductUIDAL.GetProduct(id);
                ProductDTO productDTO = new ProductDTO
                {
                    Id = response.Id,
                    Description = response.Description,
                    Detail = response.Detail,
                    Name = response.Name,
                    Price = response.Price,
                    Stock = response.Stock,
                    SalerId = response.SalerId,
                    ProductPictures = response.ProductPictures,
                };
                return productDTO;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProductDTO> GetRandom()
        {
            try
            {
                var response = efProductUIDAL.GetRandom();
                List<ProductDTO> result = new List<ProductDTO>();

                foreach (var item in response)
                {
                    ProductDTO productDTO = new ProductDTO
                    {
                        Id = item.Id,
                        Description = item.Description,
                        Detail = item.Detail,
                        Name = item.Name,
                        Price = item.Price,
                        Stock = item.Stock,
                        SalerId = item.SalerId,
                        ProductPictures = item.ProductPictures,
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
    }
}
