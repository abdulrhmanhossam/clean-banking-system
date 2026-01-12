using BankingSystem.Application.Interfaces;
using BankingSystem.Infrastructure.Persistence;

namespace BankingSystem.Infrastructure.UnitOfWork;

public class EfUnitOfWork : IUnitOfWork
{
    private readonly BankingDbContext _context;
    public IAccountRepository Accounts { get; }
    public ITransactionRepository Transactions { get; }

    public EfUnitOfWork(
        BankingDbContext context,
        IAccountRepository accounts,
        ITransactionRepository transactions)
    {
        _context = context;
        Accounts = accounts;
        Transactions = transactions;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }
}
