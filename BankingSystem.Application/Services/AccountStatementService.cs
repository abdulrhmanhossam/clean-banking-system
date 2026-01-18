using BankingSystem.Application.Interfaces;
using BankingSystem.Shared.DTOs.Requests;
using BankingSystem.Shared.DTOs.Responses;
using Microsoft.EntityFrameworkCore;


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
        var account = _unitOfWork.Accounts.GetById(accountId);

        var query = _unitOfWork.Transactions
            .QueryByAccountId(accountId);

        if (from.HasValue)
            query = query.Where(t => t.CreatedAt >= from.Value);

        if (to.HasValue)
            query = query.Where(t => t.CreatedAt <= to.Value);

        query = request.Descending
            ? query.OrderByDescending(t => EF.Property<object>(t, request.SortBy))
            : query.OrderBy(t => EF.Property<object>(t, request.SortBy));

        var totalCount = query.Count();

        var items = query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(t => new AccountStatementItem
            {
                TransactionId = t.Id,
                Type = t.Type.ToString(),
                Status = t.Status.ToString(),
                Amount = t.Amount,
                CreatedAt = t.CreatedAt
            })
            .ToList();

        return new PagedResponse<AccountStatementItem>
        {
            Items = items,
            TotalCount = totalCount,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }
}
