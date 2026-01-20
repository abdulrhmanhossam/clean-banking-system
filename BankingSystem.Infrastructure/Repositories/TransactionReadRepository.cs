using BankingSystem.Application.Interfaces;
using BankingSystem.Infrastructure.Persistence;
using BankingSystem.Shared.DTOs.Requests;
using BankingSystem.Shared.DTOs.Responses;

namespace BankingSystem.Infrastructure.Repositories;

public class TransactionReadRepository : ITransactionReadRepository
{
    private readonly BankingDbContext _context;

    public TransactionReadRepository(BankingDbContext context)
    {
        _context = context;
    }

    public PagedResponse<AccountStatementItem> GetPaged(
        Guid accountId,
        DateTime? from,
        DateTime? to,
        PagedRequest request)
    {
        var query = _context.Transactions
            .Where(t => t.AccountId == accountId);

        if (from.HasValue)
            query = query.Where(t => t.CreatedAt >= from.Value);

        if (to.HasValue)
            query = query.Where(t => t.CreatedAt <= to.Value);

        query = request.SortBy switch
        {
            "CreatedAt" => request.Descending
                ? query.OrderByDescending(t => t.CreatedAt)
                : query.OrderBy(t => t.CreatedAt),

            "Amount" => request.Descending
                ? query.OrderByDescending(t => t.Amount)
                : query.OrderBy(t => t.Amount),

            _ => query.OrderByDescending(t => t.CreatedAt)
        };

        var total = query.Count();

        var items = query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(t => new AccountStatementItem
            {
                TransactionId = t.Id,
                Type = t.Type.ToString(),
                Amount = t.Amount,
                CreatedAt = t.CreatedAt
            })
            .ToList();

        return new PagedResponse<AccountStatementItem>
        {
            Items = items,
            TotalCount = total,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize
        };
    }
}
