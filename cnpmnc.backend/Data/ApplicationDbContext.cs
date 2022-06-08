using cnpmnc.backend.Configurations;
using cnpmnc.backend.Models;
using cnpmnc.backend.SeedData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace cnpmnc.backend.Data;
public class ApplicationDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public ApplicationDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Literacy> Literacies { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<SchoolShift> SchoolShifts { get; set; }
    public DbSet<AssignmentGrade> AssignmentGrades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new ClassroomConfiguration());
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new LiteracyConfiguration());
        modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
        modelBuilder.ApplyConfiguration(new SchoolShiftConfiguration());
        modelBuilder.ApplyConfiguration(new AssignmentGradeConfiguration());

        //Seed Data
        modelBuilder.SeedAccountData();
        modelBuilder.SeedClassroomData();
        modelBuilder.SeedCourseData();
        modelBuilder.SeedLiteracyData();
        modelBuilder.SeedScheduleData();
        modelBuilder.SeedSchoolShiftData();
        modelBuilder.SeedAssignmentGradeData();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Configuration.GetConnectionString("cnpmncDb");
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}