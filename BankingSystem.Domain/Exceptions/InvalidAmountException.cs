namespace BankingSystem.Domain.Exceptions;

public class InvalidAmountException : DomainException
{
    public InvalidAmountException()
    : base("Amount must be greater than zero")
    {
    }
}
