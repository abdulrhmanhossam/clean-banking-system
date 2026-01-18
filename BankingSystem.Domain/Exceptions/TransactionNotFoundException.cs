namespace BankingSystem.Domain.Exceptions;

public class TransactionNotFoundException : DomainException
{
    public TransactionNotFoundException(Guid transactionId)
        : base($"Transaction with id {transactionId} was not found")
    {
    }
}