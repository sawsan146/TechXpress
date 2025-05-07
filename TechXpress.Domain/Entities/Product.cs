using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.Domain.Entities
{
    public class Product
    {
        public int Product_ID { get; set; }
        public int Category_ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public DateTime AddTime { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public string Processor { get; set; }
        public int RAM { get; set; }
        public string Storage { get; set; }
        public string GPU { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal ScreenSize { get; set; }
        public string Resolution { get; set; }
        public float? PercentageDiscount { get; set; }
        public float? PriceAfterDiscount { get; set; }
        public Category Category { get; set; }
        public List<ProductImg> ProductImages { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
        public List<CartItems> CartItems { get; set; }
        public List<Review> Reviews { get; set; }
    }

}
