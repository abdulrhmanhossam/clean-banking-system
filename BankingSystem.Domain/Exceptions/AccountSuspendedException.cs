namespace BankingSystem.Domain.Exceptions;

public class AccountSuspendedException : DomainException
{
    public AccountSuspendedException()
        : base("Account is suspended")
    {
    }
}
