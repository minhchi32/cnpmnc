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
                Name = "Andora",
                CourseId = 1,
            }
        );
    }
}