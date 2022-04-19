#nullable disable

using App.Models.DatabaseModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<Driver> _userManager;
    private readonly SignInManager<Driver> _signInManager;
    private readonly EmailService.ISender _emailSender;

    public AccountController(UserManager<Driver> userManager, SignInManager<Driver> signInManager, EmailService.ISender sender)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailSender = sender;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(Models.ViewModels.Account.RegistrationModel userModel)
    {
        if (!ModelState.IsValid)
        {
            return View(userModel);
        }

        Driver user = new Driver();
        user.FirstName = userModel.FirstName;
        user.LastName = userModel.LastName;
        user.BirthDate = userModel.BirthDate;
        user.UserName = userModel.Email;
        user.Email = userModel.Email;

        var result = await _userManager.CreateAsync(user, userModel.Password);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return View(userModel);
        }

        string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        string link = Url.Action(nameof(ConfirmEmail), "Account", new { token, email = user.Email }, Request.Scheme);

        EmailService.Message message = new EmailService.Message(new string[] { user.Email }, "Click here to confirm your email : ", link, null);
        await _emailSender.SendEmailAsync(message);

        return RedirectToAction(nameof(HomeController.Index), "Home");
    }

    [HttpGet]
    public async Task<IActionResult> ConfirmEmail(string token, string email)
    {
        Driver user = await _userManager.FindByEmailAsync(email);
        if (user == null)
            return View("Error");

        IdentityResult result = await _userManager.ConfirmEmailAsync(user, token);
        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, false);
            return View(nameof(ConfirmEmail));
        }
        return View("Error");
    }

    [HttpGet]
    public IActionResult Login(string returnUrl)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(Models.ViewModels.Account.LoginModel userModel, string returnUrl)
    {
        if (!ModelState.IsValid)
        {
            return View(userModel);
        }

        var result = await _signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, userModel.RememberMe, false);
        if (result.Succeeded)
        {
            return RedirectToLocal(returnUrl);
        }
        else
        {
            ModelState.AddModelError("", "Invalid UserName or Password");
            return View();
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction(nameof(HomeController.Index), "Home");
    }

    private IActionResult RedirectToLocal(string returnUrl)
    {
        if (Url.IsLocalUrl(returnUrl))
            return Redirect(returnUrl);
        else
            return RedirectToAction(nameof(HomeController.Index), "Home");
    }
}
