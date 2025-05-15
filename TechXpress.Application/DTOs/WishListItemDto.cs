using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.Application.DTOs
{
    public class WishListItemDto
    {
        public int Id { get; set; }           
        public float Price { get; set; }
        public string ProductName { get; set; }   
        public string ProductImageUrl { get; set; } 
    }
}
