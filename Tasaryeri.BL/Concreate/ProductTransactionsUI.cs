using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
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

        public IEnumerable<ProductDTO> GetRandom()
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
    }
}
