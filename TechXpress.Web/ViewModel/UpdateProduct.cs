using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TechXpress.Web.ViewModel
{
    public class UpdateProduct
    {
        public int ProductID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 100000)]
        public float Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }

        [Required]
        public string Description { get; set; }
        public DateTime AddTime { get; set; } = DateTime.Now;

        [Required]
        [MaxLength(100)]
        public string Brand { get; set; }

        public string? Processor { get; set; }

        public int? RAM { get; set; }

        public string? Storage { get; set; }

        public string? GPU { get; set; }
        public decimal? ScreenSize { get; set; }
        public string? Resolution { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string Category_ID { get; set; }

        public string CategoryName { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        public List<IFormFile>? UploadedImages { get; set; }

        public List<string> ImageNamesForDisplay { get; set; }

        public float? PercentageDiscount { get; set; }
        public float? PriceAfterDiscount { get; set; }


    }

}
