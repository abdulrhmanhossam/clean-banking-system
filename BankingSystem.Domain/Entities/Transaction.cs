using BankingSystem.Domain.Enums;

namespace BankingSystem.Domain.Entities;

public class Transaction
{
    public Guid Id { get; private set; }
    public Guid AccountId { get; private set; }
    public Guid? TargetAccountId { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public TransactionStatus Status { get; private set; }
    public TransactionType Type { get; private set; }
    public Guid? ReversedTransactionId { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    private Transaction() { }

    public Transaction(Guid accountId, Guid? targetAccountId, decimal amount, TransactionType type)
    {
        Id = Guid.NewGuid();
        AccountId = accountId;
        TargetAccountId = targetAccountId;
        Amount = amount;
        Type = type;
        Status = TransactionStatus.Pending;
        CreatedAt = DateTime.UtcNow;
        IsDeleted = false;
    }

    public void Completed()
    {
        Status = TransactionStatus.Completed;
    }

    public void Failed()
    {
        Status = TransactionStatus.Failed;
    }

    public void Reversed(Guid reversalTransactionId)
    {
        if (Status != TransactionStatus.Completed)
            throw new InvalidOperationException();

        Status = TransactionStatus.Reversed;
        ReversedTransactionId = reversalTransactionId;
    }

    public void Delete()
    {
        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
    }
}
