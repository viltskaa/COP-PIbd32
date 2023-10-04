using System.ComponentModel.DataAnnotations;

namespace EnterpriseDataBaseImplement.Models;

public class Subdivision
{
    [Required] public int Id { get; set; }
    [Required] public string Name { get; set; } = string.Empty;
}