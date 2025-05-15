namespace TechXpress.Web.ViewModel
{
    public class ProductListViewModel
    {
        public List<ProductDashBoardViewModel> Products { get; set; }
        public List<string> Categories { get; set; }
        public string SelectedCategory { get; set; }
        public string SearchQuery { get; set; }
    }
}
