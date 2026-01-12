namespace BankingSystem.Domain.Entities;

public class Customer
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; }

    public Customer(string fullName)
    {
        Id = Guid.NewGuid();
        FullName = fullName;
    }
}
