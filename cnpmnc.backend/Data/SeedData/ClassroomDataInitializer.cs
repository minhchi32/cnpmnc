using cnpmnc.backend.Models;
using Microsoft.EntityFrameworkCore;

namespace cnpmnc.backend.SeedData;

public static class ClassroomDataInitializer
{
    public static void SeedClassroomData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Classroom>().HasData(
            new Classroom
            {
                Id = 1,
                Name = "B21",
                Status = true,
                Note = "1",
            },
            new Classroom
            {
                Id = 2,
                Name = "B22",
                Status = true,
                Note = "1",
            },
            new Classroom
            {
                Id = 3,
                Name = "B24",
                Status = true,
                Note = "1",
            }
        );
    }
}