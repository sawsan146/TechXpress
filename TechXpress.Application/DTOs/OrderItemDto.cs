using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.Application.DTOs
{
    public class OrderItemDto
    {
        public string ProductName { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public float Total => Price * Quantity;
    }
}

