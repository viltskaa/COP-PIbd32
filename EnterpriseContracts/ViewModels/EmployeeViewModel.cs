namespace EnterpriseContracts.ViewModels;

public class EmployeeViewModel
{
    public int? Id { get; set; }
    public string? Fio { get; set; }
    public int? Experience { get; set; }
    public SubdivisionViewModel? Subdivision { get; set; }
    public List<string>? Posts { get; set; }
}