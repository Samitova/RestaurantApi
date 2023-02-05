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

        //var (statusCode, message) = exception switch {
        //    IServiceExceprion serviceExeption => ((int)serviceExeption.StatusCode, serviceExeption.ErrorMessage),
        //    _ =>(StatusCodes.Status500InternalServerError, "An unexpected error occurred.")
        //};
        return Problem(title: exception?.Message, statusCode: 500);
    }
}

