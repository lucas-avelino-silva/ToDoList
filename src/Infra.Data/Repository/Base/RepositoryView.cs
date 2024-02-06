using Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repository;

public class RepositoryView<domainViewObject> : IRepositoryView<domainViewObject> where domainViewObject : class, IDomainView
{
    protected readonly Context _context;

    public RepositoryView(Context context)
    {
        _context = context;
    }

    public async Task<List<domainViewObject>> GetAll()
    {
        return await _context.Set<domainViewObject>().ToListAsync();
    }
}
