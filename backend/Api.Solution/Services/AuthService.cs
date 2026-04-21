using Api.Solution.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Solution.Services
{
    public class AuthService
    {
        private readonly IConfiguration _config;
        private readonly string _jwtSecretKey;
        private readonly string _jwtIssuer;
        private readonly string _jwtAudience;
        private readonly string _jwtExpiryMinutes;

        public AuthService(IConfiguration config)
        {
            _config = config;

            // Token Settings Values
            _jwtSecretKey = _config["JwtSettings:SecretKey"] ?? throw new Exception("Missing SecretKey in appsettings.json");
            _jwtIssuer = _config["JwtSettings:Issuer"] ?? throw new Exception("Missing Issuer in appsettings.json");
            _jwtAudience = _config["JwtSettings:Audience"] ?? throw new Exception("Missing Audienceis in appsettings.json");
            _jwtExpiryMinutes = _config["JwtSettings:ExpiryMinutes"] ?? throw new Exception("Missing ExpiryMinutes in appsettings.json");
        }

        public string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtIssuer,
                audience: _jwtAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(int.Parse(_jwtExpiryMinutes)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, storedHash);
        }
    }
}
