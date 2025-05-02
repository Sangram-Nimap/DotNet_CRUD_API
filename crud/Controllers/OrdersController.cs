using crud.Data;
using crud.DTOs;
using crud.Model;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context) { _context = context; }

        [HttpPost]
        public IActionResult PlaceOrder(OrderDto orderDto)
        {
            var order = new Order { UserId = orderDto.UserId, OrderDate = DateTime.UtcNow };
            _context.Orders.Add(order);
            _context.SaveChanges();
            return Ok(order);
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Orders.ToList());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null) return NotFound();
            return Ok(order);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, OrderDto orderDto)
        {
            var order = _context.Orders.Find(id);
            if (order == null) return NotFound();

            order.UserId = orderDto.UserId;
            _context.SaveChanges();

            return Ok(order);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null) return NotFound();

            _context.Orders.Remove(order);
            _context.SaveChanges();

            return NoContent();
        }
    }

}
