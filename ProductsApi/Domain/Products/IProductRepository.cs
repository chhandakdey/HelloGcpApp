namespace ProductsApi.Domain.Products
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product Get(Guid id);
        Product Add(Product product);
        Product Update(Product product);
        Product Delete(Product product);
    }
}
