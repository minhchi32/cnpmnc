using cnpmnc.backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cnpmnc.backend.Configurations;

public class LiteracyConfiguration : IEntityTypeConfiguration<Literacy>
{
    public void Configure(EntityTypeBuilder<Literacy> builder)
    {
        builder.ToTable("Literacies");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).UseIdentityColumn();
        builder.Property(b => b.Name).IsRequired();
        builder.Property(b => b.TeacherId).IsRequired();
        builder.HasOne(c => c.Teacher).WithMany(x => x.Literacies).HasForeignKey(x => x.TeacherId);
    }
}