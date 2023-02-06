using ErrorOr;
using MapsterMapper;
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
    private readonly IMapper _mapper;
    public AuthenticationController(ISender mediator, IMapper mapper)
    {       
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("[action]")]   
    public async Task<IActionResult> Register(RegisterRequest request) 
    {
        var command = _mapper.Map<RegisterCommand>(request);            

        ErrorOr<AuthenticationResult> authenticationResult = await _mediator.Send(command);

        return authenticationResult.Match(
            authenticationResult => Ok(_mapper.Map<AuthenticationResponse>(authenticationResult)),
            errors => Problem(errors));
    }   

    [HttpPost("[action]")]    
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        var authenticationResult = await _mediator.Send(query);

        //if (loginResult.IsError && loginResult.FirstError == Errors.Authentication.)
        //{
        //    return Problem(
        //        statusCode: StatusCodes.Status401Unauthorized, 
        //        title: loginResult.FirstError.Description);
        //}
        
        return authenticationResult.Match(
           authenticationResult => Ok(_mapper.Map<AuthenticationResponse>(authenticationResult)),
           errors => Problem(errors));
    }
}
