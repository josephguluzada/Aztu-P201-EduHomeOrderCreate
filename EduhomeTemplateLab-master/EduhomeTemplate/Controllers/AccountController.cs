using EduhomeTemplate.Models;
using EduhomeTemplate.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _dataContext;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, DataContext dataContext, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _dataContext = dataContext;
            _signInManager = signInManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(MemberLoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            AppUser user = await _userManager.FindByNameAsync(loginVM.Username);

            if (user == null)
            {
                ModelState.AddModelError("", "UserName or Passowrd is incorrect!");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "UserName or Passowrd is incorrect!");
                return View();
            }
            return RedirectToAction("index", "home");
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(MemberRegisterViewModel memberVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = await _userManager.FindByNameAsync(memberVM.Username);
            if (user != null)
            {
                ModelState.AddModelError("UserName", "UserName already exist");
                return View();
            }
            if (_dataContext.Users.Any(x => x.NormalizedEmail == memberVM.Email.ToUpper()))
            {
                ModelState.AddModelError("Email", "Email already exist");
                return View();
            }
            user = new AppUser
            {
                Email = memberVM.Email,
                UserName = memberVM.Username,
                Fullname = memberVM.Fullname
            };
            var result = await _userManager.CreateAsync(user, memberVM.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(user, "Member");
            await _signInManager.SignInAsync(user, false);

            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Profil()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);

            MemberProfileViewModel profilVM = new MemberProfileViewModel
            {
                Username = user.UserName,
                Fullname = user.Fullname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                BornDate = user.BornDate,

            };
            return View(profilVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profil(MemberProfileViewModel profilVM)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null) return NotFound();

            if (!ModelState.IsValid) return View();

            if(!string.IsNullOrWhiteSpace(profilVM.NewPassword) && !string.IsNullOrWhiteSpace(profilVM.ConfirmNewPassword))
            {
                var passwordResult =  await _userManager.ChangePasswordAsync(user, profilVM.CurrentPassword, profilVM.NewPassword);

                if (!passwordResult.Succeeded)
                {
                    foreach (var item in passwordResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View();
                }
            }

            if(user.Email != profilVM.Email && _userManager.Users.Any(x=>x.NormalizedEmail == profilVM.Email.ToUpper()))
            {
                ModelState.AddModelError("Email", "This email is already exist");
                return View();
            }

            user.Fullname = profilVM.Fullname;
            user.BornDate = profilVM.BornDate;
            user.Email = profilVM.Email;
            user.PhoneNumber = profilVM.PhoneNumber;

            await _userManager.UpdateAsync(user);

            return RedirectToAction("profil", "account");
        }
    }
}
