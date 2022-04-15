using cnpmnc.backend.Models;
using Microsoft.EntityFrameworkCore;

namespace cnpmnc.backend.SeedData;

public static class TeacherGradeDataInitializer
{
    public static void SeedTeacherGradeData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TeacherGrade>().HasData(
            new TeacherGrade
            {
                GradeId = 1,
                TeacherId = 2,
            }
        );
    }
}