using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.DAL.Entities
{
    public class User
    {
        public int User_ID { get; set; }
        public string User_Type { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }

        public List<Order> Orders { get; set; }
        public List<Return> Returns { get; set; }
        public List<Review> Reviews { get; set; }
        public WishList WishList { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public List<ContactMessage> ContactMessages { get; set; }
    }

}
