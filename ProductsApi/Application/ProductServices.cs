using ProductsApi.Domain.Products;
using ProductsApi.ViewModels;
using System.Text.Json;

namespace ProductsApi.Application
{
    public class ProductServices : IProductServices
    {
        private IProductRepository _repository;
        private ILogger<ProductServices> _logger;
        public ProductServices(IProductRepository repository, ILogger<ProductServices> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public ProductViewModel AddProduct(ProductViewModel product)
        {
            var productModel = new Product(product.Name, product.Quantity, product.Price, product.Description, product.Category);
            _repository.Add(productModel);
            _logger.LogDebug($"Product is added to the repository, Product => {JsonSerializer.Serialize(product)}");
            var returnProduct = _repository.Get(product.Id);
            var returnProductViewModel = new ProductViewModel()
            {
                Quantity = returnProduct.Quantity,
                Price = returnProduct.Price,
                Name = returnProduct.Name,
                Id = returnProduct.Id,
                Description = returnProduct.Description,
                Category = returnProduct.Category
            };
            return returnProductViewModel;
        }

        public Product AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {            
            var products = _repository.GetAll();
            _logger.LogDebug($"All products are returned");
            List<ProductViewModel> productsList = new();
            foreach (var product in products)
            {
                productsList.Add(new ProductViewModel()
                {
                    Category = product.Category,
                    Description = product.Description,
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity,
                });
            }
            return productsList;
        }        
    }
}
