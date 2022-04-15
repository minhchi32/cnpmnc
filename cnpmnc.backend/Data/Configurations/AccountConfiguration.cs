using cnpmnc.backend.Models;
using cnpmnc.shared.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace cnpmnc.backend.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).UseIdentityColumn();
        builder.Property(b => b.Name).IsRequired();
        builder.Property(b => b.Username).IsRequired();
        builder.Property(b => b.Password).IsRequired();
        builder.Property(b => b.AccountType).HasDefaultValue(AccountType.Teacher).IsRequired();
        builder.Property(b => b.IdCard).IsRequired();
        builder.Property(b => b.PhoneNumber).IsRequired();
        builder.Property(b => b.NumberOfHoursInClass);
        builder.Property(b => b.ActualNumberOfHoursInClass);
        builder.Property(b => b.NumberOfTeachingSessions);
        builder.Property(b => b.NumberOfBreaks);
    }
}