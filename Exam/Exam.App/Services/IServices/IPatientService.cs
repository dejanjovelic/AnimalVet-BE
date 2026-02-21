using Exam.App.Domain;
using Exam.App.Services.Dtos.PatientDto;

namespace Exam.App.Services.IServices
{
    public interface IPatientService
    {
        Task<ResponsePatientDto> CreateAsync(CreatePatientDto createPatient);
        Task DeleteAsync(int id);
        Task<List<ResponsePatientDto>> GetAllAsync();
        Task<ResponsePatientDto> GetByIdAsync(int id);
        Task<ResponsePatientDto> UpdateAsync(int id, UpdatePatientDto patientDto);
    }
}