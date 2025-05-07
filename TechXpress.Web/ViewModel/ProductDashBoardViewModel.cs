using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TechXpress.Web.ViewModel
{
    public class ProductDashBoardViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 100000)]
        public float Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Stock { get; set; }
        
        public string Description { get; set; }        
        public DateTime AddTime { get; set; }

        [Required]
        [MaxLength(100)]        
        public string Brand { get; set; }

        [Required]
        public string Processor { get; set; }

        [Required]
        public int RAM { get; set; }

        [Required]
        public string Storage { get; set; }

        [Required]
        public string? GPU { get; set; }
        [Required]
        public decimal ScreenSize { get; set; }
        [Required]
        public string? Resolution { get; set; }





        [Required]
        [Display(Name = "Category")]
        public string Category_ID { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public List<IFormFile> UploadedImages { get; set; }


     


    }
}