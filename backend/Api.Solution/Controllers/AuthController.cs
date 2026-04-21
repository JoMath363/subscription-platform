using Api.Solution.Data;
using Api.Solution.Models;
using Api.Solution.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Solution.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        // The DI container automatically provides the instance here
        public AuthController(AppDbContext context)
        {
            _context = context;
        }


        //[HttpPost("/register")]
        //public async Task<IActionResult> Register([FromBody] AuthDto dto)
        //{
        //    User newUser = new User() { 
        //        Name = dto.Name,
        //        Password = dto.Password,
        //    };

        //    await _context.Users.AddAsync(newUser);

        //    await _context.SaveChangesAsync();

        //    return Ok(newUser);
        //}

        //[HttpGet("/users")]
        //public async Task<IActionResult> GetAll()
        //{
        //    List<User> usersList = await _context.Users.ToListAsync();

        //    return Ok(usersList);
        //}
    }
}
