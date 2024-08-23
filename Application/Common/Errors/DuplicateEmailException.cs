using System.Net;


public class DuplicateEmailException : Exception,IServiceException
{
    public HttpStatusCode httpStatusCode=>HttpStatusCode.Conflict;
    public string message=>"This mail is already used";

    
}
