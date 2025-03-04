using AuthService.Domain.Entities;
using AuthService.Domain.IRepositories;

namespace AuthService.Persistense;

public class AccountRepository : IAccountRepository
{
    public static IDictionary<string,Account> Accounts = new Dictionary<string,Account>();
    public void Add(Account account)
    {
        Accounts[account.UserName] = account;
    }

    public Account? GetAccountByName(string userName)
    {
        return Accounts.TryGetValue(userName, out var account) ? account : null;
    }

}
