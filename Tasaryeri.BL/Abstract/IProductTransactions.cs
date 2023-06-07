using Tasaryeri.BL.Dtos;

namespace Tasaryeri.BL.Abstract
{
    public interface IProductTransactions
    {
        IEnumerable<ProductDTO> GetAll(int id);
    }
}
