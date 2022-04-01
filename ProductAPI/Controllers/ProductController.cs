using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Repositories;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository productRepository;
        public ProductController()
        {
            productRepository = new ProductRepository();
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            var products = productRepository.GetProducts();
            return Ok(products);
        }

        [HttpGet("id")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = productRepository.GetProductById(id);
            return Ok(product);
        }

    }
}