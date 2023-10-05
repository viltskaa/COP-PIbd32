using EnterpriseContracts.BindingModels;
using EnterpriseContracts.ViewModels;

namespace EnterpriseContracts.BusinessLogicContracts;

public interface IEmployeeLogic
{
    List<EmployeeViewModel> Read(EmployeeBindingModel model);
    void CreateOrUpdate(EmployeeBindingModel model);
    void Delete(EmployeeBindingModel model);
}