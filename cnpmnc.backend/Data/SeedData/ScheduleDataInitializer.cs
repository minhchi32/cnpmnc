using cnpmnc.backend.Models;
using Microsoft.EntityFrameworkCore;

namespace cnpmnc.backend.SeedData;

public static class ScheduleDataInitializer
{
    public static void SeedScheduleData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Schedule>().HasData(
            new Schedule
            {
                Id = 1,
                GradeId = 1,
                ClassroomId = 1,
                SchoolShiftId = 1
            }
        );
    }
}