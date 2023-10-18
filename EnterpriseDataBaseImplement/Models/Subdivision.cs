using EnterpriseContracts.BindingModels;
using EnterpriseContracts.ViewModels;

namespace EnterpriseDataBaseImplement.Models;

public class Subdivision
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public static Subdivision? Create(SubdivisionBindingModel? model)
    {
        if (model == null) return null;
        return new()
        {
            Id = model.Id,
            Name = model.Name
        };
    }

    public static Subdivision? Create(SubdivisionViewModel? model)
    {
        if (model == null) return null;
        return new()
        {
            Id = model.Id,
            Name = model.Name
        };
    }

    public void Update(SubdivisionBindingModel? model)
    {
        if (model == null) return;
        if (!string.IsNullOrEmpty(model.Name)) Name = model.Name;
    }

    public SubdivisionViewModel GetViewModel => new()
    {
        Id = Id,
        Name = Name
    };
}