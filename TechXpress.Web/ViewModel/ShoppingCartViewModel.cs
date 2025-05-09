using TechXpress.DAL.Entities;

namespace TechXpress.Web.ViewModel
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<CartitemsViewModel> ShoppingCartList { get; set; }
        public float OrderTotal { get; set; }

        //public OrderHeader OrderHeader { get; set; }
    }
}
