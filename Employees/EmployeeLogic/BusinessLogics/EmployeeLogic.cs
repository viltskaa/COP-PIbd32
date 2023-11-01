using EmployeesContracts.BindingModels;
using EmployeesContracts.BusinessLogicsContracts;
using EmployeesContracts.StorageContracts;
using EmployeesContracts.ViewModels;
using EmployeesDatabaseImplement.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLogic.BusinessLogics
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IEmployeeStorage _employeeStorage;

        public EmployeeLogic(IEmployeeStorage employeeStorage)
        {
            _employeeStorage = employeeStorage;
        }

        public EmployeeLogic()
        {
            _employeeStorage = new EmployeeStorage();
        }

        public void CreateOrUpdate(EmployeeBindingModel model)
        {
            var element = _employeeStorage.GetElement(
               new EmployeeBindingModel
               {
                   Autobiography = model.Autobiography,
                   Name = model.Name,
                   Post = model.Post,
                   Upgrade = model.Upgrade
               });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Сотрудник с таким именем уже существует");
            }
            if (model.Id.HasValue)
            {
                _employeeStorage.Update(model);
            }
            else
            {
                _employeeStorage.Insert(model);
            }
        }

        public void Delete(EmployeeBindingModel model)
        {
            var element = _employeeStorage.GetElement(new EmployeeBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Сотрудник не найден");
            }
            _employeeStorage.Delete(model);
        }

        public List<EmployeeViewModel> Read(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return _employeeStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<EmployeeViewModel> { _employeeStorage.GetElement(model) };
            }
            return _employeeStorage.GetFilteredList(model);
        }
    }
}
