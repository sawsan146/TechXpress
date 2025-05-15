using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechXpress.DAL.Entities;

namespace TechXpress.Application.DTOs
{
    public class ProductDTO
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
        public DateTime AddTime { get; set; }= DateTime.Now;

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
        public string GPU { get; set; }
        [Required]
        public decimal ScreenSize { get; set; }
        [Required]
        public string Resolution { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int Category_ID { get; set; } = 2;

        //public IEnumerable<SelectListItem> Categories { get; set; }

        //[Required(ErrorMessage = "Please upload an image file.")]
        //public List<IFormFile> UploadedImages { get; set; }

        public float? PercentageDiscount { get; set; }
        public float? PriceAfterDiscount { get; set; }

        public int Id { get; set; } 
        public string Image { get; set; }

    }

}

