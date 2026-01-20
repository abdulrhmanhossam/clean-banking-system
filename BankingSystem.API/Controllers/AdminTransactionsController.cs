using BankingSystem.Application.Services;
using BankingSystem.Shared.DTOs.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
// [Authorize(Roles = "Admin")]
public class AdminTransactionsController : ControllerBase
{
    private readonly TransactionAdminService _transactionAdminService;
    private readonly TransactionReversalService _reversalService;

    public AdminTransactionsController(
        TransactionAdminService transactionAdminService,
        TransactionReversalService reversalService)
    {
        _transactionAdminService = transactionAdminService;
        _reversalService = reversalService;
    }

    [HttpDelete("{transactionId}")]
    public IActionResult SoftDelete(Guid transactionId)
    {
        _transactionAdminService.SoftDelete(transactionId);
        return NoContent();
    }

    [HttpPost("{transactionId}/reverse")]
    public IActionResult Reverse(
        Guid transactionId,
        [FromBody] ReverseTransactionRequest request)
    {
        var adminUserId = Guid.Parse(User.FindFirst("sub")!.Value);


        _reversalService.Reverse(
            transactionId,
            request.Reason,
            adminUserId
        );

        return NoContent();
    }
}
