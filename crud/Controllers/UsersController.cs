using Microsoft.AspNetCore.Mvc;
using crud.Data;
using crud.Model;
using crud.DTOs;
using crud.Data;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context) { _context = context; }

    [HttpPost]
    public IActionResult Create(UserDto userDto)
    {
        var user = new User { Name = userDto.Name, Email = userDto.Email };
        _context.Users.Add(user);
        _context.SaveChanges();
        return Ok(user);
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_context.Users.ToList());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UserDto userDto)
    {
        var user = _context.Users.Find(id);
        if (user == null) return NotFound();

        user.Name = userDto.Name;
        user.Email = userDto.Email;
        _context.SaveChanges();

        return Ok(user);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) return NotFound();

        _context.Users.Remove(user);
        _context.SaveChanges();

        return NoContent();
    }
}