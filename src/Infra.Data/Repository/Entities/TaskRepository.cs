using Domain.Model;

namespace Infra.Data.Repository;

public class TaskRepository : RepositoryTable<TaskDomain>, ITaskRepository
{
    ~TaskRepository() => Dispose();

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public TaskRepository(Context context) : base(context)
    {
    }
}
