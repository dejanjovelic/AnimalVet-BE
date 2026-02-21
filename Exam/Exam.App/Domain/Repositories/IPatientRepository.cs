using Exam.App.Domain;

namespace Exam.App.Domain.Repositories
{
    public interface IPatientRepository
    {
        Task<Patient> CreateAsync(Patient patient);
        Task DeleteAsync(Patient patient);
        Task<List<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(int id);
        Task<Patient> UpdateAsync(Patient patient);
    }
}