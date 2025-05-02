using crud.Data;
using crud.DTOs;
using crud.Model;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{

    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context) { _context = context; }

        [HttpPost]
        public IActionResult Create(ProductDto productDto)
        {
            var product = new Product { Name = productDto.Name, Price = productDto.Price };
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Products.ToList());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductDto productDto)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            product.Name = productDto.Name;
            product.Price = productDto.Price;
            _context.SaveChanges();

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();

            return NoContent();
        }
    }
}