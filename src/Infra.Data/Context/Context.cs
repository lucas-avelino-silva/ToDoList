using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Domain.Model;

namespace Infra.Data;

public class Context : DbContext, IDisposable
{
    ~Context() => Dispose();

    public override void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public Context(DbContextOptions options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
    }

    DbSet<TaskDomain> Task { get; set; }

    public async Task<bool> Save()
    {
        var save = await SaveChangesAsync() > 0;

        ChangeTracker.Clear();

        return save;
    }
}
