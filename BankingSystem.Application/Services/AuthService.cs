using BankingSystem.Application.Interfaces;
using BankingSystem.Shared.DTOs;

namespace BankingSystem.Application.Services;

public class AuthService
{
    private readonly IUserRepository _users;
    private readonly IJwtTokenGenerator _tokenGenerator;

    public AuthService(
        IUserRepository users,
        IJwtTokenGenerator tokenGenerator)
    {
        _users = users;
        _tokenGenerator = tokenGenerator;
    }

    public LoginResult Login(string email, string password)
    {
        var user = _users.GetByEmail(email);

        if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            throw new InvalidOperationException("Invalid credentials");

        var token = _tokenGenerator.Generate(user);

        return new LoginResult
        {
            UserId = user.Id,
            Token = token,
            Role = user.Role.ToString()
        };
    }
}