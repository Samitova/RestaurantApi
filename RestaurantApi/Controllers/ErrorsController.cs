using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Api.Controllers;

public class ErrorsController : ApiController
{
    [Route("/error")]
    [HttpGet]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;       

        return Problem(title: exception?.Message, statusCode: 500);
    }
}

