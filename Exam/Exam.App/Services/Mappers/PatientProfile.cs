using AutoMapper;
using Exam.App.Domain;
using Exam.App.Services.Dtos.PatientDto;
using Exam.App.Services.Dtos.UserDto;

namespace Exam.App.Services.Mappers
{
    public class PatientProfile : Profile
    {
        public PatientProfile() 
        {
            CreateMap<Patient, ResponsePatientDto>();
            CreateMap<CreatePatientDto, Patient>();
        }
    }
}
