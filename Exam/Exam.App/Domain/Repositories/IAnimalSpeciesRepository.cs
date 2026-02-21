using Exam.App.Domain;

namespace Exam.App.Domain.Repositories
{
    public interface IAnimalSpeciesRepository
    {
        Task<List<AnimalSpecies>> GetAllAsync();
        Task<AnimalSpecies> GetByIdAsync(int id);
    }
}