using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.Models
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<NoticeBoard> noticeBoards { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<AppUser> users { get; set;}
        public DbSet<Order> Orders { get; set; }
    }
}
