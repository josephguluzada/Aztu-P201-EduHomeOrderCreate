using EduhomeTemplate.Helper;
using EduhomeTemplate.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeacherController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;

        public TeacherController(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.teachers.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Teacher teacher)
        {
            if (teacher.ImageFile == null)
                ModelState.AddModelError("ImageFile", "ImageFile is required");
            else if (teacher.ImageFile.Length > 2097152)
                ModelState.AddModelError("ImageFile", "ImageSize max size is 2MB");
            else if (teacher.ImageFile.ContentType != "image/jpeg" && teacher.ImageFile.ContentType != "image/png")
                ModelState.AddModelError("ImageFile", "Image type is only (png,jpeg)");


            if (!ModelState.IsValid) return View();

            teacher.Image = FileManager.Save(_env.WebRootPath, "uploads/teachers", teacher.ImageFile);

            _context.teachers.Add(teacher);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Teacher teacher = _context.teachers.FirstOrDefault(x => x.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Teacher teacher)
        {
            Teacher teacherExist = _context.teachers.FirstOrDefault(x => x.Id == teacher.Id);
            if (teacherExist == null)
            {
                return NotFound();
            }
            teacherExist.Title = teacher.Title;
            teacherExist.Experience = teacher.Experience;
            teacherExist.Degree = teacher.Degree;
            teacherExist.Desc = teacher.Desc;
            teacherExist.Faculty = teacher.Faculty;
            teacherExist.Hobbies = teacher.Hobbies;
            teacherExist.Level = teacher.Level;
            teacherExist.DescLitlle = teacher.DescLitlle;
            if (teacher.ImageFile != null)
            {
                FileManager.Delete(_env.WebRootPath, "uploads/teachers", teacherExist.Image);
                teacherExist.Image = FileManager.Save(_env.WebRootPath, "uploads/teachers", teacher.ImageFile);
            }
            else if (teacher.Image == null && teacherExist.Image != null)
            {
                FileManager.Delete(_env.WebRootPath, "uploads/teachers", teacherExist.Image);
                teacherExist.Image = null;

            }
            
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Teacher teacher = _context.teachers.FirstOrDefault(x => x.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Teacher teacher)
        {
            Teacher teacherExist = _context.teachers.FirstOrDefault(x => x.Id == teacher.Id);
            if (teacherExist == null)
            {
                return NotFound();
            }

            _context.teachers.Remove(teacherExist);
            _context.SaveChanges();

            return RedirectToAction("index");

        }
    }
}
