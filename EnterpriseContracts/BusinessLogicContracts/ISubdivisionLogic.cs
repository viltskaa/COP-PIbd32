using EnterpriseContracts.BindingModels;
using EnterpriseContracts.ViewModels;

namespace EnterpriseContracts.BusinessLogicContracts;

public interface ISubdivisionLogic
{
    List<SubdivisionViewModel> Read(SubdivisionBindingModel model);
    void CreateOrUpdate(SubdivisionBindingModel model);
    bool Delete(SubdivisionBindingModel model);
}