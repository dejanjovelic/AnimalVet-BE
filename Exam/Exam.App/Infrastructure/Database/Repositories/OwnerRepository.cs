using Exam.App.Domain;
using Exam.App.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Exam.App.Infrastructure.Database.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly AppDbContext _context;

        public OwnerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Owner>> GetAllAsync()
        {
            return await _context.Owners
                .Include(o => o.User)
                .ToListAsync();
        }

        public async Task<Owner> GetByIdAsync(int id)
        {
            return await _context.Owners
                .Include(o => o.User)
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
