using Application.ViewModel;
using Infra.CrossCutting;

namespace Application.Service;

public interface ITaskApplicationService : IDisposable
{
    Task<bool> Add(InputTaskViewModel domainObject);

    Task<ResponseService<bool>> Delete(Guid id);

    Task<List<TaskViewModel>> GetAll();

    Task<ResponseService<bool>> UpdateTask(Guid id, InputTaskViewModel domainObject);

    Task<InputTaskViewModel?> GetById(Guid id);

}
