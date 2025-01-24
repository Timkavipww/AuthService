using AuthService.Domain.Entities;

namespace AuthService.Application.Interfaces;

public interface IAccountService
{
    Task Login(LoginUserRequest user);
    Task Register(RegisterUserRequest user);
}
