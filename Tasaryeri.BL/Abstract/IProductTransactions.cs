using Tasaryeri.BL.Dtos;

namespace Tasaryeri.BL.Abstract
{
    public interface IProductTransactions
    {
        IEnumerable<ProductDTO> GetAll(int id);
        bool Delete(int id);
        bool Add(ProductDTO productDTO);
        bool Update(ProductDTO productDTO);
    }
}
