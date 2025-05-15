using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.Application.DTOs
{
    public class ShoppingCartDTO
    {
        public List<CartItemDTO> CartItems { get; set; } = new();
        public float TotalPrice { get; set; }
    }
}
