using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Application.Authentication.Commands.Register;
using Restaurant.Application.Authentication.Common;
using Restaurant.Contracts.Authentication;

namespace Restaurant.Api.Controllers;

public class DinnersController : ApiController
{
    [HttpGet("api/[controller]")]    
    public async Task<IActionResult> ListDinners()
    {
        return Ok(Array.Empty<string>());
    }
}
