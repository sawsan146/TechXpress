using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.DAL.Entities
{
    public class ShoppingCart
    {
        public int Cart_ID { get; set; }
        public int User_ID { get; set; }
        public DateTime Create_Date { get; set; }
        public float Total_Price { get; set; }

        public User User { get; set; }
        public List<CartItems> CartItems { get; set; }
    }
}
