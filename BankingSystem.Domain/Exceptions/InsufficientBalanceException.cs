namespace BankingSystem.Domain.Exceptions;

public class InsufficientBalanceException : DomainException
{
    public InsufficientBalanceException()
        : base("Insufficient balance")
    {
    }
}
