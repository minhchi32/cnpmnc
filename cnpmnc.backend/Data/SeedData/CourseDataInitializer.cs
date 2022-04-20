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
                Name = "Đồ án 1",
                Content = "1",
                Detail = "1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(3),
                StudyConditions = "1",
                IsDeleted = false,
            },
            new Course
            {
                Id = 2,
                Name = "NodeJS",
                Content = "1",
                Detail = "1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(3),
                StudyConditions = "1",
                IsDeleted = false,
            },
            new Course
            {
                Id = 3,
                Name = "ASP.NET",
                Content = "1",
                Detail = "1",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(3),
                StudyConditions = "1",
                IsDeleted = false,
            }
        );
    }
    // static List<Course> temp()
    // {
    //     var a = new List<Course>();
    //     for (int i = 0; i < 100; i++)
    //     {
    //         a.Add(new Course
    //         {
    //             Id = i + 4,
    //             Name = "Andora",
    //             Content = "1",
    //             Detail = "1",
    //             StartDate = DateTime.Now,
    //             EndDate = DateTime.Now.AddMonths(3),
    //             StudyConditions = "1",
    //         });
    //     }
    //     return a;
    // }
}