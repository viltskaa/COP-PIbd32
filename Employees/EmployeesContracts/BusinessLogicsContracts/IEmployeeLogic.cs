using EmployeesContracts.BindingModels;
using EmployeesContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesContracts.BusinessLogicsContracts
{
    public interface IEmployeeLogic
    {
        List<EmployeeViewModel> Read(EmployeeBindingModel model);
        void CreateOrUpdate(EmployeeBindingModel model);
        void Delete(EmployeeBindingModel model);
    }
}
