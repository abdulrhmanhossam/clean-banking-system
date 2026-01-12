using BankingSystem.Domain.Entities;

namespace BankingSystem.Application.Interfaces;

public interface ITransactionRepository
{
    void Add(Transaction transaction);
    IReadOnlyCollection<Transaction> GetByAccountId(Guid accountId);
}
