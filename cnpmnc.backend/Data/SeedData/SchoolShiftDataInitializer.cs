using cnpmnc.backend.Models;
using Microsoft.EntityFrameworkCore;

namespace cnpmnc.backend.SeedData;

public static class SchoolShiftDataInitializer
{
    public static void SeedSchoolShiftData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SchoolShift>().HasData(
            new SchoolShift
            {
                Id = 1,
                Name = "Andora",
                ScheduleId = 1,
            }
        );
    }
}