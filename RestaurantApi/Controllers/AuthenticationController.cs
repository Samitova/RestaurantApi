using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Services.Authentication;
using Restaurant.Contracts.Authentication;
using IAuthenticationService = Restaurant.Application.Services.Authentication.IAuthenticationService;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("[action]")]   
    public IActionResult Register(RegisterRequest request) 
    {
        var authenticationResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var response = new AuthenticationResponse(
            authenticationResult.Id,
            authenticationResult.FirstName,
            authenticationResult.LastName,
            authenticationResult.Email,
            authenticationResult.Token);

        return Ok(response);
    }

    [HttpPost("[action]")]    
    public IActionResult Login(LoginRequest request)
    {
        var loginResult = _authenticationService.Login(          
           request.Email,
           request.Password);

        var response = new AuthenticationResponse(
            loginResult.Id,
            loginResult.FirstName,
            loginResult.LastName,
            loginResult.Email,
            loginResult.Token);

        return Ok(response);
    }
}
