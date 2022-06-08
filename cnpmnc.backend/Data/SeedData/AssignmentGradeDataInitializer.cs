using cnpmnc.backend.Models;
using cnpmnc.shared.Enums;
using Microsoft.EntityFrameworkCore;

namespace cnpmnc.backend.SeedData;

public static class AssignmentGradeDataInitializer
{
    public static void SeedAssignmentGradeData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssignmentGrade>().HasData(
            new AssignmentGrade
            {
                Id = 1,
                CourseId = 1,
                AssignToTeacherId = 2,
                State = AssignmentGradeStateEnumDto.Accepted,
                Total = 40,
                AssignDate = new DateTime(2021, 2, 2),
                Semester = SemesterEnumDto.Semester2,
            },
            new AssignmentGrade
            {
                Id = 2,
                CourseId = 1,
                AssignToTeacherId = 2,
                State = AssignmentGradeStateEnumDto.Accepted,
                Total = 40,
                AssignDate = new DateTime(2021, 2, 3),
                Semester = SemesterEnumDto.Semester2,
            },
            new AssignmentGrade
            {
                Id = 3,
                CourseId = 2,
                AssignToTeacherId = 2,
                State = AssignmentGradeStateEnumDto.Accepted,
                Total = 40,
                AssignDate = new DateTime(2021, 2, 3),
                Semester = SemesterEnumDto.Semester2,
            },
            new AssignmentGrade
            {
                Id = 4,
                CourseId = 4,
                AssignToTeacherId = 3,
                State = AssignmentGradeStateEnumDto.Accepted,
                Total = 40,
                AssignDate = new DateTime(2021, 5, 2),
                Semester = SemesterEnumDto.Semester3,
            }
        );
    }
}