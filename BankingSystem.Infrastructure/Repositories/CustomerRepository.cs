using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities;
using BankingSystem.Infrastructure.Persistence;

namespace BankingSystem.Infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly BankingDbContext _context;

    public CustomerRepository(BankingDbContext context)
    {
        _context = context;
    }

    public void Add(Customer customer)
        => _context.Customers.Add(customer);

    public IReadOnlyCollection<Customer> GetAll()
        => _context.Customers.ToList().AsReadOnly();

    public Customer GetById(Guid id)
        => _context.Customers.Single(c => c.Id == id);
}
