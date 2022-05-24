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
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Literacy> Literacies { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<SchoolShift> SchoolShifts { get; set; }
    public DbSet<Assignment> Assignments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new CertificateConfiguration());
        modelBuilder.ApplyConfiguration(new ClassroomConfiguration());
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new GradeConfiguration());
        modelBuilder.ApplyConfiguration(new LiteracyConfiguration());
        modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
        modelBuilder.ApplyConfiguration(new SchoolShiftConfiguration());
        modelBuilder.ApplyConfiguration(new AssignmentConfiguration());

        //Seed Data
        modelBuilder.SeedAccountData();
        modelBuilder.SeedCertificateData();
        modelBuilder.SeedClassroomData();
        modelBuilder.SeedCourseData();
        modelBuilder.SeedGradeData();
        modelBuilder.SeedLiteracyData();
        modelBuilder.SeedScheduleData();
        modelBuilder.SeedSchoolShiftData();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Configuration.GetConnectionString("cnpmncDb");
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }
}