namespace AuthService.Domain.Entities;

public class Account
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;

}
