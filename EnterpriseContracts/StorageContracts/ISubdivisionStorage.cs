using EnterpriseContracts.BindingModels;
using EnterpriseContracts.ViewModels;

namespace EnterpriseContracts.StorageContracts;

public interface ISubdivisionStorage
{
    List<SubdivisionViewModel?> GetFullList();
    List<SubdivisionViewModel?> GetFilteredList(SubdivisionBindingModel model);
    SubdivisionViewModel? GetElement(SubdivisionBindingModel? model);
    void Insert(SubdivisionBindingModel model);
    void Update(SubdivisionBindingModel model);
    void Delete(SubdivisionBindingModel model);
}