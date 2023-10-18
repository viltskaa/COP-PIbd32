using EnterpriseContracts.BindingModels;
using EnterpriseContracts.BusinessLogicContracts;
using EnterpriseContracts.StorageContracts;
using EnterpriseContracts.ViewModels;

namespace EnterpriseBusinessLogic.BusinessLogics;

public class EmployeeLogic : IEmployeeLogic
{
    private readonly IEmployeeStorage _empStorage;

    public EmployeeLogic(IEmployeeStorage empStorage)
    {
        _empStorage = empStorage;
    }
    
    public List<EmployeeViewModel> Read(EmployeeBindingModel? model)
    {
        if (model == null)
            return _empStorage.GetFullList();
        return model.Id.HasValue 
            ? new List<EmployeeViewModel> { _empStorage.GetElement(model) } 
            : _empStorage.GetFilteredList(model);
    }

    public void CreateOrUpdate(EmployeeBindingModel model)
    {
        var element = _empStorage.GetElement(new EmployeeBindingModel
        {
                Id = model.Id
        });
        if (element != null)
            _empStorage.Update(model);
        else
            _empStorage.Insert(model);
    }

    public void Delete(EmployeeBindingModel model)
    {
        var element = _empStorage.GetElement(new EmployeeBindingModel { Id = model.Id });
        if (element == null)
            throw new Exception("Id don't exists");
        _empStorage.Delete(model);
    }
}