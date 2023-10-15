using EmployeesContracts.BindingModels;
using EmployeesContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesContracts.BusinessLogicsContracts
{
    public interface IPostLogic
    {
        List<PostViewModel> Read(PostBindingModel model);
        void CreateOrUpdate(PostBindingModel model);
        void Delete(PostBindingModel model);
    }
}
