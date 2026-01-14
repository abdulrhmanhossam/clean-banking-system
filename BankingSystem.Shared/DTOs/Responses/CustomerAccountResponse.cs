using BankingSystem.Domain.Enums;

namespace BankingSystem.Shared.DTOs.Responses;

public class CustomerAccountResponse
{
    public Guid AccountId { get; set; }
    public decimal Balance { get; set; }
    public AccountStatus Status { get; set; }
}
