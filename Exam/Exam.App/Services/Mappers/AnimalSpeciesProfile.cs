using AutoMapper;
using Exam.App.Domain;
using Exam.App.Services.Dtos.AnimalSpeciesDto;

namespace Exam.App.Services.Mappers
{
    public class AnimalSpeciesProfile : Profile
    {
        protected AnimalSpeciesProfile()
        {
            CreateMap<AnimalSpecies, ResponseAnimalSpeciesDto>();
        }
    }
}
