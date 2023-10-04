using EnterpriseContracts.BindingModels;
using EnterpriseContracts.StorageContracts;
using EnterpriseContracts.ViewModels;
using EnterpriseDataBaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseDataBaseImplement.Implements
{
    public class EmployeeStorage : IEmployeeStorage
    {
        public void Delete(EmployeeBindingModel model)
        {
            var context = new EnterpriseDataBase();
            var emp = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);
            if (emp != null)
            {
                context.Employees.Remove(emp);
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
            using var context = new EnterpriseDataBase();
            var emp = context.Employees
                    .ToList()
                    .FirstOrDefault(rec => rec.FIO == model.FIO || rec.Id == model.Id);
            return emp != null ? CreateModel(emp) : null;
        }

        public List<EmployeeViewModel> GetFilteredList(EmployeeBindingModel model)
        {
            var context = new EnterpriseDataBase();
            return context.Employees
                .Where(emp => emp.FIO.Contains(model.FIO) && emp.Skill.Contains(model.Skill))
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public List<EmployeeViewModel> GetFullList()
        {
            using (var context = new EnterpriseDataBase())
            {
                return context.Employees
                .ToList()
                .Select(CreateModel)
                .ToList();
            }
        }

        public void Insert(EmployeeBindingModel model)
        {
            var context = new EnterpriseDataBase();
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
            var context = new EnterpriseDataBase();
            var transaction = context.Database.BeginTransaction();
            try
            {
                var emp = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);
                if (emp == null)
                {
                    throw new Exception("Сотрудник не найден");
                }
                CreateModel(model, emp);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private static Employee CreateModel(EmployeeBindingModel model, Employee emp)
        {
            emp.FIO = model.FIO;
            emp.Skill = model.Skill;
            emp.PhoneNumber = model.PhoneNumber;
            emp.Photo = model.Photo;
            return emp;
        }

        private EmployeeViewModel CreateModel(Employee emp)
        {
            return new EmployeeViewModel
            {
                Id = emp.Id,
                FIO = emp.FIO,
                Photo = emp.Photo,
                PhoneNumber = emp.PhoneNumber,
                Skill = emp.Skill
            };
        }
    }
}
