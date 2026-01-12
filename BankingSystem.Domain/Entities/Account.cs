using BankingSystem.Domain.Enums;
using BankingSystem.Domain.Exceptions;

namespace BankingSystem.Domain.Entities;

public class Account
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; }
    public decimal Balance { get; private set; }
    public AccountStatus Status { get; private set; }

    public decimal DailyWithdrawalLimit { get; private set; } = 10_000;
    public decimal DailyTransferLimit { get; private set; } = 20_000;

    private decimal _withdrawnToday;
    private decimal _transferredToday;

    private Account() { }

    public Account(Guid customerId)
    {
        if (customerId == Guid.Empty)
            throw new InvalidOperationException("CustomerId is required");

        Id = Guid.NewGuid();
        CustomerId = customerId;
        Balance = 0;
        Status = AccountStatus.Active;
    }

    public void Suspend()
    {
        Status = AccountStatus.Suspended;
    }

    public void Activate()
    {
        Status = AccountStatus.Active;
    }

    public void Deposit(decimal amount)
    {
        ValidateActive();
        ValidateAmount(amount);

        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        ValidateActive();
        ValidateAmount(amount);

        if (_withdrawnToday + amount > DailyWithdrawalLimit)
            throw new DailyLimitExceededException("Withdrawal");

        if (amount > Balance)
            throw new InsufficientBalanceException();

        Balance -= amount;
        _withdrawnToday += amount;
    }

    public void Transfer(decimal amount)
    {
        ValidateActive();
        ValidateAmount(amount);

        if (_transferredToday + amount > DailyTransferLimit)
            throw new DailyLimitExceededException("Transfer");

        if (Balance < amount)
            throw new InsufficientBalanceException();

        Balance -= amount;
        _transferredToday += amount;
    }

    public void ResetDailyLimits()
    {
        _withdrawnToday = 0;
        _transferredToday = 0;
    }

    private void ValidateActive()
    {
        if (Status != AccountStatus.Active)
            throw new AccountSuspendedException();
    }

    private static void ValidateAmount(decimal amount)
    {
        if (amount <= 0)
            throw new InvalidAmountException();
    }
}
