namespace BankingSystem.Domain.Entities;

public class Transaction
{
    public Guid Id { get; private set; }
    public Guid AccountId { get; private set; }
    public Guid? TargetAccountId { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public string Type { get; private set; }

    private Transaction() { }

    public Transaction(Guid accountId, Guid? targetAccountId, decimal amount, string type)
    {
        Id = Guid.NewGuid();
        AccountId = accountId;
        TargetAccountId = targetAccountId;
        Amount = amount;
        Type = type;
        CreatedAt = DateTime.UtcNow;
    }
}
