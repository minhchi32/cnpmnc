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
                Name = "THPT"
            },
            new Literacy
            {
                Id = 2,
                Name = "Đại học"
            },
            new Literacy
            {
                Id = 3,
                Name = "Thạc sĩ"
            }
        );
    }
}