namespace Domain.Core;

public interface IDomainTable : IDomainView, IDisposable
{
    Guid Id { get; set; }
}
