using AutoMapper;
using Exam.App.Domain;
using Exam.App.Domain.Repositories;
using Exam.App.Services.Exceptions;
using Exam.App.Services.Dtos.AnimalSpeciesDto;
using Exam.App.Services.IServices;

namespace Exam.App.Services
{
    public class AnimalSpeciesService : IAnimalSpeciesService
    {
        private readonly IAnimalSpeciesRepository _animalSpeciesRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AnimalSpeciesService> _logger;

        public AnimalSpeciesService(IAnimalSpeciesRepository animalSpeciesRepository, IMapper mapper, ILogger<AnimalSpeciesService> logger)
        {
            _animalSpeciesRepository = animalSpeciesRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ResponseAnimalSpeciesDto>> GetAllAsync()
        {
            List<AnimalSpecies> species = await _animalSpeciesRepository.GetAllAsync();
            return species.Select(_mapper.Map<ResponseAnimalSpeciesDto>).ToList();
        }
        public async Task<ResponseAnimalSpeciesDto> GetByIdAsync(int id)
        {
            AnimalSpecies animalSpecies = await _animalSpeciesRepository.GetByIdAsync(id);
            if (animalSpecies == null)
            {
                throw new NotFoundException(id);
            }
            return _mapper.Map<ResponseAnimalSpeciesDto>(animalSpecies);
        }
    }
}
