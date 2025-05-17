using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TechXpress.Application.ApplicationServices.Contract;
using TechXpress.Application.DTOs;
using TechXpress.Web.ViewModel;

namespace TechXpress.Web.Controllers
{
    public class ContactController : Controller
    {

        private readonly IContactMessageAppService contactMessageAppService;
        private readonly IUserAppService userAppService;
        private readonly IMapper mapper;

        public ContactController(IContactMessageAppService contactMessageAppService, IMapper mapper, IUserAppService userAppService)
        {
            this.contactMessageAppService = contactMessageAppService;
            this.mapper = mapper;
            this.userAppService = userAppService;
        }


        public IActionResult Contact()
        {
            return View("Contact");
        }

        [HttpPost]
        public IActionResult Contact(ContactMessageViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Contact));   
            }
            var Dto=mapper.Map<ContactMassegeDTO>(vm);
            Dto.UserId= userAppService.GetCurrentUser().User_ID;
            contactMessageAppService.SendMessage(Dto);
            ViewBag.Confirmation = "Your message has been sent successfully!";

            return View(vm);
        }

    }
}
