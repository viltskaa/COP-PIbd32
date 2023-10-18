namespace EnterpriseContracts.ViewModels;

public class EmployeeViewModel
{
    public int Id { get; set; }
    public string Fio { get; set; } = string.Empty;
    public int Experience { get; set; }
    public string Subdivision { get; set; } = string.Empty;
    public string Posts { get; set; } = string.Empty;
}