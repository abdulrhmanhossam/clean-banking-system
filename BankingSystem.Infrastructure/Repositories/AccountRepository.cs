using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Exceptions;
using BankingSystem.Infrastructure.Persistence;

namespace BankingSystem.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly BankingDbContext _context;

    public AccountRepository(BankingDbContext context)
    {
        _context = context;
    }

    public void Add(Account account) => _context.Accounts.Add(account);

    public Account GetById(Guid id)
    {
        var account = _context.Accounts.SingleOrDefault(a => a.Id == id)
            ?? throw new AccountNotFoundException(id);

        return account;
    }

    public IReadOnlyCollection<Account> GetAll()
        => _context.Accounts.ToList().AsReadOnly();

    public void Update(Account account)
        => _context.Accounts.Update(account);

    public IReadOnlyCollection<Account> GetByCustomerId(Guid customerId)
        => _context.Accounts
        .Where(a => a.CustomerId == customerId)
        .ToList()
        .AsReadOnly();
}
