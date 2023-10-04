using EnterpriseDataBaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseDataBaseImplement;

public class EnterpriseDataBase : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured == false) {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-QKSH4DCA\SQLEXPRESS;Initial Catalog=EnterpriseDatabase;Integrated Security=True;MultipleActiveResultSets=True;;TrustServerCertificate=True");
        }
        base.OnConfiguring(optionsBuilder);
    }

    public virtual DbSet<Employee> Employees { set; get; }
    public virtual DbSet<Subdivision> Subdivisions { set; get; }
}