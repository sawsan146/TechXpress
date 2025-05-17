//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using TechXpress.Web.ViewModel;

//[Authorize(Roles = "Admin")]
//public class UserController : Controller
//{
//    public IActionResult Index()
//    {
//        ViewData["active"] = "User";
//        List<UserManagementViewModel> fakeUsers = GenerateFakeUsers();
//        return View("AllUsers",fakeUsers);
//    }

//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public IActionResult BlockUser(string userId)
//    {
//        return Json(new { success = true, message = "User blocked successfully (test mode)" });
//    }

//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public IActionResult UnblockUser(string userId)
//    {
//        return Json(new { success = true, message = "User unblocked successfully (test mode)" });
//    }

//    [HttpPost]
//    [ValidateAntiForgeryToken]
//    public IActionResult UpdateUserRole(string userId, string newRole)
//    {
//        return Json(new
//        {
//            success = true,
//            message = $"User role updated to {newRole} (test mode)"
//        });
//    }

//    private List<UserManagementViewModel> GenerateFakeUsers()
//    {
//        var availableRoles = new List<string> { "Admin", "Manager", "User" };

//        return new List<UserManagementViewModel>
//        {
//            new UserManagementViewModel {
//                Id = "1",
//                UserName = "admin_user",
//                Email = "admin@example.com",
//                IsBlocked = false,
//                CurrentRole = "Admin",
//                AvailableRoles = availableRoles,
//                RegistrationDate = DateTime.Now.AddDays(-30)
//            },
//            new UserManagementViewModel {
//                Id = "2",
//                UserName = "manager_john",
//                Email = "john.manager@example.com",
//                IsBlocked = false,
//                CurrentRole = "Manager",
//                AvailableRoles = availableRoles,
//                RegistrationDate = DateTime.Now.AddDays(-15)
//            },
//            new UserManagementViewModel {
//                Id = "3",
//                UserName = "regular_user1",
//                Email = "user1@example.com",
//                IsBlocked = false,
//                CurrentRole = "User",
//                AvailableRoles = availableRoles,
//                RegistrationDate = DateTime.Now.AddDays(-7)
//            },
//            new UserManagementViewModel {
//                Id = "4",
//                UserName = "blocked_user",
//                Email = "blocked@example.com",
//                IsBlocked = true,
//                CurrentRole = "User",
//                AvailableRoles = availableRoles,
//                RegistrationDate = DateTime.Now.AddDays(-60)
//            },
//            new UserManagementViewModel {
//                Id = "5",
//                UserName = "new_user",
//                Email = "new@example.com",
//                IsBlocked = false,
//                CurrentRole = "User",
//                AvailableRoles = availableRoles,
//                RegistrationDate = DateTime.Now.AddDays(-1)
//            }
//        };
//    }
//}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TechXpress.Application.ApplicationServices.Contract;
using TechXpress.Application.DTOs;
using TechXpress.Web.ViewModel;

[Authorize(Roles = "Admin")]
public class UserController : Controller
{
    private readonly IUserAppService _userAppService;

    public UserController(IUserAppService userAppService)
    {
        _userAppService = userAppService;
    }

    public IActionResult Index()
    {
        ViewData["active"] = "User";

        // جلب جميع المستخدمين - لو في طريقة GetAllUsers في المستقبل نستخدمها
        // الآن نفترض بنستخدم GetAllUsers وهمي
        var usersDto = _userAppService.GetAllUsers(); // أو نطلب منك تضيف GetAllUsers في الـ Interface
        var usersVm = MapToViewModel(usersDto);

        return View("AllUsers", usersVm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult BlockUser(int userId)
    {
        var user = _userAppService.GetUserById(userId);
        if (user == null)
            return Json(new { success = false, message = "User not found." });

       // user.IsBlocked = true;
        _userAppService.UpdateUser(user);

        return Json(new { success = true, message = "User blocked successfully" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UnblockUser(int userId)
    {
        var user = _userAppService.GetUserById(userId);
        if (user == null)
            return Json(new { success = false, message = "User not found." });

       //// user.IsBlocked = false;
        _userAppService.UpdateUser(user);

        return Json(new { success = true, message = "User unblocked successfully" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UpdateUserRole(int userId, string newRole)
    {
        var user = _userAppService.GetUserById(userId);
        if (user == null)
            return Json(new { success = false, message = "User not found." });

      //  user.Role = newRole; // يفترض أن UserDTO يحتوي خاصية Role
        _userAppService.UpdateUser(user);

        return Json(new { success = true, message = $"User role updated to {newRole}" });
    }

    // تحويل من DTO إلى ViewModel
    private List<UserManagementViewModel> MapToViewModel(List<UserDTO> usersDto)
    {
        var availableRoles = new List<string> { "Admin", "Manager", "User" };

        var list = new List<UserManagementViewModel>();
        foreach (var dto in usersDto)
        {
            list.Add(new UserManagementViewModel
            {
                Id = dto.User_ID.ToString(),
                UserName = dto.User_Name,
                Email = dto.Email,
              //  IsBlocked = dto.IsBlocked,
                CurrentRole = dto.User_Type,
                AvailableRoles = availableRoles,
                //RegistrationDate = dto.RegistrationDate
            });
        }
        return list;
    }

}
