using ProductsApi.ViewModels;

namespace ProductsApi.Application
{
    public interface IProductServices
    {
        IEnumerable<ProductViewModel> GetProducts();
        ProductViewModel AddProduct(ProductViewModel product);
    }
}
