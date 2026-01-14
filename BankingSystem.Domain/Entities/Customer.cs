namespace BankingSystem.Domain.Entities;

public class Customer
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; }

    private Customer() { }

    public Customer(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new InvalidOperationException("Customer name is required");

        Id = Guid.NewGuid();
        FullName = fullName;
    }

    public void UpdateName(string fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new InvalidOperationException("Customer name is required");

        FullName = fullName;
    }
}
