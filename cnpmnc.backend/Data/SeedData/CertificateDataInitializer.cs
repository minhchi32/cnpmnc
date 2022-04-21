using cnpmnc.backend.Models;
using Microsoft.EntityFrameworkCore;

namespace cnpmnc.backend.SeedData;

public static class CertificateDataInitializer
{
    public static void SeedCertificateData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Certificate>().HasData(
            new Certificate
            {
                Id = 1,
                Name = "ReactJS",
                IssueDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddYears(3),
                CourseId = 1,
            },
            new Certificate
            {
                Id = 2,
                Name = "NodeJS",
                IssueDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddYears(3),
                CourseId = 2,
            },
            new Certificate
            {
                Id = 3,
                Name = "ASP.NET",
                IssueDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddYears(3),
                CourseId = 3,
            },
            new Certificate
            {
                Id = 4,
                Name = "C#",
                IssueDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddYears(3),
                CourseId = 4,
            },
            new Certificate
            {
                Id = 5,
                Name = "JavaScript",
                IssueDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddYears(3),
                CourseId = 5,
            },
            new Certificate
            {
                Id = 6,
                Name = "Python",
                IssueDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddYears(3),
                CourseId = 6,
            },
            new Certificate
            {
                Id = 7,
                Name = "React Native",
                IssueDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddYears(3),
                CourseId = 7,
            },
            new Certificate
            {
                Id = 8,
                Name = "Golang",
                IssueDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddYears(3),
                CourseId = 8,
            },
            new Certificate
            {
                Id = 9,
                Name = "VueJS",
                IssueDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddYears(3),
                CourseId = 9,
            },
            new Certificate
            {
                Id = 10,
                Name = "Angular",
                IssueDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddYears(3),
                CourseId = 10,
            },
            new Certificate
            {
                Id = 11,
                Name = "Flutter",
                IssueDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddYears(3),
                CourseId = 11,
            },
            new Certificate
            {
                Id = 12,
                Name = "Java",
                IssueDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddYears(3),
                CourseId = 12,
            },
            new Certificate
            {
                Id = 13,
                Name = "C++",
                IssueDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddYears(3),
                CourseId = 13,
            },
            new Certificate
            {
                Id = 14,
                Name = "C",
                IssueDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddYears(3),
                CourseId = 14,
            },
            new Certificate
            {
                Id = 15,
                Name = "C#",
                IssueDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddYears(4),
                CourseId = 15,
            }
        );
    }
}