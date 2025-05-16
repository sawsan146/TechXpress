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

        public string Description { get; set; }
        public DateTime AddTime { get; set; }= DateTime.Now;

        [Required]
        [MaxLength(100)]
        public string Brand { get; set; }

        [Required]
        public string? Processor { get; set; }

        
        public int? RAM { get; set; }

        public string? Storage { get; set; }

        public string? GPU { get; set; }
        public decimal? ScreenSize { get; set; }
        public string?  Resolution { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string Category_ID { get; set; } 

        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Please upload an image file.")]
        public List<string> UploadedImages { get; set; }

        public float? PercentageDiscount { get; set; }
        public float? PriceAfterDiscount { get; set; }

        public int Id { get; set; } 
        public string Image { get; set; }

    }

}

