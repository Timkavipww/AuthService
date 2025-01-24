using AuthService.Domain.Entities;

namespace AuthService.Domain.IRepositories;

public interface IAccountRepository
{
    void Add(Account account);
    Account? GetAccountByName(string userName);
}
