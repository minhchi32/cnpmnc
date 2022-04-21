using cnpmnc.backend.Models;
using Microsoft.EntityFrameworkCore;

namespace cnpmnc.backend.SeedData;

public static class CourseDataInitializer
{
    public static void SeedCourseData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>().HasData(
            new Course
            {
                Id = 1,
                Name = "ReactJS",
                Content = "1",
                Detail = "1",
                StartDate = DateTime.Now.AddMonths(-4),
                EndDate = DateTime.Now.AddMonths(-2),
                StudyConditions = "1",
                Tuition = 4000000,
                IsDeleted = false,
            },
            new Course
            {
                Id = 2,
                Name = "NodeJS",
                Content = "1",
                Detail = "1",
                StartDate = DateTime.Now.AddMonths(1),
                EndDate = DateTime.Now.AddMonths(7),
                StudyConditions = "1",
                Tuition = 4500000,
                IsDeleted = false,
            },
            new Course
            {
                Id = 3,
                Name = "ASP.NET",
                Content = "1",
                Detail = "1",
                StartDate = DateTime.Now.AddMonths(-12),
                EndDate = DateTime.Now.AddMonths(-6),
                StudyConditions = "1",
                Tuition = 3000000,
                IsDeleted = false,
            },
            new Course
            {
                Id = 4,
                Name = "C#",
                Content = "1",
                Detail = "1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(3),
                StudyConditions = "1",
                Tuition = 2000000,
                IsDeleted = false,
            },
            new Course
            {
                Id = 5,
                Name = "JavaScript",
                Content = "1",
                Detail = "1",
                StartDate = DateTime.Now.AddMonths(3),
                EndDate = DateTime.Now.AddMonths(6),
                StudyConditions = "1",
                Tuition = 3500000,
                IsDeleted = false,
            },
            new Course
            {
                Id = 6,
                Name = "Python",
                Content = "1",
                Detail = "1",
                StartDate = DateTime.Now.AddMonths(5),
                EndDate = DateTime.Now.AddMonths(8),
                StudyConditions = "1",
                Tuition = 2500000,
                IsDeleted = false,
            },
            new Course
            {
                Id = 7,
                Name = "React Native",
                Content = "1",
                Detail = "1",
                StartDate = DateTime.Now.AddMonths(6),
                EndDate = DateTime.Now.AddMonths(9),
                StudyConditions = "1",
                Tuition = 5500000,
                IsDeleted = false,
            },
            new Course
            {
                Id = 8,
                Name = "Golang",
                Content = "1",
                Detail = "1",
                StartDate = DateTime.Now.AddMonths(4),
                EndDate = DateTime.Now.AddMonths(7),
                StudyConditions = "1",
                Tuition = 5500000,
                IsDeleted = false,
            },
            new Course
            {
                Id = 9,
                Name = "VueJS",
                Content = "1",
                Detail = "1",
                StartDate = DateTime.Now.AddMonths(1),
                EndDate = DateTime.Now.AddMonths(4),
                StudyConditions = "1",
                Tuition = 5000000,
                IsDeleted = false,
            },
            new Course
            {
                Id = 10,
                Name = "Angular",
                Content = "1",
                Detail = "1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(3),
                StudyConditions = "1",
                Tuition = 6000000,
                IsDeleted = false,
            },
            new Course
            {
                Id = 11,
                Name = "Flutter",
                Content = "1",
                Detail = "1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(3),
                StudyConditions = "1",
                Tuition = 6000000,
                IsDeleted = false,
            },
            new Course
            {
                Id = 12,
                Name = "Java",
                Content = "1",
                Detail = "1",
                StartDate = DateTime.Now.AddMonths(-5),
                EndDate = DateTime.Now.AddMonths(-3),
                StudyConditions = "1",
                Tuition = 1500000,
                IsDeleted = false,
            },
            new Course
            {
                Id = 13,
                Name = "C++",
                Content = "1",
                Detail = "1",
                StartDate = DateTime.Now.AddMonths(-6),
                EndDate = DateTime.Now.AddMonths(-3),
                StudyConditions = "1",
                Tuition = 1500000,
                IsDeleted = false,
            },
            new Course
            {
                Id = 14,
                Name = "C",
                Content = "1",
                Detail = "1",
                StartDate = DateTime.Now.AddMonths(-7),
                EndDate = DateTime.Now.AddMonths(-4),
                StudyConditions = "1",
                Tuition = 1000000,
                IsDeleted = false,
            },
            new Course
            {
                Id = 15,
                Name = "C#",
                Content = "1",
                Detail = "1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(4),
                StudyConditions = "1",
                Tuition = 5500000,
                IsDeleted = false,
            }
        );
    }
}