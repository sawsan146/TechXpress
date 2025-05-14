using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechXpress.Application.DTOs
{
    namespace TechXpress.Web.DTO
    {
        public class CategoryDto
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public bool IsSelected { get; set; }
        }
    }
}
