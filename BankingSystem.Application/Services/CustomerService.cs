using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities;

namespace BankingSystem.Application.Services;

public class CustomerService
{
    private readonly IUnitOfWork _unitOfWork;

    public CustomerService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public Guid Create(string fullName)
    {
        var customer = new Customer(fullName);

        _unitOfWork.Customers.Add(customer);
        _unitOfWork.Commit();

        return customer.Id;
    }

    public Customer GetById(Guid id)
        => _unitOfWork.Customers.GetById(id);

    public IReadOnlyCollection<Customer> GetAll()
        => _unitOfWork.Customers.GetAll();

    public IReadOnlyCollection<Account> GetAccounts(Guid customerId)
    {
        _unitOfWork.Customers.GetById(customerId);

        return _unitOfWork.Accounts.GetByCustomerId(customerId);
    }
}
