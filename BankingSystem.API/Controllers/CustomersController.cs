using BankingSystem.Application.Services;
using BankingSystem.Shared.DTOs.Requests;
using BankingSystem.Shared.DTOs.Responses;
using BankingSystem.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly CustomerService _customerService;

    public CustomersController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost("create")]
    public IActionResult Create(CreateCustomerRequest request)
    {
        var customerId = _customerService.Create(request.FullName);
        return Ok(ApiResponse<Guid>.Ok(customerId));
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var customers = _customerService.GetAll()
            .Select(c => new CustomerResponse
            {
                Id = c.Id,
                FullName = c.FullName,
            });

        return Ok(ApiResponse<IEnumerable<CustomerResponse>>.Ok(customers));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var customer = _customerService.GetById(id);

        return Ok(ApiResponse<CustomerResponse>.Ok(
            new CustomerResponse
            {
                Id = customer.Id,
                FullName = customer.FullName
            }));
    }
}
