using EnterpriseContracts.BindingModels;
using EnterpriseContracts.StorageContracts;
using EnterpriseContracts.ViewModels;
using EnterpriseDataBaseImplement.Models;

namespace EnterpriseDataBaseImplement.Implements;

public class EmployeeStorage : IEmployeeStorage
{
    public List<EmployeeViewModel> GetFullList()
    {
        var context = new EnterpriseDataBase();
        return context.Employees
            .ToList()
            .Select(x => x.GetViewModel)
            .ToList();
    }

    public List<EmployeeViewModel> GetFilteredList(EmployeeBindingModel model)
    {
        var context = new EnterpriseDataBase();
        if (!model.ExperienceStep.HasValue) return new();
        return context.Employees
            .Where(x => model.ExperienceStep.Value.Item1 <= x.Experience && 
                        model.ExperienceStep.Value.Item2 >= x.Experience)
            .ToList()
            .Select(x => x.GetViewModel)
            .ToList();
    }

    public EmployeeViewModel? GetElement(EmployeeBindingModel model)
    {
        if (model == null) return null;
        using var context = new EnterpriseDataBase();
        var x = context.Employees
            .ToList()
            .FirstOrDefault(rec => rec.Id == model.Id);
        return x?.GetViewModel;
    }

    public void Insert(EmployeeBindingModel model)
    {
        var context = new EnterpriseDataBase();
        var transaction = context.Database.BeginTransaction();
        try
        {
            var x = Employee.Create(model);
            context.Employees.Add(x);
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
            var x = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);
            if (x == null)
                throw new Exception("Not found");
            x.Update(model);
            context.SaveChanges();
            transaction.Commit();
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
    }

    public void Delete(EmployeeBindingModel model)
    {
        var context = new EnterpriseDataBase();
        var x = context.Employees.FirstOrDefault(rec => rec.Id == model.Id);
        if (x != null)
        {
            context.Employees.Remove(x);
            context.SaveChanges();
        }
        else
            throw new Exception("Id isn't exists");
    }
}