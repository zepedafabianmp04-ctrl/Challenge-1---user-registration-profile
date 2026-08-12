using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductService.Database;
using ProductService.Models;
using Microsoft.AspNetCore.Identity;

namespace ProductService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UsersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var activeUsers = await _context.Users
            .Where(u => u.IsActive)
            .ToListAsync();

        return Ok(activeUsers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null || !user.IsActive)
        {
            return NotFound("Usuario no encontrado o inactivo.");
        }

        return Ok(user);
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser([FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        bool emailExists = await _context.Users.AnyAsync(u => u.Email.ToLower() == user.Email.ToLower());
        if (emailExists)
        {
            return BadRequest(new { message = "El correo electrónico ya está registrado." });
        }

        user.RegistrationDate = DateTime.UtcNow;
        user.IsActive = true;

        var passwordHasher = new PasswordHasher<User>();
        user.PasswordHash = passwordHasher.HashPassword(user, user.PasswordHash);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null || !user.IsActive)
        {
            return NotFound("El usuario no existe o ya ha sido desactivado.");
        }

        user.IsActive = false;

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}