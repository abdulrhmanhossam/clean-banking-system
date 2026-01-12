namespace BankingSystem.Shared.DTOs.Responses;

public class WithdrawResponse
{
    public Guid AccountId { get; set; }
    public decimal NewBalance { get; set; }
    public DateTime Timestamp { get; set; }
}
