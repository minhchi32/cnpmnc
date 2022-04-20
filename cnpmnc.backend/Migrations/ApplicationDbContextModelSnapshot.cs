﻿// <auto-generated />
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
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("cnpmnc.backend.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(2);

                    b.Property<int?>("ActualNumberOfHoursInClass")
                        .HasColumnType("int");

                    b.Property<string>("IdCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("LiteracyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberOfBreaks")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfHoursInClass")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfTeachingSessions")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LiteracyId");

                    b.ToTable("Accounts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountType = 1,
                            IdCard = "1",
                            IsDeleted = false,
                            LiteracyId = 1,
                            Name = "1",
                            Password = "1",
                            PhoneNumber = 1,
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            AccountType = 2,
                            ActualNumberOfHoursInClass = 15,
                            IdCard = "1",
                            IsDeleted = false,
                            LiteracyId = 2,
                            Name = "2",
                            NumberOfBreaks = 0,
                            NumberOfHoursInClass = 15,
                            NumberOfTeachingSessions = 15,
                            Password = "1",
                            PhoneNumber = 1,
                            Username = "gv1"
                        });
                });

            modelBuilder.Entity("cnpmnc.backend.Models.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Certificates", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            ExpiryDate = new DateTime(2025, 4, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8885),
                            IssueDate = new DateTime(2022, 4, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8876),
                            Name = "Software"
                        });
                });

            modelBuilder.Entity("cnpmnc.backend.Models.Classroom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
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
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("StudyConditions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tuition")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Courses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "1",
                            Detail = "1",
                            EndDate = new DateTime(2022, 7, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8927),
                            IsDeleted = false,
                            Name = "Đồ án 1",
                            StartDate = new DateTime(2022, 4, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8926),
                            StudyConditions = "1",
                            Tuition = 0
                        },
                        new
                        {
                            Id = 2,
                            Content = "1",
                            Detail = "1",
                            EndDate = new DateTime(2022, 7, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8931),
                            IsDeleted = false,
                            Name = "NodeJS",
                            StartDate = new DateTime(2022, 4, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8931),
                            StudyConditions = "1",
                            Tuition = 0
                        },
                        new
                        {
                            Id = 3,
                            Content = "1",
                            Detail = "1",
                            EndDate = new DateTime(2022, 7, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8933),
                            IsDeleted = false,
                            Name = "ASP.NET",
                            StartDate = new DateTime(2022, 4, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8933),
                            StudyConditions = "1",
                            Tuition = 0
                        });
                });

            modelBuilder.Entity("cnpmnc.backend.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfSessions")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CourseId");

                    b.ToTable("Grades", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            Name = "Đồ án 1 - 1",
                            NumberOfSessions = 0,
                            Total = 0
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 1,
                            Name = "Đồ án 1 - 2",
                            NumberOfSessions = 0,
                            Total = 0
                        });
                });

            modelBuilder.Entity("cnpmnc.backend.Models.Literacy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClassroomId")
                        .HasColumnType("int");

                    b.Property<int>("GradeId")
                        .HasColumnType("int");

                    b.Property<int>("SchoolShiftId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassroomId");

                    b.HasIndex("GradeId");

                    b.HasIndex("SchoolShiftId");

                    b.ToTable("Schedules", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClassroomId = 1,
                            GradeId = 1,
                            SchoolShiftId = 1
                        });
                });

            modelBuilder.Entity("cnpmnc.backend.Models.SchoolShift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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

            modelBuilder.Entity("cnpmnc.backend.Models.Certificate", b =>
                {
                    b.HasOne("cnpmnc.backend.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("cnpmnc.backend.Models.Grade", b =>
                {
                    b.HasOne("cnpmnc.backend.Models.Account", null)
                        .WithMany("Grades")
                        .HasForeignKey("AccountId");

                    b.HasOne("cnpmnc.backend.Models.Course", "Course")
                        .WithMany("Grades")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("cnpmnc.backend.Models.Schedule", b =>
                {
                    b.HasOne("cnpmnc.backend.Models.Classroom", "Classroom")
                        .WithMany("Schedules")
                        .HasForeignKey("ClassroomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cnpmnc.backend.Models.Grade", "Grade")
                        .WithMany("Schedules")
                        .HasForeignKey("GradeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cnpmnc.backend.Models.SchoolShift", "SchoolShift")
                        .WithMany("Schedules")
                        .HasForeignKey("SchoolShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classroom");

                    b.Navigation("Grade");

                    b.Navigation("SchoolShift");
                });

            modelBuilder.Entity("cnpmnc.backend.Models.Account", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("cnpmnc.backend.Models.Classroom", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("cnpmnc.backend.Models.Course", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("cnpmnc.backend.Models.Grade", b =>
                {
                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("cnpmnc.backend.Models.SchoolShift", b =>
                {
                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}