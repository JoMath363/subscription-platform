using Api.Solution.Data;
using Api.Solution.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Solution.Services
{
    public class ProjectService
    {
        protected readonly AppDbContext _context;

        public ProjectService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<Project> CreateAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            return project;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(Guid id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<Project> UpdateAsync(Project project)
        {
            _context.Projects.Update(project);
            return project;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
                return false;

            _context.Projects.Remove(entity);
            return true;
        }
    }
}
