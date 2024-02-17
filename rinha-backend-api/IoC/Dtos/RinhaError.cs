using System.Net;

namespace rinha_backend_api.IoC.Dtos
{
    public class RinhaError : Exception
    {
        public int Code { get; set; }

        public RinhaError(HttpStatusCode httpStatusCode, string? message) : base(message)
        {
            Code = (int)httpStatusCode;
        }
    }
}