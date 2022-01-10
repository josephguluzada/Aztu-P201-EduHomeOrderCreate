using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.ViewModels
{
    public class BasketItemViewModal
    {
        public int CourseId { get; set; }
        public int Count { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Desc { get; set; }
    }
}
