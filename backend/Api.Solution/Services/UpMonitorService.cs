using Api.Solution.Data;
using Api.Solution.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Solution.Services
{
    public class UpMonitorService
    {
        protected readonly AppDbContext _context;

        public UpMonitorService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<UpMonitor> CreateAsync(UpMonitor monitor)
        {
            await _context.UpMonitors.AddAsync(monitor);
            return monitor;
        }

        public async Task<List<UpMonitor>> GetAllAsync()
        {
            return await _context.UpMonitors.ToListAsync();
        }

        public async Task<UpMonitor?> GetByIdAsync(Guid id)
        {
            return await _context.UpMonitors.FindAsync(id);
        }

        public async Task<UpMonitor> UpdateAsync(UpMonitor monitor)
        {
            _context.UpMonitors.Update(monitor);
            return monitor;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
                return false;

            _context.UpMonitors.Remove(entity);
            return true;
        }
    }
}
