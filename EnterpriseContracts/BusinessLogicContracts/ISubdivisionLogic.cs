using EnterpriseContracts.BindingModels;
using EnterpriseContracts.ViewModels;

namespace EnterpriseContracts.BusinessLogicContracts;

public interface ISubdivisionLogic
{
    List<SubdivisionViewModel?> Read(SubdivisionBindingModel model);
    void CreateOrUpdate(SubdivisionBindingModel model);
    void Delete(SubdivisionBindingModel model);
}