using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Authentication.Commands.Register;
using Restaurant.Application.Authentication.Common;
using Restaurant.Application.Authentication.Queries.Login;
using Restaurant.Contracts.Authentication;

namespace Restaurant.Api.Controllers;

[Route("api/[controller]")]
[AllowAnonymous]
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
        
        return authenticationResult.Match(
           authenticationResult => Ok(_mapper.Map<AuthenticationResponse>(authenticationResult)),
           errors => Problem(errors));
    }
}
