﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechXpress.DAL.Entities;

namespace TechXpress.Web.ViewModel
{
    public class ProductDashBoardViewModel
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

        [Required(ErrorMessage = "Please upload an image file.")]
        public List<IFormFile> UploadedImages { get; set; }

        public List<string> ImageNamesForDisplay { get; set; } 

        public float? PercentageDiscount { get; set; }
        public float? PriceAfterDiscount { get; set; }
      


    }
}