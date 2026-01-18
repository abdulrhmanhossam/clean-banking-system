using BankingSystem.Application.Interfaces;

namespace BankingSystem.Application.Services;

public class TransactionAdminService
{
    private readonly IUnitOfWork _unitOfWork;

    public TransactionAdminService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void SoftDelete(Guid transactionId)
    {
        var transaction = _unitOfWork.Transactions.GetById(transactionId);

        transaction.Delete();

        _unitOfWork.Commit();
    }
}