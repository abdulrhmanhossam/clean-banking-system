using BankingSystem.Application.Services;
using BankingSystem.Shared.DTOs.Requests;
using BankingSystem.Shared.DTOs.Responses;
using BankingSystem.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransfersController : ControllerBase
{
    private readonly TransferService _transferService;

    public TransfersController(TransferService transferService)
    {
        _transferService = transferService;
    }

    [HttpPost]
    public IActionResult Transfer([FromBody] TransferRequest request)
    {
        var response = _transferService.Transfer(
                request.FromAccountId,
                request.ToAccountId,
                request.Amount
            );

        return Ok(ApiResponse<TransferResponse>.Ok(response));
    }
}
