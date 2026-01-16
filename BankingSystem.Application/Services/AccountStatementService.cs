using BankingSystem.Application.Interfaces;
using BankingSystem.Shared.DTOs.Responses;

namespace BankingSystem.Application.Services;

public class AccountStatementService
{
    private readonly IUnitOfWork _unitOfWork;

    public AccountStatementService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public AccountStatementResponse GetStatement(
       Guid accountId,
       DateTime? from,
       DateTime? to)
    {
        var account = _unitOfWork.Accounts.GetById(accountId);

        var transactions = _unitOfWork.Transactions
            .GetByAccountId(accountId, from, to);

        return new AccountStatementResponse
        {
            AccountId = account.Id,
            CurrentBalance = account.Balance,
            Transactions = transactions.Select(t => new AccountStatementItem
            {
                TransactionId = t.Id,
                Type = t.Type,
                Amount = t.Amount,
                CreatedAt = t.CreatedAt
            })
        };
    }
}
