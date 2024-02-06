using Domain.Core.Models;

namespace Domain.Model;

public class TaskDomain : DomainTable, ITaskDomain
{
    ~TaskDomain() => Dispose();

    public override void Dispose()
    {
        base.Dispose();
        GC.SuppressFinalize(this);
    }

    public TaskDomain(string title, string description, bool completed)
    {
        Title = title;
        Description = description;
        Completed = completed;
    }

    public string Title { get; set; }

    public string Description { get; set; }

    public bool Completed { get; set; }

    public void UpdateData(string title, string description, bool completed)
    {
        Title = title;
        Description = description;
        Completed = completed;
    }
}
