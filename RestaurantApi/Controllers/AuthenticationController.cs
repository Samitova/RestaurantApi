using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Authentication.Commands.Register;
using Restaurant.Application.Authentication.Common;
using Restaurant.Application.Authentication.Queries.Login;
using Restaurant.Contracts.Authentication;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;   
    public AuthenticationController(ISender mediator)
    {       
        _mediator = mediator;
    }

    [HttpPost("[action]")]   
    public async Task<IActionResult> Register(RegisterRequest request) 
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);

        ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);

        return registerResult.Match(
            authenticationResult => Ok(MapAuthenticationResult(authenticationResult)),
            errors => Problem(errors));
    }   

    [HttpPost("[action]")]    
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        var loginResult = await _mediator.Send(query);

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
