using BankingSystem.Application.Interfaces;
using BankingSystem.Shared.DTOs.Requests;
using BankingSystem.Shared.DTOs.Responses;


namespace BankingSystem.Application.Services;

public class AccountStatementService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITransactionReadRepository _readRepo;

    public AccountStatementService(IUnitOfWork unitOfWork, ITransactionReadRepository readRepo)
    {
        _unitOfWork = unitOfWork;
        _readRepo = readRepo;
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
                Type = t.Type.ToString(),
                Status = t.Status.ToString(),
                Amount = t.Amount,
                CreatedAt = t.CreatedAt
            })
        };
    }

    public PagedResponse<AccountStatementItem> GetStatementPaged(
        Guid accountId,
        DateTime? from,
        DateTime? to,
        PagedRequest request)
    {
        _unitOfWork.Accounts.GetById(accountId);

        return _readRepo.GetPaged(accountId, from, to, request);
    }
}
