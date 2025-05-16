using System.ComponentModel.DataAnnotations;

namespace TechXpress.Web.ViewModel
{
    public class ContactMessageViewModel
    {
        [Required]

        public string Name { get; set; }

        [Required]
        [EmailAddress]      
        
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]       
        public string Message { get; set; }
    }
}
