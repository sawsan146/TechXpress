using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.DAL.Entities
{
    public class Review
    {
        public int Review_ID { get; set; }
        public int User_ID { get; set; }
        public int Product_ID { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }
    }

}
