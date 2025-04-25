using Microsoft.AspNetCore.Mvc;

namespace TechXpress.Web.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Contact()
        {
            return View("Contact");
        }

        [HttpPost]
        public IActionResult Contact(string name, string email, string phone, string message)
        {

            // Here you would typically send the message to save it to a database
            ViewBag.Confirmation = "Your message has been sent successfully!";

            return View();
        }

    }
}
