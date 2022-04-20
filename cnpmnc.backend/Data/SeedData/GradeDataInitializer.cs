using cnpmnc.backend.Models;
using Microsoft.EntityFrameworkCore;

namespace cnpmnc.backend.SeedData;

public static class GradeDataInitializer
{
    public static void SeedGradeData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Grade>().HasData(
            new Grade
            {
                Id = 1,
                Name = "Đồ án 1 - 1",
                CourseId = 1,
            },

            new Grade
            {
                Id = 2,
                Name = "Đồ án 1 - 2",
                CourseId = 1,
                
            }
        );
    }
}