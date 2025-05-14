using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.DAL.Entities
{
    public class Category
    {
        public string Category_ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsSelected { get; set; }
        public List<Product> Products { get; set; }
    }

}
