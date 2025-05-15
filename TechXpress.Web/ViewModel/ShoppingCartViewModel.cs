using TechXpress.DAL.Entities;

namespace TechXpress.Web.ViewModel
{
    public class ShoppingCartViewModel
    {
        public List<CartitemsViewModel> ShoppingCartList { get; set; } = new();
        public float OrderTotal { get; set; }
    }
}
