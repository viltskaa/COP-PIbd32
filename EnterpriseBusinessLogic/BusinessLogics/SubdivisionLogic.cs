using EnterpriseContracts.BindingModels;
using EnterpriseContracts.BusinessLogicContracts;
using EnterpriseContracts.StorageContracts;
using EnterpriseContracts.ViewModels;

namespace EnterpriseBusinessLogic.BusinessLogics;

public class SubdivisionLogic : ISubdivisionLogic
{
    private readonly ISubdivisionStorage _subdivisionStorage;

    public SubdivisionLogic(ISubdivisionStorage subdivisionStorage)
    {
        _subdivisionStorage = subdivisionStorage;
    }
    
    public List<SubdivisionViewModel> Read(SubdivisionBindingModel? model)
    {
        if (model == null)
            return _subdivisionStorage.GetFullList();
        return model.Id != 0 ? 
            new List<SubdivisionViewModel> { _subdivisionStorage.GetElement(model) } : 
            _subdivisionStorage.GetFilteredList(model);
    }

    public void CreateOrUpdate(SubdivisionBindingModel model)
    {
        var element = _subdivisionStorage.GetElement(new SubdivisionBindingModel
        {
            Name = model.Name
        });
        
        if (element != null && element.Id != model.Id)
            throw new Exception("This name is exists!");
        if (model.Id != 0)
            _subdivisionStorage.Update(model);
        else
            _subdivisionStorage.Insert(model);
    }

    public bool Delete(SubdivisionBindingModel model) 
    {
        var element = _subdivisionStorage.GetElement(new SubdivisionBindingModel { Id = model.Id });
        if (element == null)
            return false;
        _subdivisionStorage.Delete(model);
        return true;
    }
}