using System.ComponentModel.DataAnnotations;

namespace TechXpress.Web.ViewModel
{
    public class CategoryViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public bool IsSelected { get; set; }
    }
}
