using Microsoft.IdentityModel.Tokens;
using PaymentDetails.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PaymentDetails.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        User? ValidateUser(string username, string password);
    }
    public class JwtService : IJwtService   
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        public JwtService(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // validate user using DbContext
        public User? ValidateUser(string username, string password)
        {
            // example (you should hash password)
            return _context.User.FirstOrDefault(u => u.Email == username && u.PasswordHash == password);
        }

        // generate JWT token
        public string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, user.PasswordHash)
        };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
