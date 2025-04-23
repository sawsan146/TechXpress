using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore_task
{
    public class Payment
    {
        public int Payment_ID { get; set; }
        public int Order_ID { get; set; }
        public string Payment_Method { get; set; }
        public DateTime Payment_Date { get; set; }
        public float Amount { get; set; }
        public string Status { get; set; }

        public Order Order { get; set; }
    }

}
