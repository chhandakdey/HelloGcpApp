using ProductsApi.Domain.Products;

namespace ProductsApi.Infra
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> _products;
        public ProductRepository()
        {
            _products = new List<Product>()
            {
                new Product("Samsung Mobile 1",10,90,"Samsung smart phone","Mobile"),
                new Product("Samsung Mobile 2",8,80,"Samsung smart phone","Mobile")
            };
        }
        public Product Add(Product product)
        {
            _products.Add(product);
            return product;
        }

        public Product Delete(Product product)
        {
            _products.Remove(product);
            return product;
        }

        public Product Get(Guid id)
        {
            return _products.Where(p => p.Id == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product Update(Product product)
        {
            _products.Remove(Get(product.Id));
            _products.Add(product);
            return product;
        }
    }
}
