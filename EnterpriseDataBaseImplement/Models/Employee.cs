using EnterpriseContracts.BindingModels;
using EnterpriseContracts.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace EnterpriseDataBaseImplement.Models;

public class Employee
{
    public int Id { get; set; }
    public string Fio { get; set; } = string.Empty;
    public int Experience { get; set; }
    public string Posts { get; set; } = string.Empty;
    public string Subdivision { get; set; } = string.Empty;

    public static Employee? Create(EmployeeBindingModel? model)
    {
        if (model == null) return null;
        return new()
        {
            Fio = model.Fio,
            Experience = model.Experience,
            Posts = model.Posts,
            Subdivision = model.Subdivision
        };
    }

    public static Employee Create(EmployeeViewModel model)
    {
        return new Employee
        {
            Id = model.Id,
            Fio = model.Fio,
            Experience = model.Experience,
            Posts = model.Posts,
            Subdivision = model.Subdivision
        };
    }

    public void Update(EmployeeBindingModel? model)
    {
        if (model == null) return;
        Posts = model.Posts;
        Subdivision = model.Subdivision;
    }

    public EmployeeViewModel GetViewModel => new()
    {
        Id = Id,
        Fio = Fio,
        Experience = Experience,
        Subdivision = Subdivision,
        Posts = Posts,
    };
}