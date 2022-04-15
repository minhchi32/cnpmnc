using cnpmnc.backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cnpmnc.backend.Configurations;

public class TeacherGradeConfiguration : IEntityTypeConfiguration<TeacherGrade>
{
    public void Configure(EntityTypeBuilder<TeacherGrade> builder)
    {
        builder.ToTable("TeacherGrades");
        builder.HasKey(b => b.GradeId);
        builder.HasKey(b => b.TeacherId);
        builder.HasOne(b=>b.Grade).WithMany(b=>b.TeacherGrades).HasForeignKey(b=>b.GradeId);
        builder.HasOne(b => b.Teacher).WithMany(b => b.TeacherGrades).HasForeignKey(b => b.TeacherId);
    }
}