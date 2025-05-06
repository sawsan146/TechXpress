using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.Domain.Entities
{
    public class Return
    {
        public int Return_ID { get; set; }
        public int? User_ID { get; set; }
        public int? Order_ID { get; set; }
        public string Reason { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Status { get; set; }

        public User? User { get; set; }
        public Order? Order { get; set; }
    }

}
