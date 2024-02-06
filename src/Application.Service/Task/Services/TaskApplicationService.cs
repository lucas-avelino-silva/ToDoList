using Application.ViewModel;
using AutoMapper;
using Domain.Model;
using Infra.CrossCutting;

namespace Application.Service;

public class TaskApplicationService : ITaskApplicationService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public TaskApplicationService(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    ~TaskApplicationService() => Dispose();

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task<List<TaskViewModel>> GetAll()
    {
        return _mapper.Map<List<TaskViewModel>>(await _taskRepository.GetAll());
    }

    public async Task<bool> Add(InputTaskViewModel domainObject)
    {
        return await _taskRepository.Add(_mapper.Map<TaskDomain>(domainObject));
    }

    public async Task<ResponseService<bool>> Delete(Guid id)
    {
        var response = new ResponseService<bool>();

        var taskTemp = await _taskRepository.GetById(id);

        if (taskTemp == null)
        {
            response.AddInformation("Tarefa não localizada para deletar.");

            return response;
        }

        response.Content = await _taskRepository.Delete(_mapper.Map<TaskDomain>(taskTemp));

        if (!response.Content)
        {
            response.AddInformation("Não foi possível excluir a tarefa.");
        }

        return response;
    }

    public async Task<ResponseService<bool>> UpdateTask(Guid id, InputTaskViewModel domainObject)
    {
        var response = new ResponseService<bool>();

        var taskTemp = await _taskRepository.GetById(id);

        if(taskTemp == null)
        {
            response.AddInformation("Tarefa não localizada para atualizar.");

            return response;
        }

        taskTemp.UpdateData(domainObject.Title!, domainObject.Description!, (bool)domainObject.Completed!);
  
        response.Content = await _taskRepository.Update(_mapper.Map<TaskDomain>(taskTemp));

        return response;
    }

    public async Task<InputTaskViewModel?> GetById(Guid id)
    {
        return _mapper.Map<InputTaskViewModel>(await _taskRepository.GetById(id));
    }

}
