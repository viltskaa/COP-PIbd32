using EmployeesDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesDatabaseImplement
{
    public class EmployeesDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-V0ON61E\SQLEXPRESS;Initial Catalog=DatabaseEmployees;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Employee> Employees { set; get; }

        public virtual DbSet<Post> Posts { set; get; }
    }
}