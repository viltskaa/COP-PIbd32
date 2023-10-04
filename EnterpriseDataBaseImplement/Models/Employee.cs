using System.ComponentModel.DataAnnotations;

namespace EnterpriseDataBaseImplement.Models;

public class Employee
{
    [Required] public int Id { get; set; }
    [Required] public string Fio { get; set; } = string.Empty;
    [Required] public int Experience { get; set; }
    
    [Required] public Subdivision Subdivision { get; set; }
    [Required] public List<string> Posts { get; set; }
}