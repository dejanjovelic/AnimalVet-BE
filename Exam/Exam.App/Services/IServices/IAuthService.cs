using System.Security.Claims;
using Exam.App.Services.Dtos.UserDto;

namespace Exam.App.Services.IServices;

public interface IAuthService
{
    Task Register(RegistrationDto data);
    Task<string> Login(LoginDto data);
    Task<ProfileDto> GetProfile(ClaimsPrincipal userPrincipal);
}