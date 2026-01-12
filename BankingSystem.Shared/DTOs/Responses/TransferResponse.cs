namespace BankingSystem.Shared.DTOs.Responses;

public class TransferResponse
{
    public Guid FromAccountId { get; set; }
    public Guid ToAccountId { get; set; }
    public decimal Amount { get; set; }
    public decimal FromAccountBalance { get; set; }
    public decimal ToAccountBalance { get; set; }
    public DateTime Timestamp { get; set; }
}
