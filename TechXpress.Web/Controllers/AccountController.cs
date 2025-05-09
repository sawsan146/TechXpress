using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechXpress.BLL.IService;
using TechXpress.DAL.Entities;
using TechXpress.Web.ViewModel;

namespace TechXpress.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInmanager;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AccountController(UserManager<User> userManager,
           SignInManager<User> signInManager
           , ITokenService tokenService,
           IEmailService emailService, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInmanager = signInManager;
            _tokenService = tokenService;
            _emailService = emailService;
            this._roleManager = roleManager;
        }
        public IActionResult MyAccount()
        {
            return View();
        }
        #region Register

        // /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterViewModel model)
        //{
        //    if (ModelState.IsValid) // Server Side Validation
        //    {
        //        var user = new ApplicationUser()
        //        {
        //            FName = model.FName,
        //            LName = model.LName,
        //            UserName = model.Email.Split('@')[0],
        //            Email = model.Email,
        //            IsAgree = model.IsAgree
        //        };

        //        var result = await _userManager.CreateAsync(user, model.Password);

        //        if (result.Succeeded)
        //            return RedirectToAction(nameof(Login));

        //        foreach (var error in result.Errors)
        //            ModelState.AddModelError(string.Empty, error.Description);
        //    }
        //    return View(model);
        //}

        //#endregion

        //#region Login

        ////public IActionResult GoogleLogin()
        ////{
        ////	var prop = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
        ////	return Challenge(prop, GoogleDefaults.AuthenticationScheme);
        ////}

        ////public async Task<IActionResult> GoogleResponse()
        ////{
        ////	var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
        ////	var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim =>
        ////	new
        ////	{
        ////		claim.Type,
        ////		claim.Value,
        ////		claim.Issuer,
        ////		claim.OriginalIssuer
        ////	});

        ////	return Json(claims);
        ////}






        //public IActionResult Login()
        //{
        //    return View();
        //}


        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByEmailAsync(model.Email);
        //        if (user is not null)
        //        {
        //            var flag = await _userManager.CheckPasswordAsync(user, model.Password);
        //            if (flag)
        //            {
        //                await _signInManager.PasswordSignInAsync(user, model.Password, model.RemeberMe, false);
        //                return RedirectToAction("Index", "Home");
        //            }
        //            ModelState.AddModelError(string.Empty, "Invalid Password");
        //        }
        //        ModelState.AddModelError(string.Empty, "Email is not Exsited");
        //    }
        //    return View(model);
        //}



        //public IActionResult GoogleLogin()
        //{
        //    var prop = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
        //    return Challenge(prop, GoogleDefaults.AuthenticationScheme);
        //}

        //public async Task<IActionResult> GoogleResponse()
        //{
        //    var result = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);
        //    var Claims = result.Principal.Identities.FirstOrDefault().Claims.Select(cliam => new
        //    {
        //        cliam.Issuer,
        //        cliam.OriginalIssuer,
        //        cliam.Type,
        //        cliam.Value
        //    });
        //    return RedirectToAction("Index", "Home");
        //}



        //#endregion

        //#region Sign Out

        //public new async Task<IActionResult> SignOut()
        //{
        //    await _signInManager.SignOutAsync();
        //    return RedirectToAction(nameof(Login));
        //}

        //#endregion

        //#region Forget Password

        //public IActionResult ForgetPassword()
        //{
        //    return View();
        //}

        //// baseUrl/Account/SendEmail
        //[HttpPost]
        //public async Task<IActionResult> SendEmail(ForgetPasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByEmailAsync(model.Email);
        //        if (user is not null)
        //        {
        //            var token = await _userManager.GeneratePasswordResetTokenAsync(user); // Valid Just Only One Time Per User
        //            var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);
        //            var email = new Email()
        //            {
        //                Subject = "Reset Password",
        //                To = model.Email,
        //                Body = passwordResetLink
        //            };
        //            emailSettings.SendEmail(email);
        //            return RedirectToAction(nameof(CheckYourInbox));
        //        }
        //        ModelState.AddModelError(string.Empty, "Email is not Existed");
        //    }
        //    return View(model);
        //}





        //[HttpPost]
        //public async Task<IActionResult> SendSms(ForgetPasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = await _userManager.FindByEmailAsync(model.Email);
        //        if (user is not null)
        //        {
        //            var token = await _userManager.GeneratePasswordResetTokenAsync(user); // Valid Just Only One Time Per User
        //            var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);
        //            var sms = new SmsMessage()
        //            {
        //                phoneNumber = user.PhoneNumber,
        //                Body = passwordResetLink
        //            };
        //            smsService.Send(sms);
        //            return Ok("Check your phone");
        //        }
        //        ModelState.AddModelError(string.Empty, "Email is not Existed");
        //    }
        //    return View(model);
        //}

        //[HttpPost]




        //public IActionResult CheckYourInbox()
        //{
        //    return View();
        //}
        //#endregion

        //#region Reset Password

        //public IActionResult ResetPassword(string email, string token)
        //{
        //    TempData["email"] = email;
        //    TempData["token"] = token;
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var email = TempData["email"] as string;
        //        var token = TempData["token"] as string;

        //        var user = await _userManager.FindByEmailAsync(email);
        //        var result = await _userManager.ResetPasswordAsync(user, token, model.NewPassword);
        //        if (result.Succeeded)
        //            return RedirectToAction(nameof(Login));
        //        foreach (var error in result.Errors)
        //            ModelState.AddModelError(string.Empty, error.Description);
        //    }
        //    return View(model);
        //}


        #endregion
        public IActionResult Orders()
        {
            var orders = new List<OrderViewModel>
        {
            new OrderViewModel
            {
                OrderId = 1,
                OrderDate = new DateTime(2025, 3, 19, 15, 17, 0), 
                TotalAmount = 350.00m,
                Status = "Delivered"
            },
            new OrderViewModel
            {
                OrderId = 2,
                OrderDate = new DateTime(2025, 3, 19, 15, 17, 0),
                TotalAmount = 575.00m,
                Status = "Delivered"
            }
        };
            return View(orders);
        }
        public IActionResult Returns()
        {
            var userEmail = User.Identity.Name;
            var returns = new List<OrderViewModel>
    {
        new OrderViewModel
        {
            OrderId = 1,
            OrderDate = new DateTime(2025, 3, 30, 18, 18, 0),
            TotalAmount = 350.00m,
            Status = "RETURNED"
        }
    };

            return View(returns);
        }
    }
}
