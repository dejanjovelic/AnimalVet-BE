using AutoMapper;
using Exam.App.Domain;
using Exam.App.Domain.Repositories;
using Exam.App.Services.Dtos.PatientDto;
using Exam.App.Services.Exceptions;
using Exam.App.Services.IServices;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Exam.App.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PatientService> _logger;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IAnimalSpeciesRepository _animalSpeciesRepository;

        public PatientService(
            IPatientRepository patientRepository,
            IMapper mapper,
            ILogger<PatientService> logger,
            IOwnerRepository ownerRepository,
            IAnimalSpeciesRepository animalSpeciesRepository
            )
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
            _logger = logger;
            _ownerRepository = ownerRepository;
            _animalSpeciesRepository = animalSpeciesRepository;
        }

        public async Task<List<ResponsePatientDto>> GetAllAsync()
        {
            _logger.LogInformation($"Fetching all patients data.");
            List<Patient> patients = await _patientRepository.GetAllAsync();
            return patients.Select(_mapper.Map<ResponsePatientDto>).ToList();
        }
        public async Task<ResponsePatientDto> GetByIdAsync(int id)
        {
            _logger.LogInformation($"Fetching data from patient with id: {id}.");
            Patient patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null)
            {
                throw new NotFoundException(id);
            }
            return _mapper.Map<ResponsePatientDto>(patient);
        }
        public async Task<ResponsePatientDto> CreateAsync(CreatePatientDto createPatient)
        {
            _logger.LogInformation($"Creating new patient with name: {createPatient.Name}.");
            Owner owner = await _ownerRepository.GetByIdAsync(createPatient.OwnerId);

            if (owner == null)
            {
                throw new NotFoundException(createPatient.OwnerId);
            }

            AnimalSpecies animalSpecies = await _animalSpeciesRepository.GetByIdAsync(createPatient.AnimalSpeciesId);
            if (animalSpecies == null)
            {
                throw new NotFoundException(createPatient.AnimalSpeciesId);
            }

            Patient patient = _mapper.Map<Patient>(createPatient);
            patient.Owner = owner;
            patient.AnimalSpecies = animalSpecies;

            patient = await _patientRepository.CreateAsync(patient);
            return _mapper.Map<ResponsePatientDto>(patient);
        }
        public async Task<ResponsePatientDto> UpdateAsync(int id, UpdatePatientDto patientDto)
        {
            _logger.LogInformation($"Updating patient with ID: {id}");
            if (patientDto.Id != id)
            {
                throw new BadRequestException($"Patient ID mismatch: route ID {id} vs body ID {patientDto.Id}");
            }

            Patient existingPatient = await _patientRepository.GetByIdAsync(patientDto.Id);
            if (existingPatient == null)
            {
                throw new NotFoundException(patientDto.Id);
            }

            AnimalSpecies animalSpecies = await _animalSpeciesRepository.GetByIdAsync(patientDto.AnimalSpeciesId);
            if (animalSpecies == null)
            {
                throw new NotFoundException(patientDto.AnimalSpeciesId);
            }

            existingPatient.Name = patientDto.Name;
            existingPatient.AnimalSpeciesId = patientDto.AnimalSpeciesId;
            existingPatient.DateOfBirth = patientDto.DateOfBirth;
            existingPatient.AnimalSpecies = animalSpecies;

            existingPatient = await _patientRepository.UpdateAsync(existingPatient);

            return _mapper.Map<ResponsePatientDto>(existingPatient);
        }

        public async Task DeleteAsync(int id)
        {
            _logger.LogInformation($"Deleting patient with id: {id}.");
            Patient patient = await _patientRepository.GetByIdAsync(id);
            if (patient == null)
            {
                throw new NotFoundException(id);
            }
            await _patientRepository.DeleteAsync(patient);
        }
    }
}
