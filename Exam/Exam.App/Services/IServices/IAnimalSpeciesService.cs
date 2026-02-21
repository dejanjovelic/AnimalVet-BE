using Exam.App.Services.Dtos.AnimalSpeciesDto;

namespace Exam.App.Services.IServices
{
    public interface IAnimalSpeciesService
    {
        Task<List<ResponseAnimalSpeciesDto>> GetAllAsync();
        Task<ResponseAnimalSpeciesDto> GetByIdAsync(int id);
    }
}