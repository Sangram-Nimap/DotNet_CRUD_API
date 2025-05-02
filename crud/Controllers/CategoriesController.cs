using crud.Data;
using crud.DTOs;
using crud.Model;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context) { _context = context; }

        [HttpPost]
        public IActionResult Create(CategoryDto categoryDto)
        {
            var category = new Category { Name = categoryDto.Name };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok(category);
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Categories.ToList());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, CategoryDto categoryDto)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            category.Name = categoryDto.Name;
            _context.SaveChanges();

            return Ok(category);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return NoContent();
        }
    }

}
