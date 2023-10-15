using EmployeesContracts.BindingModels;
using EmployeesContracts.StorageContracts;
using EmployeesContracts.ViewModels;
using EmployeesDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesDatabaseImplement.Implements
{
    public class EmployeeStorage : IEmployeeStorage
    {
        public void Delete(EmployeeBindingModel model)
        {
            var context = new EmployeesDatabase();
            var employee = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Сотрудник не найден");
            }
        }

        public EmployeeViewModel GetElement(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new EmployeesDatabase();
            var employee = context.Employees
                    .ToList()
                    .FirstOrDefault(rec => rec.Id == model.Id);
            return employee != null ? CreateModel(employee) : null;
        }

        public List<EmployeeViewModel> GetFilteredList(EmployeeBindingModel model)
        {
            var context = new EmployeesDatabase();
            return context.Employees
                .Where(employee => employee.Name.Contains(model.Name) && employee.Post.Contains(model.Post))
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public List<EmployeeViewModel> GetFullList()
        {
            using (var context = new EmployeesDatabase())
            {
                return context.Employees
                .ToList()
                .Select(CreateModel)
                .ToList();
            }
        }

        public void Insert(EmployeeBindingModel model)
        {
            var context = new EmployeesDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                context.Employees.Add(CreateModel(model, new Employee()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(EmployeeBindingModel model)
        {
            var context = new EmployeesDatabase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                var employee = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);
                if (employee == null)
                {
                    throw new Exception("Сотрудник не найден");
                }
                CreateModel(model, employee);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private static Employee CreateModel(EmployeeBindingModel model, Employee employee)
        {
            employee.Upgrade = (DateTime)model.Upgrade;
            employee.Name = model.Name;
            employee.Post = model.Post;
            employee.Autobiography = model.Autobiography;

            return employee;
        }

        private EmployeeViewModel CreateModel(Employee employee)
        {
            return new EmployeeViewModel
            {
                Id = employee.Id,
                Upgrade = employee.Upgrade,
                Name = employee.Name,
                Post = employee.Post,
                Autobiography = employee.Autobiography
            };
        }
    }
}
