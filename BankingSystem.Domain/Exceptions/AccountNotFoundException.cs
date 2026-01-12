namespace BankingSystem.Domain.Exceptions;

public class AccountNotFoundException : DomainException
{
    public AccountNotFoundException(Guid accountId)
        : base($"Account with id {accountId} was not found")
    {
    }
}
