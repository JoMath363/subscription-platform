using Api.Solution.Data;
using Api.Solution.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Solution.Services
{
    public class UserService
    {
        protected readonly AppDbContext _context;

        public UserService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
