using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore_task
{
    public class ProductImg
    {
        public int Image_ID { get; set; }
        public int Product_ID { get; set; }
        public string ImageURL { get; set; }

        public Product Product { get; set; }
    }

}
