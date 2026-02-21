using Exam.App.Domain;
using System.ComponentModel.DataAnnotations;

namespace Exam.App.Services.Dtos.PatientDto
{
    public class CreatePatientDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int AnimalSpeciesId { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public int OwnerId { get; set; }
    }
}
