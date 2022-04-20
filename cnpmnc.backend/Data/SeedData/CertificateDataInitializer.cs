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
                Name = "Software",
                IssueDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddYears(3),
                CourseId = 1,
            }
        );
    }
}