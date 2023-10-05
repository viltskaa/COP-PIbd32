using EnterpriseContracts.BindingModels;
using EnterpriseContracts.StorageContracts;
using EnterpriseContracts.ViewModels;
using EnterpriseDataBaseImplement.Models;

namespace EnterpriseDataBaseImplement.Implements;

public class SubdivisionStorage : ISubdivisionStorage
{
    public List<SubdivisionViewModel?> GetFullList()
    {
        throw new NotImplementedException();
    }

    public List<SubdivisionViewModel?> GetFilteredList(SubdivisionBindingModel model)
    {
        var context = new EnterpriseDataBase();
        return context.Subdivisions
            .Where(emp => model.Name != null && emp.Name.Contains(model.Name))
            .ToList()
            .Select(CreateModel)
            .ToList();
    }

    public SubdivisionViewModel? GetElement(SubdivisionBindingModel? model)
    {
        if (model == null)
        {
            return null;
        }
        using var context = new EnterpriseDataBase();
        var emp = context.Subdivisions
            .ToList()
            .FirstOrDefault(rec => rec.Name == model.Name || rec.Id == model.Id);
        return emp != null ? CreateModel(emp) : null;
    }

    public void Insert(SubdivisionBindingModel model)
    {
        var context = new EnterpriseDataBase();
        var transaction = context.Database.BeginTransaction();
        try {
            var ent = CreateModel(model);
            context.Subdivisions.Add(ent);
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
            var emp = context.Subdivisions.FirstOrDefault(rec => rec.Id == model.Id);
            if (emp == null)
                throw new Exception("Not found");
            if (model.Name != null)
                emp.Name = model.Name;
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
        var emp = context.Subdivisions.FirstOrDefault(rec => rec.Id == model.Id);
        if (emp != null)
        {
            context.Subdivisions.Remove(emp);
            context.SaveChanges();
        }
        else
            throw new Exception("Id isn't exists");
    }

    private static SubdivisionViewModel? CreateModel(Subdivision model)
    {
        return new SubdivisionViewModel
        {
            Id = model.Id,
            Name = model.Name
        };
    }

    private static Subdivision CreateModel(SubdivisionBindingModel model)
    {
        if (model.Name != null)
            return new Subdivision
            {
                Id = model.Id,
                Name = model.Name
            };
    }
}