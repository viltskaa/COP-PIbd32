using EmployeesContracts.BindingModels;
using EmployeesContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesContracts.StorageContracts
{
    public interface IPostStorage
    {
        List<PostViewModel> GetFullList();
        List<PostViewModel> GetFilteredList(PostBindingModel model);
        PostViewModel GetElement(PostBindingModel model);

        void Insert(PostBindingModel model);
        void Update(PostBindingModel model);
        void Delete(PostBindingModel model);
    }
}
