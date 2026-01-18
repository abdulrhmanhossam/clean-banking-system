using BankingSystem.Application.Services;
using BankingSystem.Shared.DTOs.Requests;
using BankingSystem.Shared.DTOs.Responses;
using BankingSystem.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly AccountStatementService _statementService;
    private readonly AccountService _accountService;

    public AccountsController(AccountService accountService, AccountStatementService statementService)
    {
        _accountService = accountService;
        _statementService = statementService;
    }

    [HttpPost("create")]
    public IActionResult CreateAccount([FromBody] CreateAccountRequest request)
    {
        var response = _accountService.CreateAccount(request.CustomerId);

        return Ok(ApiResponse<AccountResponse>.Ok(response));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var responses = _accountService.GetAll()
            .Select(a => new AccountResponse
            {
                AccountId = a.Id,
                CustomerId = a.CustomerId,
                Balance = a.Balance
            });

        return Ok(ApiResponse<IEnumerable<AccountResponse>>.Ok(responses));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var response = _accountService.GetById(id);

        return Ok(ApiResponse<AccountDetailsResponse>.Ok(response));
    }

    [HttpPost("deposit")]
    public IActionResult Deposit([FromBody] DepositRequest request)
    {
        var response = _accountService
            .Deposit(request.AccountId, request.Amount);

        return Ok(ApiResponse<DepositResponse>.Ok(response));
    }

    [HttpPost("withdraw")]
    public IActionResult Withdraw([FromBody] WithdrawRequest request)
    {
        var response = _accountService
            .Withdraw(request.AccountId, request.Amount);

        return Ok(ApiResponse<WithdrawResponse>.Ok(response));
    }

    [HttpGet("{id}/statement")]
    public IActionResult GetStatement(
    Guid id,
    [FromQuery] DateTime? from,
    [FromQuery] DateTime? to)
    {
        var response = _statementService.GetStatement(id, from, to);

        return Ok(ApiResponse<AccountStatementResponse>.Ok(response));
    }

    [HttpGet("{id}/statement/paged")]
    public IActionResult GetStatementPaged(
    Guid id,
    [FromQuery] DateTime? from,
    [FromQuery] DateTime? to,
    [FromQuery] PagedRequest request)
    {
        var result = _statementService
            .GetStatementPaged(id, from, to, request);

        return Ok(ApiResponse<PagedResponse<AccountStatementItem>>.Ok(result));
    }

    [HttpPost("{id}/suspend")]
    public IActionResult Suspend(Guid id)
    {
        _accountService.Suspend(id);
        return NoContent();
    }

    [HttpPost("{id}/activate")]
    public IActionResult Activate(Guid id)
    {
        _accountService.Activate(id);
        return NoContent();
    }

}
