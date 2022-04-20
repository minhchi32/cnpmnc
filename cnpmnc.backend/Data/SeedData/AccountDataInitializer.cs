using cnpmnc.backend.Models;
using cnpmnc.shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace cnpmnc.backend.SeedData;

public static class AccountDataInitializer
{
    public static void SeedAccountData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().HasData(
            new Account
            {
                Id = 1,
                Name = "1",
                Username = "admin",
                Password = "1",
                AccountType = AccountType.Admin,
                IdCard = "1",
                PhoneNumber = 1,
                LiteracyId = 1,
                IsDeleted = false,
            },
            new Account
            {
                Id = 2,
                Name = "2",
                Username = "gv1",
                Password = "1",
                AccountType = AccountType.Teacher,
                IdCard = "1",
                PhoneNumber = 1,
                LiteracyId = 2,
                NumberOfHoursInClass = 15,
                ActualNumberOfHoursInClass = 15,
                NumberOfTeachingSessions = 15,
                NumberOfBreaks = 0,
                IsDeleted = false,
            }
        );
    }
}