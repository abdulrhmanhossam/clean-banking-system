using BankingSystem.Application.Interfaces;

namespace BankingSystem.Application.Services;

public class DailyLimitResetService
{
    private readonly IUnitOfWork _unitOfWork;

    public DailyLimitResetService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Reset()
    {
        var accounts = _unitOfWork.Accounts.GetAll();

        foreach (var account in accounts)
        {
            account.ResetDailyLimits();
        }

        _unitOfWork.Commit();
    }
}
