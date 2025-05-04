using TechXpress.Domain.Entities;

namespace TechXpress.Web.ViewModel
{
    public class WishListItemsViewModel
    {
        public int WishList_Item_ID { get; set; }
        public float Price { get; set; }
        public ProductViewModel Product { get; set; }
    }
}
