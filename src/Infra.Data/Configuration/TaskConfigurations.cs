using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Model;

namespace Infra.Data.Configuration;

public class TaskConfigurations : IEntityTypeConfiguration<TaskDomain>
{
    public void Configure(EntityTypeBuilder<TaskDomain> builder)
    {
        builder.ToTable("TB_TASK");

        builder.HasKey(x => x.Id);

        builder.Property(b => b.Id).HasColumnName("ID");

        builder.Property(b => b.Title).HasColumnName("TITLE");

        builder.Property(b => b.Description).HasColumnName("DESCRIPTION");

        builder.Property(b => b.Completed).HasColumnName("COMPLETED");
    }
}
