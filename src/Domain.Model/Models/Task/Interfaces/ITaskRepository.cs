namespace Domain.Model;

public interface ITaskRepository : IDisposable
{
    Task<bool> Add(TaskDomain domainObject);

    Task<bool> Update(TaskDomain domainObject);

    Task<bool> Delete(TaskDomain domainObject);

    Task<TaskDomain?> GetById(Guid id);

    Task<List<TaskDomain>> GetAll();
}
