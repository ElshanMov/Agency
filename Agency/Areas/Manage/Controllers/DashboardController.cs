using Agency.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agency.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize]
    public class DashboardController : Controller
    {
        UserManager<AppUser> _userManager;
        RoleManager<IdentityRole> _roleManager;

        public DashboardController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> CreateRole()
        //{

        //    await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
        //    await _roleManager.CreateAsync(new IdentityRole("Admin"));
        //    await _roleManager.CreateAsync(new IdentityRole("Member"));


        //    return Ok();
        //}

        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser user = new AppUser
        //    {
        //        UserName = "SuperAdmin",
        //        FullName = "Admin Adminovic"
        //    };

        //    await _userManager.CreateAsync(user, "Admin123");
        //    var result = await _userManager.FindByNameAsync("SuperAdmin");
        //    await _userManager.AddToRoleAsync(result, "SuperAdmin");
        //    return Ok(result);
        //}


    }
}
