using EmployeesContracts.BindingModels;
using EmployeesContracts.BusinessLogicsContracts;
using EmployeesContracts.StorageContracts;
using EmployeesContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLogic.BusinessLogics
{
    public class PostLogic : IPostLogic
    {
        private readonly IPostStorage _postStorage;

        public PostLogic(IPostStorage postStorage)
        {
            _postStorage = postStorage;
        }

        public void CreateOrUpdate(PostBindingModel model)
        {
            var element = _postStorage.GetElement(
               new PostBindingModel
               {
                   Name = model.Name
               });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Такая должность уже существует");
            }
            if (model.Id.HasValue)
            {
                _postStorage.Update(model);
            }
            else
            {
                _postStorage.Insert(model);
            }
        }

        public void Delete(PostBindingModel model)
        {
            var element = _postStorage.GetElement(new PostBindingModel { Id = model.Id });
            if (element == null)
            {
                throw new Exception("Должность не найдена");
            }
            _postStorage.Delete(model);
        }

        public List<PostViewModel> Read(PostBindingModel model)
        {
            if (model == null)
            {
                return _postStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<PostViewModel> { _postStorage.GetElement(model) };
            }
            return _postStorage.GetFilteredList(model);
        }
    }
}
