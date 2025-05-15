using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TechXpress.Application.ApplicationServices.Contract; 
using TechXpress.BLL.Services.Contracts; 
using TechXpress.DAL.Entities;
using TechXpress.Web.ViewModel;

namespace TechXpress.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IOrderAppService _orderAppService;

        public AccountController(IUserService userService, IOrderAppService orderAppService)
        {
            _userService = userService;
            _orderAppService = orderAppService;
        }

        [Authorize]
        public IActionResult MyAccount()
        {
            var userEmail = User.Identity.Name;
            var user = _userService.GetUserByEmail(userEmail);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var model = new UserProfileViewModel
            {
                FirstName = user.Fname,
                LastName = user.Lname,
                Email = user.Email,
                Address = user.Country
            };
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpdateProfile(UserProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userEmail = User.Identity.Name;
                var user = _userService.GetUserByEmail(userEmail);
                if (user == null)
                {
                    return NotFound("User not found");
                }

                user.Fname = model.FirstName;
                user.Lname = model.LastName;
                user.Email = model.Email;

                _userService.UpdateUser(user);
                TempData["Success"] = "Profile updated successfully!";
                return RedirectToAction(nameof(MyAccount));
            }
            return View("MyAccount", model);
        }

        [Authorize]
        public IActionResult Orders()
        {
            var userEmail = User.Identity.Name;
            var user = _userService.GetUserByEmail(userEmail);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var orders = _orderAppService.GetOrdersByUserId(user.User_ID);
            var orderViewModels = orders.Select(o => new OrderViewModel
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                TotalAmount = (float)o.TotalAmount,
                Status = o.Status
            }).ToList();
            return View(orderViewModels);
        }

        [Authorize]
        public IActionResult Returns()
        {
            var userEmail = User.Identity.Name;
            var returns = new List<OrderViewModel>
            {
                new OrderViewModel
                {
                    OrderId = 1,
                    OrderDate = new DateTime(2025, 3, 30, 18, 18, 0),
                    TotalAmount = 350.00f,
                    Status = "RETURNED"
                }
            };
            return View(returns);
        }
    }
}