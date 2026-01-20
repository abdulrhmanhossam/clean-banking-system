using BankingSystem.Application.Interfaces;
using BankingSystem.Domain.Enums;
using BankingSystem.Shared.DTOs.Responses;
using BankingSystem.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionsController : ControllerBase
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionsController(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    [HttpGet("{accountId}")]
    public IActionResult GetHistory(
    Guid accountId,
    [FromQuery] TransactionStatus? status)
    {
        var query = _transactionRepository
            .QueryByAccountId(accountId);

        if (status.HasValue)
            query = query.Where(t => t.Status == status);

        var result = query.Select(t => new TransactionResponse
        {
            Id = t.Id,
            Type = t.Type.ToString(),
            Status = t.Status.ToString(),
            Amount = t.Amount,
            TargetAccountId = t.TargetAccountId,
            CreatedAt = t.CreatedAt
        });

        return Ok(ApiResponse<IEnumerable<TransactionResponse>>.Ok(result));
    }
}
