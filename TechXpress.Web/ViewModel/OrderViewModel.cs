namespace TechXpress.Web.ViewModel
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public float TotalAmount { get; set; }
        public string Status { get; set; }
    }
}
