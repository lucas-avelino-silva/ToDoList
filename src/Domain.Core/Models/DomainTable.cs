namespace Domain.Core.Models;

public class DomainTable : IDomainTable
{
    ~DomainTable() => Dispose();

    public virtual void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public DomainTable()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
}
