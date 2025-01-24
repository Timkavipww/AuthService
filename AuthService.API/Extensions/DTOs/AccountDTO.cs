using AuthService.Domain.Entities;

namespace AuthService.API.Extensions.DTOs;

public static class AccountDTO
{
    public static Account toAccount(this LoginUserRequest loginUserRequest) {
        return new Account{
            FirstName = loginUserRequest.userName,
            PasswordHash = loginUserRequest.Password
        };
    }
}
