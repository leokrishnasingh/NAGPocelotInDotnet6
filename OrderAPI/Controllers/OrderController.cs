using Microsoft.AspNetCore.Mvc;
using OrderAPI.Models;
using OrderAPI.Repositories;

namespace OrderAPI.Controllers
{
    namespace OrderAPI.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class OrderController : ControllerBase
        {
            private readonly OrderRepository orderRepository;
            public OrderController()
            {
                orderRepository = new OrderRepository();
            }

            [HttpGet]
            public ActionResult<List<Order>> GetOrders()
            {
                var orders = orderRepository.GetOrders();
                return Ok(orders);
            }

            [HttpGet("{id}")]
            public ActionResult<Order> GetOrder(int id)
            {
                var order = orderRepository.GetOrderById(id);
                return Ok(order);
            }
        }
    }
}