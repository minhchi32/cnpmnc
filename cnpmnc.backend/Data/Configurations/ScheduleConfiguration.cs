using cnpmnc.backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cnpmnc.backend.Configurations;

public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder.ToTable("Schedules");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).UseMySqlIdentityColumn();
        builder.Property(b => b.AssignmentGradeId).IsRequired();
        builder.HasOne(c => c.AssignmentGrade).WithMany(x => x.Schedules).HasForeignKey(x => x.AssignmentGradeId);
        builder.Property(b => b.ClassroomId).IsRequired();
        builder.HasOne(c => c.Classroom).WithMany(x => x.Schedules).HasForeignKey(x => x.ClassroomId);
        builder.Property(b => b.SchoolShiftId).IsRequired();
        builder.HasOne(c => c.SchoolShift).WithMany(x => x.Schedules).HasForeignKey(x => x.SchoolShiftId);
        builder.Property(b => b.StartDate).IsRequired();
        builder.Property(b => b.EndDate).IsRequired();
    }
}