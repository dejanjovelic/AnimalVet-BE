using AutoMapper;
using Exam.App.Domain;
using Exam.App.Services.Dtos.OwnerDto;
using Exam.App.Services.Dtos.UserDto;

namespace Exam.App.Services.Mappers
{
    public class OwnerProfile : Profile
    {
        public OwnerProfile()
        {
            CreateMap<Owner, ResponseOwnerDto>()
                .ForMember(dest => dest.User,
                opt => opt.MapFrom(src => new ProfileDto
                {
                    Id = src.User.Id,
                    Name = src.User.Name,
                    Email = src.User.Email,
                    Surname = src.User.Surname,
                    Username = src.User.UserName
                })
                );
        }
    }
}
