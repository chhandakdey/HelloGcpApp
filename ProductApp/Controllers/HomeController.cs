using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;
using ProductApp.Services;
using System.Diagnostics;

namespace ProductApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices _productServices;

        public HomeController(ILogger<HomeController> logger, IProductServices productServices)
        {
            _logger = logger;
            _productServices = productServices;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productServices.GetProductsAsync();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}