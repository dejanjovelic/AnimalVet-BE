using Exam.App.Domain;
using System.ComponentModel.DataAnnotations;

namespace Exam.App.Services.Dtos.PatientDto
{
    public class UpdatePatientDto
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public int AnimalSpeciesId { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
