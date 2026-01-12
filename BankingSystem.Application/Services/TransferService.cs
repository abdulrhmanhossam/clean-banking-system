using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities.Factories;
using BankingSystem.Shared.DTOs.Responses;

namespace BankingSystem.Application.Services;

public class TransferService
{
    private readonly IUnitOfWork _unitOfWork;

    public TransferService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public TransferResponse Transfer(Guid fromAccountId, Guid toAccountId, decimal amount)
    {
        var from = _unitOfWork.Accounts.GetById(fromAccountId);
        var to = _unitOfWork.Accounts.GetById(toAccountId);

        from.Transfer(amount);
        to.Deposit(amount);

        _unitOfWork.Transactions.Add(
            TransactionFactory.Transfer(fromAccountId, toAccountId, amount)
        );

        _unitOfWork.Commit();

        return new TransferResponse
        {
            FromAccountId = fromAccountId,
            ToAccountId = toAccountId,
            Amount = amount,
            FromAccountBalance = from.Balance,
            ToAccountBalance = to.Balance,
            Timestamp = DateTime.UtcNow
        };
    }
}
