using BankingSystem.Application.Interfaces;
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
    public IActionResult GetHistory(Guid accountId)
    {
        var transactions = _transactionRepository.GetByAccountId(accountId)
           .Select(t => new
           {
               t.Id,
               t.Type,
               t.Amount,
               t.CreatedAt
           });

        return Ok(ApiResponse<IEnumerable<object>>.Ok(transactions));
    }
}
