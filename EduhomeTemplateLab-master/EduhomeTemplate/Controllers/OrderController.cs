using EduhomeTemplate.Models;
using EduhomeTemplate.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.Controllers
{
    public class OrderController : Controller
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;

        public OrderController(DataContext context,UserManager<AppUser> userManager,IEmailService emailService)
        {
            _context = context;
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<IActionResult> Buy(int id)
        {
            Course course = _context.Courses.FirstOrDefault(x => x.Id == id);
            if (course == null) return NotFound();

            AppUser appUser = null;
            appUser = await _userManager.FindByNameAsync(User.Identity.Name);

            Order order = new Order
            {
                FullName = appUser.Fullname,
                AppUserId = appUser.Id,
                Title = course.Title,
                Email = appUser.Email,
                Price = course.Price,
                Language = course.Language,
                CreatedAt = DateTime.UtcNow.AddHours(4)
            };

            _context.Orders.Add(order);
            _context.SaveChanges();

            _emailService.Send(order.AppUser.Email, "Sifaris Qebul Olundu", "Bizi secdiyiniz ucun tesekkurler");

            return RedirectToAction("index", "home");
        }
    }
}
