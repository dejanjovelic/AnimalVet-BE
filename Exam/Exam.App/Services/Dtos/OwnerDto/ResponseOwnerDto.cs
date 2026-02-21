using Exam.App.Domain;
using Exam.App.Services.Dtos.UserDto;

namespace Exam.App.Services.Dtos.OwnerDto
{
    public class ResponseOwnerDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ProfileDto User { get; set; }
    }
}
