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
                Content = "",
                Detail = "",
                StudyConditions = "",
                Tuition = 4000000,
                NumberOfLesson = 15,
            },
            new Course
            {
                Id = 2,
                Name = "NodeJS",
                Content = "",
                Detail = "",
                StudyConditions = "",
                Tuition = 4500000,
                NumberOfLesson = 15,
            },
            new Course
            {
                Id = 3,
                Name = "ASP.NET",
                Content = "",
                Detail = "",
                StudyConditions = "",
                Tuition = 3000000,
                NumberOfLesson = 15,
            },
            new Course
            {
                Id = 4,
                Name = "C#",
                Content = "",
                Detail = "",
                StudyConditions = "",
                Tuition = 2000000,
                NumberOfLesson = 15,
            },
            new Course
            {
                Id = 5,
                Name = "JavaScript",
                Content = "",
                Detail = "",
                StudyConditions = "",
                Tuition = 3500000,
                NumberOfLesson = 15,
            },
            new Course
            {
                Id = 6,
                Name = "Python",
                Content = "",
                Detail = "",
                StudyConditions = "",
                Tuition = 2500000,
                NumberOfLesson = 15,
            },
            new Course
            {
                Id = 7,
                Name = "React Native",
                Content = "",
                Detail = "",
                StudyConditions = "",
                Tuition = 5500000,
                NumberOfLesson = 15,
            },
            new Course
            {
                Id = 8,
                Name = "Golang",
                Content = "",
                Detail = "",
                StudyConditions = "",
                Tuition = 5500000,
                NumberOfLesson = 15,
            },
            new Course
            {
                Id = 9,
                Name = "VueJS",
                Content = "",
                Detail = "",
                StudyConditions = "",
                Tuition = 5000000,
                NumberOfLesson = 15,
            },
            new Course
            {
                Id = 10,
                Name = "Angular",
                Content = "",
                Detail = "",
                StudyConditions = "",
                Tuition = 6000000,
                NumberOfLesson = 15,
            },
            new Course
            {
                Id = 11,
                Name = "Flutter",
                Content = "",
                Detail = "",
                StudyConditions = "",
                Tuition = 6000000,
                NumberOfLesson = 15,
            },
            new Course
            {
                Id = 12,
                Name = "Java",
                Content = "",
                Detail = "",
                StudyConditions = "",
                Tuition = 1500000,
                NumberOfLesson = 15,
            },
            new Course
            {
                Id = 13,
                Name = "C++",
                Content = "",
                Detail = "",
                StudyConditions = "",
                Tuition = 1500000,
                NumberOfLesson = 15,
            },
            new Course
            {
                Id = 14,
                Name = "C",
                Content = "",
                Detail = "",
                StudyConditions = "",
                Tuition = 1000000,
                NumberOfLesson = 15,
            },
            new Course
            {
                Id = 15,
                Name = "C#",
                Content = "",
                Detail = "",
                StudyConditions = "",
                Tuition = 5500000,
                NumberOfLesson = 15,
            }
        );
    }
}