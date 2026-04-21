using Api.Solution.Data;
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
    }
}
