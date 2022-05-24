using cnpmnc.backend.Models;
using cnpmnc.shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cnpmnc.backend.Configurations;

public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder.ToTable("Assignments");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).UseMySqlIdentityColumn();
        builder.Property(b => b.CourseId).IsRequired();
        builder.HasOne(c => c.Course).WithMany(x => x.Assignments).HasForeignKey(x => x.CourseId);
        builder.Property(b => b.AssignToTeacherId).IsRequired();
        builder.HasOne(c => c.Teacher).WithMany(x => x.Assignments).HasForeignKey(x => x.AssignToTeacherId);
        builder.Property(b => b.State).HasDefaultValue(AssignmentStateEnumDto.WaitingForAcceptance).IsRequired();
        builder.Property(b => b.AssignDate).IsRequired();
        builder.Property(b => b.Note);
        builder.Property(b => b.IsDeleted);
    }
}