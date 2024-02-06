using Domain.Core;

namespace Domain.Model;

public interface ITaskDomain : IDomainTable
{
    string Title { get; set; }

    string Description { get; set; }

    bool Completed { get; set; }
}
