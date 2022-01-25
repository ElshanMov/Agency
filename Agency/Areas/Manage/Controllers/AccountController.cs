using Agency.Areas.Manage.ViewModels;
using Agency.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agency.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        UserManager<AppUser> _userManager;
        AgencyContext _context;
        SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, AgencyContext context, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {

            if (!ModelState.IsValid) return View();
            AppUser appUser =await _userManager.FindByNameAsync(loginVM.UserName);
            if (appUser==null)
            {
                ModelState.AddModelError("", "User name ve ya sifhre yanlishdir");
            }

            var result=await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "User name ve ya sifhre yanlishdir");
            }

            

            return RedirectToAction("index", "dashboard");
        }
    }
}
