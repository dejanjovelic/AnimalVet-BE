using Exam.App.Domain;
using Exam.App.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Exam.App.Infrastructure.Database.Repositories
{
    public class AnimalSpeciesRepository : IAnimalSpeciesRepository
    {
        private readonly AppDbContext _context;

        public AnimalSpeciesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AnimalSpecies>> GetAllAsync()
        {
            return await _context.AnimalSpecies
                .ToListAsync();
        }

        public async Task<AnimalSpecies> GetByIdAsync(int id)
        {
            return await _context.AnimalSpecies
                .FirstOrDefaultAsync(o => o.Id == id);
        }
    }
}
