using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;


[ApiController]
public class ErrorsController : ControllerBase
{

    [Route("/error")]
    public IActionResult Error(){
        
        Exception ? exception=HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode,message)=exception switch 
        {
        IServiceException serviceException =>
        ((int)serviceException.httpStatusCode,serviceException.message),
        _=>(StatusCodes.Status500InternalServerError,"An error has occured"),
        };
        return Problem(statusCode:statusCode,title:message);
    }

}