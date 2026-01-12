namespace BankingSystem.Shared.DTOs.Responses;

public class TransactionResponse
{
    public Guid Id { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public decimal Amount { get; set; }
    public Guid? TargetAccountId { get; set; }
    public DateTime CreatedAt { get; set; }
}
