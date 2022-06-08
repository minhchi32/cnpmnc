using cnpmnc.backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cnpmnc.backend.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).UseMySqlIdentityColumn();
        builder.Property(b => b.Name).IsRequired();
        builder.Property(b => b.Content).HasDefaultValue("").IsRequired();
        builder.Property(b => b.Detail).HasDefaultValue("").IsRequired();
        builder.Property(b => b.StudyConditions).HasDefaultValue("").IsRequired();
        builder.Property(b => b.Tuition).IsRequired();
        builder.Property(b => b.NumberOfLesson).HasDefaultValue(15).IsRequired();
    }
}