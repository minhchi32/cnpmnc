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
                Name = "Ca 1",
                StartTime = new TimeSpan(6, 45, 0),
                EndTime = new TimeSpan(9, 15, 0)
            },
            new SchoolShift
            {
                Id = 2,
                Name = "Ca 2",
                StartTime = new TimeSpan(9, 30, 0),
                EndTime = new TimeSpan(12, 0, 0)
            },
            new SchoolShift
            {
                Id = 3,
                Name = "Ca 3",
                StartTime = new TimeSpan(12, 45, 0),
                EndTime = new TimeSpan(12, 15, 0)
            },
            new SchoolShift
            {
                Id = 4,
                Name = "Ca 4",
                StartTime = new TimeSpan(15, 30, 0),
                EndTime = new TimeSpan(18, 0, 0)
            },
            new SchoolShift
            {
                Id = 5,
                Name = "Ca 5",
                StartTime = new TimeSpan(18, 15, 0),
                EndTime = new TimeSpan(21, 45, 0)
            }
        );
    }
}