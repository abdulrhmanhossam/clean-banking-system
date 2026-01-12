namespace BankingSystem.Domain.Exceptions;

public class DailyLimitExceededException : DomainException
{
    public DailyLimitExceededException(string limitType)
    : base($"{limitType} limit exceeded")
    {
    }
}
