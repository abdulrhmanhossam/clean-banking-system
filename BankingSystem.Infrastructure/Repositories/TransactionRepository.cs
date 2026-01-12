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
}
