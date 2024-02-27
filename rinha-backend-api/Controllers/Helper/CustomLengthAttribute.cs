using System.ComponentModel.DataAnnotations;
using System.Net;
using rinha_backend_api.Middlewares;

namespace rinha_backend_api.Controllers.Helper
{
    public class CustomMaxLength : ValidationAttribute
    {
        public int Length { get; set; }
        public CustomMaxLength(int length, string message) : base(message)
        {
            this.Length = length;
            ErrorMessage = message;
        }

       protected override ValidationResult IsValid(object value, ValidationContext validationContext){
        if(value?.ToString().Length > Length) {
            throw new RinhaError(HttpStatusCode.UnprocessableEntity, ErrorMessage);
        }

        return ValidationResult.Success;
       }
    }

    public class CustomMinLength : ValidationAttribute
    {
        public int Length { get; set; }
        public CustomMinLength(int length, string message) : base(message)
        {
            this.Length = length;
            ErrorMessage = message;
        }

       protected override ValidationResult IsValid(object value, ValidationContext validationContext){
        if(value?.ToString().Length < Length) {
            throw new RinhaError(HttpStatusCode.UnprocessableEntity, ErrorMessage);
        }

        return ValidationResult.Success;
       }
    }
}