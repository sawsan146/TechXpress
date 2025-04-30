namespace TechXpress.Web.ViewModel
{
    public class CartitemsViewModel
    {
        public int Cart_Item_ID { get; set; }
        //public int Cart_ID { get; set; }
        //public int Product_ID { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        //public DateTime AdditionTime { get; set; }
        //public ShoppingCartViewModel Cart { get; set; }


        public ProductViewModel Product { get; set; }
    }
}
