using AuthService.API.Extensions.DTOs;
using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;
using AuthService.Domain.IRepositories;

namespace AuthService.API.Services;

public class AccountService(IAccountRepository _accountRepository) : IAccountService
{
    public async Task Login(LoginUserRequest user)
    {
        _accountRepository.Add(user.toAccount());
    }

    public async Task Register(RegisterUserRequest user)
    {
        
    }

}
