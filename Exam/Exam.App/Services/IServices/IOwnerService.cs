using Exam.App.Services.Dtos.OwnerDto;

namespace Exam.App.Services.IServices
{
    public interface IOwnerService
    {
        Task<List<ResponseOwnerDto>> GetAllAsync();
        Task<ResponseOwnerDto> GetByIdAsync(int id);
    }
}