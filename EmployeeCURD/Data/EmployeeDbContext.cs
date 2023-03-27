using EmployeeCURD.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCURD.Data
{
    public class EmployeeDbContext:DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
            //use dbcontext options and pass to base class
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
