namespace BankingSystem.Shared.DTOs.Responses;

public class DepositResponse
{
    public Guid AccountId { get; set; }
    public decimal NewBalance { get; set; }
    public DateTime Timestamp { get; set; }
}
