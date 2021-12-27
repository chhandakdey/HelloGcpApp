using ProductApp.Models;

namespace ProductApp.Services
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductViewModel>> GetProductsAsync();
    }
}
