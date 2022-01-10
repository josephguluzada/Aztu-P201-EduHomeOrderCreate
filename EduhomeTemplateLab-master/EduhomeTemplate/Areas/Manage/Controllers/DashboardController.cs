using EduhomeTemplate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser appUser = new AppUser
        //    {
        //        Fullname = "Super Admin",
        //        UserName = "SuperAdmin"
        //    };
        //    var result = await _userManager.CreateAsync(appUser, "Admin123");
        //    return Ok(result);
        //}

    }
}
