using System.ComponentModel.DataAnnotations;

namespace ASP.NET_tut.Validators
{
    public class DateCheckAttribute: ValidationAttribute
    {
        public string GetErrorMessage()=>
            $"Admission date must be greater than or equal to {DateTime.Now}";

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var date= (DateTime?)value;
            if(date<DateTime.Now){
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }

    }
}