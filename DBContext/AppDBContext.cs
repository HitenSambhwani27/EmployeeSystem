//using December_Project.Dtos;
using December_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace December_Project.DBContext
{
    public class AppDBContext:IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Guard> Guard { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}
