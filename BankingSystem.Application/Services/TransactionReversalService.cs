using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Entities;
using BankingSystem.Domain.Entities.Factories;
using BankingSystem.Domain.Enums;

namespace BankingSystem.Application.Services;

public class TransactionReversalService
{
    private readonly IUnitOfWork _unitOfWork;

    public TransactionReversalService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void Reverse(Guid transactionId)
    {
        var transaction = _unitOfWork.Transactions.GetById(transactionId);

        if (transaction.ReversedTransactionId != null)
            throw new InvalidOperationException("Transaction already reversed");

        switch (transaction.Type)
        {
            case TransactionType.Deposit:
                ReverseDeposit(transaction);
                break;

            case TransactionType.Withdraw:
                ReverseWithdraw(transaction);
                break;

            case TransactionType.Transfer:
                ReverseTransfer(transaction);
                break;

            default:
                throw new InvalidOperationException("Unsupported transaction type");
        }

        _unitOfWork.Commit();
    }

    private void ReverseDeposit(Transaction tx)
    {
        var account = _unitOfWork.Accounts.GetById(tx.AccountId);

        account.Withdraw(tx.Amount);

        var reversal = TransactionFactory.Withdraw(tx.AccountId, tx.Amount);
        _unitOfWork.Transactions.Add(reversal);

        tx.Reversed(reversal.Id);
    }

    private void ReverseWithdraw(Transaction tx)
    {
        var account = _unitOfWork.Accounts.GetById(tx.AccountId);

        account.Deposit(tx.Amount);

        var reversal = TransactionFactory.Deposit(tx.AccountId, tx.Amount);
        _unitOfWork.Transactions.Add(reversal);

        tx.Reversed(reversal.Id);
    }

    private void ReverseTransfer(Transaction tx)
    {
        var from = _unitOfWork.Accounts.GetById(tx.AccountId);
        var to = _unitOfWork.Accounts.GetById(tx.TargetAccountId!.Value);

        to.Transfer(tx.Amount);
        from.Deposit(tx.Amount);

        var reversal = TransactionFactory.Transfer(
            tx.TargetAccountId.Value,
            tx.AccountId,
            tx.Amount
        );

        _unitOfWork.Transactions.Add(reversal);
        tx.Reversed(reversal.Id);
    }
}