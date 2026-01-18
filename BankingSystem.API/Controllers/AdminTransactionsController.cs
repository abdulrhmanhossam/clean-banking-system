using BankingSystem.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminTransactionsController : ControllerBase
{
    private readonly TransactionAdminService _transactionAdminService;

    public AdminTransactionsController(
        TransactionAdminService transactionAdminService)
    {
        _transactionAdminService = transactionAdminService;
    }

    [HttpDelete("{transactionId}")]
    public IActionResult SoftDelete(Guid transactionId)
    {
        _transactionAdminService.SoftDelete(transactionId);
        return NoContent();
    }
}
