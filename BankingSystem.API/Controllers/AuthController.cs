using BankingSystem.Application.Services;
using BankingSystem.Shared.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _auth;

        public AuthController(AuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var result = _auth.Login(request.Email, request.Password);
            return Ok(result);
        }
    }
}