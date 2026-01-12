namespace BankingSystem.Shared.DTOs.Responses;

public class AccountDetailsResponse
{
    public Guid AccountId { get; set; }
    public Guid CustomerId { get; set; }
    public decimal Balance { get; set; }
}
