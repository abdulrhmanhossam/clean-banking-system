using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities;
using BankingSystem.Infrastructure.Persistence;

namespace BankingSystem.Infrastructure.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly BankingDbContext _context;

    public TransactionRepository(BankingDbContext context)
    {
        _context = context;
    }

    public void Add(Transaction transaction)
        => _context.Transactions.Add(transaction);

    public IReadOnlyCollection<Transaction> GetByAccountId(Guid accountId)
        => _context.Transactions
            .Where(t => t.AccountId == accountId)
            .OrderByDescending(t => t.CreatedAt)
            .ToList()
            .AsReadOnly();

    public IReadOnlyCollection<Transaction> GetByAccountId(
        Guid accountId,
        DateTime? from,
        DateTime? to)
    {
        var query = _context.Transactions
            .Where(t => t.AccountId == accountId);

        if (from.HasValue)
            query = query.Where(t => t.CreatedAt >= from.Value);

        if (to.HasValue)
            query = query.Where(t => t.CreatedAt <= to.Value);

        return query
            .OrderByDescending(t => t.CreatedAt)
            .ToList();
    }

    public IQueryable<Transaction> QueryByAccountId(Guid accountId)
        => _context.Transactions
            .Where(t => t.AccountId == accountId);
}
