using BankingSystem.Domain.Entities;

namespace BankingSystem.Application.Interfaces;

public interface IAccountRepository
{
    Account GetById(Guid id);
    void Add(Account account);
    void Update(Account account);
    IReadOnlyCollection<Account> GetAll();
}
