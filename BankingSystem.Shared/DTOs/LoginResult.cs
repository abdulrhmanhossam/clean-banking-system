namespace BankingSystem.Shared.DTOs;

public class LoginResult
{
    public Guid UserId { get; set; }
    public string Token { get; set; }
    public string Role { get; set; }
}