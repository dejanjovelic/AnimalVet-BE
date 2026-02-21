using Exam.App.Domain;
using Exam.App.Services.Dtos.OwnerDto;

namespace Exam.App.Services.Dtos.PatientDto
{
    public class ResponsePatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AnimalSpeciesId { get; set; }
        public AnimalSpecies? AnimalSpecies { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int OwnerId { get; set; }
        public ResponseOwnerDto? Owner { get; set; }
    }
}
