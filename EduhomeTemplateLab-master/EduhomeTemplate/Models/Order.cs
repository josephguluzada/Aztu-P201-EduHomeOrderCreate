using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string Language { get; set; }
        public DateTime CreatedAt { get; set; }


        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
