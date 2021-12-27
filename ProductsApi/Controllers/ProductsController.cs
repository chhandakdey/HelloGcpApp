using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApi.Application;
using ProductsApi.Domain.Products;
using ProductsApi.ViewModels;

namespace ProductsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ILogger<ProductsController> _logger;
        private IProductServices _productServices;

        public ProductsController(ILogger<ProductsController> logger, IProductServices productServices)
        {
            _logger = logger;
            _productServices = productServices;
        }

        [HttpGet]        
        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            _logger.LogDebug("Get All Products");
            return _productServices.GetProducts();
        }
    }
}
