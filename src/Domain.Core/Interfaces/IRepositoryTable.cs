namespace Domain.Core;

public interface IRepositoryTable<domainTableObject> : IRepositoryView<domainTableObject> where domainTableObject : class, IDomainTable, IDisposable
{
    Task<bool> Add(domainTableObject domainObject);

    Task<bool> Update(domainTableObject domainObject);

    Task<bool> Delete(domainTableObject domainObject);

    Task<domainTableObject?> GetById(Guid id);
}
