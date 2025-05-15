using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.Application.DTOs
{
    public class CartItemDTO
    {
        public int Cart_Item_ID { get; set; }
        public int Product_ID { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string ProductImage { get; set; }
    }
}
