using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate request)
    {
        _next=request;
    }
    public async Task Invoke(HttpContext context){

        try{
            await _next(context);
        }
        catch(Exception ex){
            await HandleExceptionAsync(context,ex);

        }
    }

    private static Task HandleExceptionAsync(HttpContext context,Exception ex)
    {
        var code =System.Net.HttpStatusCode.InternalServerError;
        var result=JsonSerializer.Serialize(new {error="Error has occured during proccessing"});
        context.Response.ContentType="application/json";
        context.Response.StatusCode=(int) code;

        return context.Response.WriteAsync(result);

    }
}