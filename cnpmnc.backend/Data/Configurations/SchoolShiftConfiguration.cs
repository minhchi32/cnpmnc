using cnpmnc.backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cnpmnc.backend.Configurations;

public class SchoolShiftConfiguration : IEntityTypeConfiguration<SchoolShift>
{
    public void Configure(EntityTypeBuilder<SchoolShift> builder)
    {
        builder.ToTable("SchoolShifts");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).UseIdentityColumn();
        builder.Property(b => b.Name).IsRequired();
        builder.Property(b => b.StartTime).IsRequired();
        builder.Property(b => b.EndTime).IsRequired();
    }
}