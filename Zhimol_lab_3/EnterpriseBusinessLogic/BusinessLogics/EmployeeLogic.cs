using EnterpriseContracts.BindingModels;
using EnterpriseContracts.BusinessLogicContracts;
using EnterpriseContracts.StorageContracts;
using EnterpriseContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseBusinessLogic.BusinessLogics
{
    public class EmployeeLogic : IEmployeeLogic
    {
        private readonly IEmployeeStorage _empStorage;

        public EmployeeLogic(IEmployeeStorage empStorage)
        {
            _empStorage = empStorage;
        }

        public void CreateOrUpdate(EmployeeBindingModel model)
        {
            var element = _empStorage.GetElement(
                new EmployeeBindingModel
                {
                    FIO = model.FIO
                });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Сотрудник с таким именем уже существует");
            }
            if (model.Id.HasValue)
            {
                _empStorage.Update(model);
            }
            else
            {
                _empStorage.Insert(model);
            }
        }

        public void Delete(EmployeeBindingModel model)
        {
            var element = _empStorage.GetElement(new EmployeeBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Сотрудник не найден");
            }
            _empStorage.Delete(model);
        }

        public List<EmployeeViewModel> Read(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return _empStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<EmployeeViewModel> { _empStorage.GetElement(model) };
            }
            return _empStorage.GetFilteredList(model);
        }
    }
}
