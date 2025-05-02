using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TechXpress.Web.ViewModel;

[Authorize(Roles = "Admin")]
public class UserController : Controller
{
    public IActionResult Index()
    {
        ViewData["active"] = "User";
        List<UserManagementViewModel> fakeUsers = GenerateFakeUsers();
        return View("AllUsers",fakeUsers);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult BlockUser(string userId)
    {
        // Fake implementation - in real app would update database
        return Json(new { success = true, message = "User blocked successfully (test mode)" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UnblockUser(string userId)
    {
        // Fake implementation
        return Json(new { success = true, message = "User unblocked successfully (test mode)" });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UpdateUserRole(string userId, string newRole)
    {
        // Fake implementation
        return Json(new
        {
            success = true,
            message = $"User role updated to {newRole} (test mode)"
        });
    }

    private List<UserManagementViewModel> GenerateFakeUsers()
    {
        var availableRoles = new List<string> { "Admin", "Manager", "User" };

        return new List<UserManagementViewModel>
        {
            new UserManagementViewModel {
                Id = "1",
                UserName = "admin_user",
                Email = "admin@example.com",
                IsBlocked = false,
                CurrentRole = "Admin",
                AvailableRoles = availableRoles,
                RegistrationDate = DateTime.Now.AddDays(-30)
            },
            new UserManagementViewModel {
                Id = "2",
                UserName = "manager_john",
                Email = "john.manager@example.com",
                IsBlocked = false,
                CurrentRole = "Manager",
                AvailableRoles = availableRoles,
                RegistrationDate = DateTime.Now.AddDays(-15)
            },
            new UserManagementViewModel {
                Id = "3",
                UserName = "regular_user1",
                Email = "user1@example.com",
                IsBlocked = false,
                CurrentRole = "User",
                AvailableRoles = availableRoles,
                RegistrationDate = DateTime.Now.AddDays(-7)
            },
            new UserManagementViewModel {
                Id = "4",
                UserName = "blocked_user",
                Email = "blocked@example.com",
                IsBlocked = true,
                CurrentRole = "User",
                AvailableRoles = availableRoles,
                RegistrationDate = DateTime.Now.AddDays(-60)
            },
            new UserManagementViewModel {
                Id = "5",
                UserName = "new_user",
                Email = "new@example.com",
                IsBlocked = false,
                CurrentRole = "User",
                AvailableRoles = availableRoles,
                RegistrationDate = DateTime.Now.AddDays(-1)
            }
        };
    }
}
