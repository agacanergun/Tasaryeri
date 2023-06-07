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
    public class ProductTransactions : IProductTransactions
    {
        IEfProductDAL efProductDAL;
        public ProductTransactions(IEfProductDAL efProductDAL)
        {
            this.efProductDAL = efProductDAL;
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
