using System.ComponentModel.DataAnnotations;
using System.Net;
using rinha_backend_api.Middlewares;

namespace rinha_backend_api.Controllers.Helper
{
    public class CustomValue : ValidationAttribute
    {
        public long Value { get; set; }
        public CustomValue(string message) : base(message)
        {
            ErrorMessage = message;
        }

       protected override ValidationResult IsValid(object value, ValidationContext validationContext){
        if((long)value < 0) {
            throw new RinhaError(HttpStatusCode.UnprocessableEntity, ErrorMessage);
        }

        return ValidationResult.Success;
       }
    }

}