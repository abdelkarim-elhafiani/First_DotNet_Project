using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class ErrorHandlerFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception=context.Exception;
        var problemDetails=new ProblemDetails{
            Type="www.google.com",
            Title="error has occured while processing your requestion",
            Status=(int) HttpStatusCode.InternalServerError

        };

        context.Result=new ObjectResult(problemDetails);
        context.ExceptionHandled=true;
    }
}