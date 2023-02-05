using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Services.Authentication;
using Restaurant.Contracts.Authentication;
using IAuthenticationService = Restaurant.Application.Services.Authentication.IAuthenticationService;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("[action]")]   
    public IActionResult Register(RegisterRequest request) 
    {
        ErrorOr<AuthenticationResult> registerResult = _authenticationService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        return registerResult.Match(
            authenticationResult => Ok(MapAuthenticationResult(authenticationResult)),
            errors => Problem(errors));
    }   

    [HttpPost("[action]")]    
    public IActionResult Login(LoginRequest request)
    {
        var loginResult = _authenticationService.Login(          
           request.Email,
           request.Password);

        //if (loginResult.IsError && loginResult.FirstError == Errors.Authentication.)
        //{
        //    return Problem(
        //        statusCode: StatusCodes.Status401Unauthorized, 
        //        title: loginResult.FirstError.Description);
        //}

        return loginResult.Match(
           authenticationResult => Ok(MapAuthenticationResult(authenticationResult)),
           errors => Problem(errors));
    }

    private static AuthenticationResponse MapAuthenticationResult(AuthenticationResult authenticationResult)
    {
        return new AuthenticationResponse(
            authenticationResult.User.Id,
            authenticationResult.User.FirstName,
            authenticationResult.User.LastName,
            authenticationResult.User.Email,
            authenticationResult.Token);
    }
}
