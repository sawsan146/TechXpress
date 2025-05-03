using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TechXpress.Web.ViewModel
{
    public class ProductDashBoardViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 100000)]
        public float Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string Category_ID { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public List<IFormFile> UploadedImages { get; set; }
    }
}