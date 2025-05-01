using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace TechXpress.Web.Validators
{
    public class EmailOrPhoneValidationAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var input = value as string;

            if (string.IsNullOrWhiteSpace(input))
            {
                return new ValidationResult("Email or Phone number is required");
            }

            // Check if it's a valid email
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            // Check if it's a valid phone number (e.g., digits only, allow + or leading 0s)
            var phoneRegex = new Regex(@"^\+?\d{10,15}$");

            if (emailRegex.IsMatch(input) || phoneRegex.IsMatch(input))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Please enter a valid email or phone number.");
        }
    }
}
