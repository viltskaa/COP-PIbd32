using EnterpriseDataBaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseDataBaseImplement
{
    public class EnterpriseDataBase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-VG5USAH\SQLEXPRESS;Initial Catalog=EnterpriseDatabase;Integrated Security=True;MultipleActiveResultSets=True; TrustServerCertificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Employee> Employees { set; get; }

        public virtual DbSet<Skill> Skills { set; get; }
    }
}
