namespace TechXpress.Web.ViewModel
{
    public class OrderSummaryViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();
    }
    public class OrderItemViewModel
    {
        public string ProductName { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public float Total => Price * Quantity;
    }
}
