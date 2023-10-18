using EnterpriseContracts.BindingModels;
using EnterpriseContracts.StorageContracts;
using EnterpriseContracts.ViewModels;
using EnterpriseDataBaseImplement.Models;

namespace EnterpriseDataBaseImplement.Implements;

public class SubdivisionStorage : ISubdivisionStorage
{
    public List<SubdivisionViewModel> GetFullList()
    {
        var context = new EnterpriseDataBase();
        return context.Subdivisions
            .ToList()
            .Select(x => x.GetViewModel)
            .ToList();
    }

    public List<SubdivisionViewModel> GetFilteredList(SubdivisionBindingModel model)
    {
        var context = new EnterpriseDataBase();
        return context.Subdivisions
            .Where(x => x.Name.Contains(model.Name))
            .ToList()
            .Select(x => x.GetViewModel)
            .ToList();
    }

    public SubdivisionViewModel? GetElement(SubdivisionBindingModel? model)
    {
        if (model == null) return null;
        using var context = new EnterpriseDataBase();
        var x = context.Subdivisions
            .ToList()
            .FirstOrDefault(rec => rec.Name == model.Name || rec.Id == model.Id);
        return x?.GetViewModel;
    }

    public void Insert(SubdivisionBindingModel model)
    {
        var context = new EnterpriseDataBase();
        var transaction = context.Database.BeginTransaction();
        try {
            var x = Subdivision.Create(model);
            context.Subdivisions.Add(x);
            context.SaveChanges();
            transaction.Commit();
        }
        catch {
            transaction.Rollback();
            throw;
        }
    }

    public void Update(SubdivisionBindingModel model)
    {
        var context = new EnterpriseDataBase();
        var transaction = context.Database.BeginTransaction();
        try {
            var x = context.Subdivisions.FirstOrDefault(rec => rec.Id == model.Id);
            if (x == null)
                throw new Exception("Not found");
            x.Update(model);
            context.SaveChanges();
            transaction.Commit();
        }
        catch {
            transaction.Rollback();
            throw;
        }
    }

    public void Delete(SubdivisionBindingModel model)
    {
        var context = new EnterpriseDataBase();
        var x = context.Subdivisions.FirstOrDefault(rec => rec.Id == model.Id);
        if (x != null)
        {
            context.Subdivisions.Remove(x);
            context.SaveChanges();
        }
        else
            throw new Exception("Id isn't exists");
    }
}