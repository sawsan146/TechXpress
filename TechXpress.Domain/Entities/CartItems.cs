using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore_task
{
    public class CartItems
    {
        public int Cart_Item_ID { get; set; }
        public int Cart_ID { get; set; }
        public int Product_ID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public DateTime AdditionTime { get; set; }

        public ShoppingCart Cart { get; set; }
        public Product Product { get; set; }
    }

}
