using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Entities.Factories;
using BankingSystem.Shared.DTOs.Responses;

namespace BankingSystem.Application.Services;

public class AccountService
{
    private readonly IUnitOfWork _unitOfWork;

    public AccountService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public AccountResponse CreateAccount(Guid customerId)
    {
        var account = new Account(customerId);
        _unitOfWork.Accounts.Add(account);
        _unitOfWork.Commit();

        return new AccountResponse
        {
            AccountId = account.Id,
            CustomerId = account.CustomerId,
            Balance = account.Balance,
        };
    }

    public DepositResponse Deposit(Guid accountId, decimal amount)
    {
        var account = _unitOfWork.Accounts.GetById(accountId);

        account.Deposit(amount);
        _unitOfWork.Accounts.Update(account);

        _unitOfWork.Transactions.Add(
            TransactionFactory.Deposit(accountId, amount)
        );

        _unitOfWork.Commit();

        return new DepositResponse
        {
            AccountId = account.Id,
            NewBalance = account.Balance,
            Timestamp = DateTime.UtcNow
        };
    }

    public WithdrawResponse Withdraw(Guid accountId, decimal amount)
    {
        var account = _unitOfWork.Accounts.GetById(accountId);

        account.Withdraw(amount);
        _unitOfWork.Accounts.Update(account);

        _unitOfWork.Transactions.Add(
            TransactionFactory.Withdraw(accountId, amount)
        );

        _unitOfWork.Commit();

        return new WithdrawResponse
        {
            AccountId = account.Id,
            NewBalance = account.Balance,
            Timestamp = DateTime.UtcNow
        };
    }

    public IReadOnlyCollection<Account> GetAll()
    {
        return _unitOfWork.Accounts.GetAll();
    }

    public AccountDetailsResponse GetById(Guid accountId)
    {
        var account = _unitOfWork.Accounts.GetById(accountId);

        return new AccountDetailsResponse
        {
            AccountId = account.Id,
            CustomerId = account.CustomerId,
            Balance = account.Balance,
        };
    }

    public void Suspend(Guid accountId)
    {
        var account = _unitOfWork.Accounts.GetById(accountId);
        account.Suspend();
        _unitOfWork.Commit();
    }

    public void Activate(Guid accountId)
    {
        var account = _unitOfWork.Accounts.GetById(accountId);
        account.Activate();
        _unitOfWork.Commit();
    }

}
