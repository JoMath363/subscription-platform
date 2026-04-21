using Api.Solution.Data;
using Api.Solution.Models;
using Api.Solution.Models.DTOs;
using Api.Solution.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Solution.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UnityOfWork _unityOfWork;
        private readonly UserService _userService;
        private readonly AuthService _authService;

        public UserController(UnityOfWork unityOfWork, UserService userService, AuthService authService)
        {
            _unityOfWork = unityOfWork;
            _userService = userService;
            _authService = authService;
        }


        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] AuthDto dto)
        {
            User newUser = new User()
            {
                Email = dto.Email,
                PasswordHash = _authService.HashPassword(dto.Password)
            };

            await _userService.CreateAsync(newUser);

            await _unityOfWork.SaveChangesAsync();

            return Ok(newUser);
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] AuthDto dto)
        {
            var user = await _userService.GetByEmailAsync(dto.Email);

            if (user == null)
                return Unauthorized("No user found for this email.");

            if (!_authService.VerifyPassword(dto.Password, user.PasswordHash))
                return Unauthorized("Invalid password.");

            var token = _authService.GenerateToken(user);

            return Ok(new { token });
        }

        [HttpPost("/test")]
        [Authorize]
        public async Task<IActionResult> test([FromBody] AuthDto dto)
        {
            return Ok("You are logged in!");
        }
    }
}
