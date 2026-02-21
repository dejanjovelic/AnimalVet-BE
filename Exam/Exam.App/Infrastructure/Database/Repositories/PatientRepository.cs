using Exam.App.Domain;
using Exam.App.Domain.Repositories;
using Exam.App.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Exam.App.Infrastructure.Database.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _context.Patients
                .Include(p => p.Owner)
                .ThenInclude(o => o.User)
                .Include(p => p.AnimalSpecies)
                .ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _context.Patients
                  .Include(p => p.Owner)
                   .ThenInclude(o => o.User)
                  .Include(p => p.AnimalSpecies)
                  .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Patient> CreateAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> UpdateAsync(Patient patient)
        {
            _context.SaveChangesAsync();
            return patient;
        }

        public async Task DeleteAsync(Patient patient)
        {
            _context.Patients.Remove(patient);
            _context.SaveChangesAsync();
        }
    }
}
