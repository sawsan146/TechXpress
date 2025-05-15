using TechXpress.DAL.Entities;

namespace TechXpress.Web.ViewModel
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public string Description { get; set; }
        public  string Image { get; set; }
        public  float Price { get; set; }
        public int ReviewCount { get; set; }
        public  int  Rating { get; set; }

        public string Category { get; set; }


    }
}
