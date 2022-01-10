using EduhomeTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.ViewModels
{
    public class HomeViewModel
    {
        public List<Course> Courses { get; set; }
        public List<NoticeBoard> noticeBoards { get; set; }
    }
}
