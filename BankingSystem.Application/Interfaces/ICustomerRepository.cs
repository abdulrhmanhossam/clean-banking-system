using BankingSystem.Domain.Entities;

namespace BankingSystem.Application.Interfaces;

public interface ICustomerRepository
{
    void Add(Customer customer);
    Customer GetById(Guid id);
    IReadOnlyCollection<Customer> GetAll();
}
