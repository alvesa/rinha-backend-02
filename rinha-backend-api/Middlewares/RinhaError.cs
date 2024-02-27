using System.Net;

namespace rinha_backend_api.Middlewares
{
    public class RinhaError : HttpRequestException
    {
        public int Code { get; set; }

        public RinhaError(HttpStatusCode httpStatusCode, string? message) : base(message, null, httpStatusCode)
        {
            Code = (int)httpStatusCode;
        }
    }
}