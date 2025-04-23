using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.Domain.Entities
{
    public class WishList
    {
        public int WishList_ID { get; set; }
        public int User_ID { get; set; }

        public User User { get; set; }
        public List<WishListItems> WishListItems { get; set; }
    }
}
