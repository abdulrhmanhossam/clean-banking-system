namespace BankingSystem.Application.Interfaces;

public interface IUnitOfWork
{
    IAccountRepository Accounts { get; }
    ITransactionRepository Transactions { get; }
    ICustomerRepository Customers { get; }
    void Commit();
}
