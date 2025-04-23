using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore_task
{
    public class Category
    {
        public int Category_ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }

}
