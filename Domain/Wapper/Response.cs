using System.Data;
using System.Net;

namespace Domain.Wapper;

public class Response<T>
{  
    public int StatusCode { get; set; }
   
    public string Message { get; set; }
   
    public T Data { get; set; }

    public Response(T data)
    {
        Data = data;
        StatusCode = (int)HttpStatusCode.OK;
        Message = HttpStatusCode.OK.ToString();

    }

    public Response(string message,HttpStatusCode statusCode)
    {
        Message = message;
        StatusCode = (int)statusCode;
    }
}