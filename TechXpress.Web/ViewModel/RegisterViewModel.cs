using System.ComponentModel.DataAnnotations;
using TechXpress.Web.Validators;

namespace TechXpress.Web.ViewModel
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        [Display(Name = "Name")]
        [DataType(DataType.Text)]
       // [RegularExpression(@"^[A-Za-z]\w{5,29}$", ErrorMessage = "Name can only contain letters and spaces")]
        public  string Name { get; set; }


        [Required]
        [EmailOrPhoneValidation(ErrorMessage = "Please enter a valid email or phone number.")]
        public string EmailOrPhone { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Password must be at least 6 characters long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{6,}$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, and one number.")]

        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public  string ConfirmPassword { get; set; }


    }
}
