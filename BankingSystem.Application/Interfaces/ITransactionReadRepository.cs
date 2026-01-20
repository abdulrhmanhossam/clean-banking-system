using BankingSystem.Shared.DTOs.Requests;
using BankingSystem.Shared.DTOs.Responses;

namespace BankingSystem.Application.Interfaces;

public interface ITransactionReadRepository
{
    PagedResponse<AccountStatementItem> GetPaged(
        Guid accountId,
        DateTime? from,
        DateTime? to,
        PagedRequest request);
}