using ProductAPI.Models;

namespace ProductAPI.Repositories
{
    public class ProductRepository
    {
        private readonly List<Product> products;

        public ProductRepository()
        {
            products = new List<Product>
            {
                new Product{Id=1,Name="Mobile",Price=16000},
                new Product{Id=2,Name="Laptop",Price=35000},
                new Product{Id=3,Name="Headphone",Price=2000}
            };
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(product => product.Id==id);
        }
    }
}