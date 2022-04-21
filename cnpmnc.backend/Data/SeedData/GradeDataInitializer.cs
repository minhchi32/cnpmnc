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
                Name = "ReactJS - 1",
                CourseId = 1,
                NumberOfSessions = 10,
                TeacherId = 2,
            },
            new Grade
            {
                Id = 2,
                Name = "ReactJS - 2",
                NumberOfSessions = 10,
                TeacherId = 2,
                CourseId = 1,
            },
            new Grade
            {
                Id = 3,
                Name = "NodeJS - 1",
                NumberOfSessions = 10,
                TeacherId = 3,
                CourseId = 2,
            },
            new Grade
            {
                Id = 4,
                Name = "NodeJS - 2",
                NumberOfSessions = 10,
                TeacherId = 3,
                CourseId = 2,
            },
            new Grade
            {
                Id = 5,
                Name = "ASP.NET - 1",
                NumberOfSessions = 10,
                TeacherId = 4,
                CourseId = 3,
            },
            new Grade
            {
                Id = 6,
                Name = "ASP.NET - 2",
                NumberOfSessions = 10,
                TeacherId = 4,
                CourseId = 3,
            },
            new Grade
            {
                Id = 7,
                Name = "C# - 1",
                NumberOfSessions = 10,
                TeacherId = 2,
                CourseId = 4,
            },
            new Grade
            {
                Id = 8,
                Name = "C# - 2",
                NumberOfSessions = 10,
                TeacherId = 2,
                CourseId = 4,
            },
            new Grade
            {
                Id = 9,
                Name = "JavaScript - 1",
                NumberOfSessions = 10,
                TeacherId = 3,
                CourseId = 5,
            },
            new Grade
            {
                Id = 10,
                Name = "JavaScript - 2",
                NumberOfSessions = 10,
                TeacherId = 3,
                CourseId = 5,
            },
            new Grade
            {
                Id = 11,
                Name = "Python - 1",
                NumberOfSessions = 10,
                TeacherId = 4,
                CourseId = 6,
            },
            new Grade
            {
                Id = 12,
                Name = "Python - 2",
                NumberOfSessions = 10,
                TeacherId = 4,
                CourseId = 6,
            },
            new Grade
            {
                Id = 13,
                Name = "React Native - 1",
                NumberOfSessions = 10,
                TeacherId = 2,
                CourseId = 7,
            },
            new Grade
            {
                Id = 14,
                TeacherId = 2,
                NumberOfSessions = 10,
                Name = "React Native - 2",
                CourseId = 7,
            },
            new Grade
            {
                Id = 15,
                Name = "Golang - 1",
                NumberOfSessions = 10,
                TeacherId = 3,
                CourseId = 8,
            },
            new Grade
            {
                Id = 16,
                Name = "Golang - 2",
                NumberOfSessions = 10,
                TeacherId = 3,
                CourseId = 8,
            },
            new Grade
            {
                Id = 17,
                Name = "VueJS - 1",
                NumberOfSessions = 10,
                TeacherId = 4,
                CourseId = 9,
            },
            new Grade
            {
                Id = 18,
                Name = "VueJS - 2",
                NumberOfSessions = 10,
                TeacherId = 4,
                CourseId = 9,
            },
            new Grade
            {
                Id = 19,
                Name = "Angular - 1",
                NumberOfSessions = 10,
                TeacherId = 2,
                CourseId = 10,
            },
            new Grade
            {
                Id = 20,
                Name = "Angular - 2",
                NumberOfSessions = 10,
                TeacherId = 2,
                CourseId = 10,
            },
            new Grade
            {
                Id = 21,
                Name = "Flutter - 1",
                NumberOfSessions = 10,
                TeacherId = 3,
                CourseId = 11,
            },
            new Grade
            {
                Id = 22,
                Name = "Flutter - 1",
                NumberOfSessions = 10,
                TeacherId = 3,
                CourseId = 11,
            },
            new Grade
            {
                Id = 23,
                Name = "Java - 1",
                NumberOfSessions = 10,
                TeacherId = 4,
                CourseId = 12,
            },
            new Grade
            {
                Id = 24,
                Name = "Java - 2",
                NumberOfSessions = 10,
                TeacherId = 4,
                CourseId = 12,
            },
            new Grade
            {
                Id = 25,
                Name = "C++ - 1",
                NumberOfSessions = 10,
                TeacherId = 2,
                CourseId = 13,
            },
            new Grade
            {
                Id = 26,
                Name = "C++ - 2",
                NumberOfSessions = 10,
                TeacherId = 2,
                CourseId = 13,
            },
            new Grade
            {
                Id = 27,
                Name = "C - 1",
                NumberOfSessions = 10,
                TeacherId = 3,
                CourseId = 14,
            },
            new Grade
            {
                Id = 28,
                Name = "C - 2",
                NumberOfSessions = 10,
                TeacherId = 3,
                CourseId = 14,
            },
            new Grade
            {
                Id = 29,
                Name = "C# - 1",
                NumberOfSessions = 10,
                TeacherId = 4,
                CourseId = 15,
            },
            new Grade
            {
                Id = 30,
                Name = "C# - 2",
                NumberOfSessions = 10,
                TeacherId = 4,
                CourseId = 15,
            }
        );
    }
}