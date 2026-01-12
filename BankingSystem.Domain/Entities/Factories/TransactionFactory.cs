using BankingSystem.Domain.Enums;

namespace BankingSystem.Domain.Entities.Factories;

public static class TransactionFactory
{
    public static Transaction Deposit(Guid accountId, decimal amount)
        => new(accountId, null, amount, TransactionType.Deposit);

    public static Transaction Withdraw(Guid accountId, decimal amount)
        => new(accountId, null, amount, TransactionType.Withdraw);

    public static Transaction Transfer(Guid fromAccountId, Guid toAccountId, decimal amount)
        => new(fromAccountId, toAccountId, amount, TransactionType.Transfer);
}
