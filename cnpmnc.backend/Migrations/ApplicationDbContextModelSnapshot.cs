// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cnpmnc.backend.Data;

#nullable disable

namespace cnpmnc.backend.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("cnpmnc.backend.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(2);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("IdCard")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("LiteracyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("LiteracyId");

                    b.ToTable("Accounts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountType = 1,
                            Address = "abc123@gmail.com",
                            IdCard = "1",
                            LiteracyId = 1,
                            Name = "admin",
                            Password = "1",
                            PhoneNumber = 1,
                            Status = 1,
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            AccountType = 2,
                            Address = "abc123@gmail.com",
                            IdCard = "1",
                            LiteracyId = 2,
                            Name = "Nguyễn Van A",
                            Password = "1",
                            PhoneNumber = 1,
                            Status = 1,
                            Username = "gv0001"
                        },
                        new
                        {
                            Id = 3,
                            AccountType = 2,
                            Address = "abc123@gmail.com",
                            IdCard = "1",
                            LiteracyId = 3,
                            Name = "Nguyễn Văn B",
                            Password = "1",
                            PhoneNumber = 1,
                            Status = 1,
                            Username = "gv0002"
                        },
                        new
                        {
                            Id = 4,
                            AccountType = 2,
                            Address = "abc123@gmail.com",
                            IdCard = "1",
                            LiteracyId = 3,
                            Name = "Nguyễn Văn C",
                            Password = "1",
                            PhoneNumber = 1,
                            Status = 1,
                            Username = "gv0003"
                        });
                });

            modelBuilder.Entity("cnpmnc.backend.Models.AssignmentGrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AssignDate")
                        .HasColumnType("datetime");

                    b.Property<int>("AssignToTeacherId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("longtext")
                        .HasDefaultValue("");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("Total")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(40);

                    b.HasKey("Id");

                    b.HasIndex("AssignToTeacherId");

                    b.HasIndex("CourseId");

                    b.ToTable("AssignmentGrades", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssignDate = new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AssignToTeacherId = 2,
                            CourseId = 1,
                            Semester = 2,
                            State = 2,
                            Total = 40
                        },
                        new
                        {
                            Id = 2,
                            AssignDate = new DateTime(2021, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AssignToTeacherId = 2,
                            CourseId = 1,
                            Semester = 2,
                            State = 2,
                            Total = 40
                        },
                        new
                        {
                            Id = 3,
                            AssignDate = new DateTime(2021, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AssignToTeacherId = 2,
                            CourseId = 2,
                            Semester = 2,
                            State = 2,
                            Total = 40
                        },
                        new
                        {
                            Id = 4,
                            AssignDate = new DateTime(2021, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AssignToTeacherId = 3,
                            CourseId = 4,
                            Semester = 3,
                            State = 2,
                            Total = 40
                        });
                });

            modelBuilder.Entity("cnpmnc.backend.Models.Classroom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("Classrooms", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "B21",
                            Note = "1",
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            Name = "B22",
                            Note = "1",
                            Status = true
                        },
                        new
                        {
                            Id = 3,
                            Name = "B24",
                            Note = "1",
                            Status = true
                        });
                });

            modelBuilder.Entity("cnpmnc.backend.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("longtext")
                        .HasDefaultValue("");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("longtext")
                        .HasDefaultValue("");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("NumberOfLesson")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(15);

                    b.Property<string>("StudyConditions")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("longtext")
                        .HasDefaultValue("");

                    b.Property<int>("Tuition")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Courses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "",
                            Detail = "",
                            Name = "ReactJS",
                            NumberOfLesson = 15,
                            StudyConditions = "",
                            Tuition = 4000000
                        },
                        new
                        {
                            Id = 2,
                            Content = "",
                            Detail = "",
                            Name = "NodeJS",
                            NumberOfLesson = 15,
                            StudyConditions = "",
                            Tuition = 4500000
                        },
                        new
                        {
                            Id = 3,
                            Content = "",
                            Detail = "",
                            Name = "ASP.NET",
                            NumberOfLesson = 15,
                            StudyConditions = "",
                            Tuition = 3000000
                        },
                        new
                        {
                            Id = 4,
                            Content = "",
                            Detail = "",
                            Name = "C#",
                            NumberOfLesson = 15,
                            StudyConditions = "",
                            Tuition = 2000000
                        },
                        new
                        {
                            Id = 5,
                            Content = "",
                            Detail = "",
                            Name = "JavaScript",
                            NumberOfLesson = 15,
                            StudyConditions = "",
                            Tuition = 3500000
                        },
                        new
                        {
                            Id = 6,
                            Content = "",
                            Detail = "",
                            Name = "Python",
                            NumberOfLesson = 15,
                            StudyConditions = "",
                            Tuition = 2500000
                        },
                        new
                        {
                            Id = 7,
                            Content = "",
                            Detail = "",
                            Name = "React Native",
                            NumberOfLesson = 15,
                            StudyConditions = "",
                            Tuition = 5500000
                        },
                        new
                        {
                            Id = 8,
                            Content = "",
                            Detail = "",
                            Name = "Golang",
                            NumberOfLesson = 15,
                            StudyConditions = "",
                            Tuition = 5500000
                        },
                        new
                        {
                            Id = 9,
                            Content = "",
                            Detail = "",
                            Name = "VueJS",
                            NumberOfLesson = 15,
                            StudyConditions = "",
                            Tuition = 5000000
                        },
                        new
                        {
                            Id = 10,
                            Content = "",
                            Detail = "",
                            Name = "Angular",
                            NumberOfLesson = 15,
                            StudyConditions = "",
                            Tuition = 6000000
                        },
                        new
                        {
                            Id = 11,
                            Content = "",
                            Detail = "",
                            Name = "Flutter",
                            NumberOfLesson = 15,
                            StudyConditions = "",
                            Tuition = 6000000
                        },
                        new
                        {
                            Id = 12,
                            Content = "",
                            Detail = "",
                            Name = "Java",
                            NumberOfLesson = 15,
                            StudyConditions = "",
                            Tuition = 1500000
                        },
                        new
                        {
                            Id = 13,
                            Content = "",
                            Detail = "",
                            Name = "C++",
                            NumberOfLesson = 15,
                            StudyConditions = "",
                            Tuition = 1500000
                        },
                        new
                        {
                            Id = 14,
                            Content = "",
                            Detail = "",
                            Name = "C",
                            NumberOfLesson = 15,
                            StudyConditions = "",
                            Tuition = 1000000
                        },
                        new
                        {
                            Id = 15,
                            Content = "",
                            Detail = "",
                            Name = "C#",
                            NumberOfLesson = 15,
                            StudyConditions = "",
                            Tuition = 5500000
                        });
                });

            modelBuilder.Entity("cnpmnc.backend.Models.Literacy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Literacies", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "THPT"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Đại học"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Thạc sĩ"
                        });
                });

            modelBuilder.Entity("cnpmnc.backend.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AssignmentGradeId")
                        .HasColumnType("int");

                    b.Property<int>("ClassroomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<int>("SchoolShiftId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentGradeId");

                    b.HasIndex("ClassroomId");

                    b.HasIndex("SchoolShiftId");

                    b.ToTable("Schedules", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AssignmentGradeId = 1,
                            ClassroomId = 1,
                            EndDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            SchoolShiftId = 1,
                            StartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("cnpmnc.backend.Models.SchoolShift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("SchoolShifts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndTime = new TimeSpan(0, 9, 15, 0, 0),
                            Name = "Ca 1",
                            StartTime = new TimeSpan(0, 6, 45, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            EndTime = new TimeSpan(0, 12, 0, 0, 0),
                            Name = "Ca 2",
                            StartTime = new TimeSpan(0, 9, 30, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            EndTime = new TimeSpan(0, 12, 15, 0, 0),
                            Name = "Ca 3",
                            StartTime = new TimeSpan(0, 12, 45, 0, 0)
                        },
                        new
                        {
                            Id = 4,
                            EndTime = new TimeSpan(0, 18, 0, 0, 0),
                            Name = "Ca 4",
                            StartTime = new TimeSpan(0, 15, 30, 0, 0)
                        },
                        new
                        {
                            Id = 5,
                            EndTime = new TimeSpan(0, 21, 45, 0, 0),
                            Name = "Ca 5",
                            StartTime = new TimeSpan(0, 18, 15, 0, 0)
                        });
                });

            modelBuilder.Entity("cnpmnc.backend.Models.Account", b =>
                {
                    b.HasOne("cnpmnc.backend.Models.Literacy", "Literacy")
                        .WithMany()
                        .HasForeignKey("LiteracyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Literacy");
                });

            modelBuilder.Entity("cnpmnc.backend.Models.AssignmentGrade", b =>
                {
                    b.HasOne("cnpmnc.backend.Models.Account", "Teacher")
                        .WithMany("AssignmentGrades")
                        .HasForeignKey("AssignToTeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cnpmnc.backend.Models.Course", "Course")
                        .WithMany("AssignmentGrades")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("cnpmnc.backend.Models.Schedule", b =>
                {
                    b.HasOne("cnpmnc.backend.Models.AssignmentGrade", "AssignmentGrade")
                        .WithMany("Schedules")
                        .HasForeignKey("AssignmentGradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cnpmnc.backend.Models.Classroom", "Classroom")
                        .WithMany("Schedules")
                        .HasForeignKey("ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cnpmnc.backend.Models.SchoolShift", "SchoolShift")
                        .WithMany("Schedules")
                        .HasForeignKey("SchoolShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AssignmentGrade");

                    b.Navigation("Classroom");

                    b.Navigation("SchoolShift");
                });

            modelBuilder.Entity("cnpmnc.backend.Models.Account", b =>
                {
                    b.Navigation("AssignmentGrades");
                });

            modelBuilder.Entity("cnpmnc.backend.Models.AssignmentGrade", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("cnpmnc.backend.Models.Classroom", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("cnpmnc.backend.Models.Course", b =>
                {
                    b.Navigation("AssignmentGrades");
                });

            modelBuilder.Entity("cnpmnc.backend.Models.SchoolShift", b =>
                {
                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}
