using Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository;

public class RepositoryTable<domainTableObject> : RepositoryView<domainTableObject>, IRepositoryTable<domainTableObject> where domainTableObject : class, IDomainTable
{
    public RepositoryTable(Context context) : base(context)
    {
    }

    public async Task<bool> Add(domainTableObject domainObject)
    {
        await _context.Set<domainTableObject>().AddAsync(domainObject);

        return await _context.Save();
    }

    public async Task<bool> Delete(domainTableObject domainObject)
    {
        _context.Set<domainTableObject>().Remove(domainObject);

        return await _context.Save();
    }

    public async Task<bool> Update(domainTableObject domainObject)
    {
        _context.Set<domainTableObject>().Update(domainObject);

        return await _context.Save();
    }

    public async Task<domainTableObject?> GetById(Guid id)
    {
        return await _context.Set<domainTableObject>().FirstOrDefaultAsync(x => x.Id == id);
    }
}
