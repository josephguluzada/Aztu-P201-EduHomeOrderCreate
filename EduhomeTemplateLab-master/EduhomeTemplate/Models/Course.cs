using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string Language { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
