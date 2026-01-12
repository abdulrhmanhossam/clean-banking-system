namespace BankingSystem.Shared.DTOs.Requests;

public class WithdrawRequest
{
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
}
