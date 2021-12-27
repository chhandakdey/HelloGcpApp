namespace ProductsApi.Domain.Products
{
    public class Product
    {
        public Product(string name, int quantity, decimal price, string description, string category)
        {
            Id = Guid.NewGuid();
            Name = name;
            if (RuleForQuantity(quantity))
                Quantity = quantity;
            else 
                throw new ArgumentException("Quantity should be greater than 0");
            if (RuleForPrice(price))
                Price = price;
            else
                throw new ArgumentException("Price should be greater than 0 and less than equals to 100");            
            Description = description;
            if (RuleForCategory(category))
                Category = category;
            else
                throw new ArgumentException("Category should be either Mobile or TV");            
        }        

        private static bool RuleForQuantity(int quantity)
        {
            return (quantity > 0);
        }

        private static bool RuleForPrice(decimal price)
        {
            return (price > 0 && price <= 100);
        }

        private static bool RuleForCategory(string category)
        {
            return category != null && (category == "Mobile" || category == "TV");
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public string Description { get; private set; }
        public string Category { get; private set; }        
    }
}
