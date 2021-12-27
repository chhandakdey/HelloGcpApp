using ProductApp.Models;

namespace ProductApp.Services
{
    public class ProductServices : IProductServices
    {
        private readonly HttpClient _httpClient;

        public ProductServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<ProductViewModel>>("/products");
        }
    }
}
