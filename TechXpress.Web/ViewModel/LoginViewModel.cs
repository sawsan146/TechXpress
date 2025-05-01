using System.ComponentModel.DataAnnotations;
using TechXpress.Web.Validators;

namespace TechXpress.Web.ViewModel
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Email or Phone number is required")]
        [EmailOrPhoneValidation(ErrorMessage = "Please enter a valid email or phone number.")]
        public string EmailOrPhone { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]   
        public string Password { get; set; }
      


    }
}
