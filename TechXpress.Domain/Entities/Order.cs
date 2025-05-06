using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.Domain.Entities
{
    public class Order
    {
        public int Order_ID { get; set; }
        public int? User_ID { get; set; }
        public DateTime CreationTime { get; set; }
        public string ShippingGoal { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string Status { get; set; }
        public float TotalAmount { get; set; }

        public User? User { get; set; }
        public Payment Payment { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }

}
