//using EmployeeSystem.Dtos;
using EmployeeSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeSystem.DBContext
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
