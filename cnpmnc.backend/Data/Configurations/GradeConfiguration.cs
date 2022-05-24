using cnpmnc.backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cnpmnc.backend.Configurations;

public class GradeConfiguration : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
        builder.ToTable("Grades");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).UseMySqlIdentityColumn();
        builder.Property(b => b.Name).IsRequired();
        builder.Property(b=>b.CourseId).IsRequired();
        builder.HasOne(c => c.Course).WithMany(x => x.Grades).HasForeignKey(x => x.CourseId);
        builder.Property(b => b.NumberOfSessions).IsRequired();
        builder.Property(b => b.Total).IsRequired();
        builder.Property(b => b.TeacherId).IsRequired();
        builder.HasOne(c => c.Teacher).WithMany(x => x.Grades).HasForeignKey(x => x.TeacherId);
    }
}