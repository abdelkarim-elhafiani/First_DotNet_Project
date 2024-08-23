using System.Net;

public interface IServiceException
{

    public HttpStatusCode httpStatusCode { get; }
    public string message { get; }
}
