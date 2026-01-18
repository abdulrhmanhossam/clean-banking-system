using BankingSystem.Domain.Enums;

namespace BankingSystem.Shared.DTOs.Responses;

public class AccountStatementResponse
{
    public Guid AccountId { get; set; }
    public decimal CurrentBalance { get; set; }
    public IEnumerable<AccountStatementItem> Transactions { get; set; } = [];

}

public class AccountStatementItem
{
    public Guid TransactionId { get; set; }
    public string Type { get; set; }
    public string Status { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
}