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
        builder.Property(b => b.Id).UseIdentityColumn();
        builder.Property(b => b.Name).IsRequired();
        builder.Property(b => b.Content).IsRequired();
        builder.Property(b => b.Detail).IsRequired();
        builder.Property(b => b.StartDate).IsRequired();
        builder.Property(b => b.EndDate).IsRequired();
        builder.Property(b => b.StudyConditions).IsRequired();
        builder.Property(b => b.Tuition).IsRequired();
        builder.Property(b => b.StudyConditions).IsRequired();
        builder.Property(b => b.IsDeleted);
    }
}