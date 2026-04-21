using Api.Solution.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Solution.Data
{
    public class UnityOfWork
    {
        protected readonly AppDbContext _context;

        public UnityOfWork(AppDbContext context) 
        {
            _context = context;
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
