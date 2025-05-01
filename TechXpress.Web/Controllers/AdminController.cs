using Microsoft.AspNetCore.Mvc;

namespace TechXpress.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            //var userName = Request.Cookies["UserName"] ?? "Guest";
            //ViewBag.UserName = userName;
            return View("DashBoard");
        }
    }
}
