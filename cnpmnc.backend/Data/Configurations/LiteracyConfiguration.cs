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
        builder.Property(b => b.Id).UseMySqlIdentityColumn();
        builder.Property(b => b.Name).IsRequired();
    }
}