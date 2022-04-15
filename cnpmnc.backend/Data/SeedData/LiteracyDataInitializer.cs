using cnpmnc.backend.Models;
using Microsoft.EntityFrameworkCore;

namespace cnpmnc.backend.SeedData;

public static class LiteracyDataInitializer
{
    public static void SeedLiteracyData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Literacy>().HasData(
            new Literacy
            {
                Id = 1,
                Name = "Andora",
                TeacherId = 2,
            }
        );
    }
}