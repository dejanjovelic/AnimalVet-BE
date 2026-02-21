using AutoMapper;
using Exam.App.Domain;
using Exam.App.Domain.Repositories;
using Exam.App.Services.Dtos.OwnerDto;
using Exam.App.Services.Dtos.AnimalSpeciesDto;
using Exam.App.Services.Exceptions;
using Exam.App.Services.IServices;

namespace Exam.App.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<AnimalSpeciesService> _logger;

        public OwnerService(
            IOwnerRepository ownerRepository,
            IMapper mapper,
            ILogger<AnimalSpeciesService> logger
            )
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ResponseOwnerDto>> GetAllAsync()
        {
            List<Owner> owners = await _ownerRepository.GetAllAsync();
            return owners.Select(_mapper.Map<ResponseOwnerDto>).ToList();
        }
        public async Task<ResponseOwnerDto> GetByIdAsync(int id)
        {
            Owner owner = await _ownerRepository.GetByIdAsync(id);
            if (owner == null)
            {
                throw new NotFoundException(id);
            }
            return _mapper.Map<ResponseOwnerDto>(owner);
        }
    }
}
