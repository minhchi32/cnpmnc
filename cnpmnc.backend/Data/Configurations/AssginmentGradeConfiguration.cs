using cnpmnc.backend.Models;
using cnpmnc.shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cnpmnc.backend.Configurations;

public class AssignmentGradeConfiguration : IEntityTypeConfiguration<AssignmentGrade>
{
    public void Configure(EntityTypeBuilder<AssignmentGrade> builder)
    {
        builder.ToTable("AssignmentGrades");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).UseMySqlIdentityColumn();
        builder.Property(b => b.CourseId).IsRequired();
        builder.HasOne(c => c.Course).WithMany(x => x.AssignmentGrades).HasForeignKey(x => x.CourseId);
        builder.Property(b => b.AssignToTeacherId).IsRequired();
        builder.HasOne(c => c.Teacher).WithMany(x => x.AssignmentGrades).HasForeignKey(x => x.AssignToTeacherId);
        builder.Property(b => b.Note).HasDefaultValue("");
        builder.Property(b => b.State).HasDefaultValue(AssignmentGradeStateEnumDto.WaitingForAcceptance).IsRequired();
        builder.Property(b => b.Total).HasDefaultValue(40);
        builder.Property(b => b.AssignDate).IsRequired();
        builder.Property(b => b.Semester).IsRequired();
    }
}