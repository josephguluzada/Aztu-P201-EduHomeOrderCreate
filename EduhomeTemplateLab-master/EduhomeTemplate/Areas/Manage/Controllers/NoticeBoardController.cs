using EduhomeTemplate.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class NoticeBoardController : Controller
    {
        private readonly DataContext _context;
        public NoticeBoardController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.noticeBoards.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(NoticeBoard notice)
        {
            _context.noticeBoards.Add(notice);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            NoticeBoard notice = _context.noticeBoards.FirstOrDefault(x => x.Id == id);
            if (notice == null)
            {
                return NotFound();
            }
            return View(notice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(NoticeBoard notice)
        {
            NoticeBoard noticeExist = _context.noticeBoards.FirstOrDefault(x => x.Id == notice.Id);
            if (noticeExist == null)
            {
                return NotFound();
            }
            noticeExist.Date = notice.Date;
            noticeExist.Desc = notice.Desc;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            NoticeBoard notice = _context.noticeBoards.FirstOrDefault(x => x.Id == id);
            if (notice == null)
            {
                return NotFound();
            }
            return View(notice);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(NoticeBoard notice)
        {
            NoticeBoard existNotice = _context.noticeBoards.FirstOrDefault(x => x.Id == notice.Id);
            if (existNotice==null)
            {
                return NotFound();
            }
           
            _context.Remove(existNotice);
            _context.SaveChanges();
       
            return RedirectToAction("index");

        }


    }
}
