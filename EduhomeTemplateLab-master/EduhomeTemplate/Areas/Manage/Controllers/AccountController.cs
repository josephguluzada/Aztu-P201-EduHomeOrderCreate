using EduhomeTemplate.Areas.Manage.ViewModels;
using EduhomeTemplate.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.Areas.Manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Login()
        {
            //AppUser user = _userManager.FindByNameAsync("SuperAdmin").Result;
            //var result = _userManager.AddToRoleAsync(user, "SuperAdmin").Result;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginViewModel adminVM)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            AppUser admin = await _userManager.FindByNameAsync(adminVM.UserName);

            if (admin == null)
            {
                ModelState.AddModelError("", "UserName or Passowrd is incorrect!");
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(admin, adminVM.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Passowrd is incorrect!");
                return View();
            }
            return RedirectToAction("index","dashboard");
        }

        public async Task<IActionResult> CreateRole()
        {
            IdentityRole role1 = new IdentityRole("SuperAdmin");
            IdentityRole role2 = new IdentityRole("Admin");
            IdentityRole role3 = new IdentityRole("Member");

            await _roleManager.CreateAsync(role1);
            await _roleManager.CreateAsync(role2);
            await _roleManager.CreateAsync(role3);

            return Ok();
        }
    }
}
