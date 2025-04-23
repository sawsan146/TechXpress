using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.Domain.Entities
{
    public class WishListItems
    {
        public int WishList_Item_ID { get; set; }
        public int WishList_ID { get; set; }
        public int Product_ID { get; set; }

        public WishList WishList { get; set; }
        public Product Product { get; set; }
    }
}
