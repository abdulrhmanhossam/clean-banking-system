using BankingSystem.Domain.Enums;

namespace BankingSystem.Domain.Entities;

public class User
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; private set; }
    public UserRole Role { get; private set; }

    private User() { }

    public User(string email, string passwordHash, UserRole role)
    {
        Id = Guid.NewGuid();
        Email = email;
        PasswordHash = passwordHash;
        Role = role;
    }

    public bool IsAdmin() => Role == UserRole.Admin;
}