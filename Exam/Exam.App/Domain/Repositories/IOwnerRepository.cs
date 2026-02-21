using Exam.App.Domain;

namespace Exam.App.Domain.Repositories
{
    public interface IOwnerRepository
    {
        Task<List<Owner>> GetAllAsync();
        Task<Owner> GetByIdAsync(int id);
    }
}