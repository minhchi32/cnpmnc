using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cnpmnc.backend.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    Note = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Detail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    StudyConditions = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tuition = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Literacies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Literacies", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SchoolShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolShifts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IssueDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AccountType = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    IdCard = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    LiteracyId = table.Column<int>(type: "int", nullable: false),
                    NumberOfHoursInClass = table.Column<int>(type: "int", nullable: true),
                    ActualNumberOfHoursInClass = table.Column<int>(type: "int", nullable: true),
                    NumberOfTeachingSessions = table.Column<int>(type: "int", nullable: true),
                    NumberOfBreaks = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Literacies_LiteracyId",
                        column: x => x.LiteracyId,
                        principalTable: "Literacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    NumberOfSessions = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Accounts_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Grades_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    ClassroomId = table.Column<int>(type: "int", nullable: false),
                    SchoolShiftId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_SchoolShifts_SchoolShiftId",
                        column: x => x.SchoolShiftId,
                        principalTable: "SchoolShifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "Id", "Name", "Note", "Status" },
                values: new object[,]
                {
                    { 1, "B21", "1", true },
                    { 2, "B22", "1", true },
                    { 3, "B24", "1", true }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Content", "Detail", "EndDate", "IsDeleted", "Name", "StartDate", "StudyConditions", "Tuition" },
                values: new object[,]
                {
                    { 1, "1", "1", new DateTime(2022, 3, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3132), false, "ReactJS", new DateTime(2022, 1, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3128), "1", 4000000 },
                    { 2, "1", "1", new DateTime(2022, 12, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3135), false, "NodeJS", new DateTime(2022, 6, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3134), "1", 4500000 },
                    { 3, "1", "1", new DateTime(2021, 11, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3137), false, "ASP.NET", new DateTime(2021, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3136), "1", 3000000 },
                    { 4, "1", "1", new DateTime(2022, 8, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3139), false, "C#", new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3138), "1", 2000000 },
                    { 5, "1", "1", new DateTime(2022, 11, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3140), false, "JavaScript", new DateTime(2022, 8, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3140), "1", 3500000 },
                    { 6, "1", "1", new DateTime(2023, 1, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3142), false, "Python", new DateTime(2022, 10, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3141), "1", 2500000 },
                    { 7, "1", "1", new DateTime(2023, 2, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3143), false, "React Native", new DateTime(2022, 11, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3143), "1", 5500000 },
                    { 8, "1", "1", new DateTime(2022, 12, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3145), false, "Golang", new DateTime(2022, 9, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3144), "1", 5500000 },
                    { 9, "1", "1", new DateTime(2022, 9, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3147), false, "VueJS", new DateTime(2022, 6, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3146), "1", 5000000 },
                    { 10, "1", "1", new DateTime(2022, 8, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3148), false, "Angular", new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3148), "1", 6000000 },
                    { 11, "1", "1", new DateTime(2022, 8, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3150), false, "Flutter", new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3150), "1", 6000000 },
                    { 12, "1", "1", new DateTime(2022, 2, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3152), false, "Java", new DateTime(2021, 12, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3151), "1", 1500000 },
                    { 13, "1", "1", new DateTime(2022, 2, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3153), false, "C++", new DateTime(2021, 11, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3152), "1", 1500000 },
                    { 14, "1", "1", new DateTime(2022, 1, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3155), false, "C", new DateTime(2021, 10, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3154), "1", 1000000 },
                    { 15, "1", "1", new DateTime(2022, 9, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3156), false, "C#", new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3156), "1", 5500000 }
                });

            migrationBuilder.InsertData(
                table: "Literacies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "THPT" },
                    { 2, "Đại học" },
                    { 3, "Thạc sĩ" }
                });

            migrationBuilder.InsertData(
                table: "SchoolShifts",
                columns: new[] { "Id", "EndTime", "Name", "StartTime" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 9, 15, 0, 0), "Ca 1", new TimeSpan(0, 6, 45, 0, 0) },
                    { 2, new TimeSpan(0, 12, 0, 0, 0), "Ca 2", new TimeSpan(0, 9, 30, 0, 0) },
                    { 3, new TimeSpan(0, 12, 15, 0, 0), "Ca 3", new TimeSpan(0, 12, 45, 0, 0) },
                    { 4, new TimeSpan(0, 18, 0, 0, 0), "Ca 4", new TimeSpan(0, 15, 30, 0, 0) },
                    { 5, new TimeSpan(0, 21, 45, 0, 0), "Ca 5", new TimeSpan(0, 18, 15, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountType", "ActualNumberOfHoursInClass", "IdCard", "IsDeleted", "LiteracyId", "Name", "NumberOfBreaks", "NumberOfHoursInClass", "NumberOfTeachingSessions", "Password", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { 1, 1, null, "1", false, 1, "1", null, null, null, "1", 1, "admin" },
                    { 2, 2, 15, "1", false, 2, "Nguyễn Van A", 0, 15, 15, "1", 1, "gv1" },
                    { 3, 2, 15, "1", false, 3, "Nguyễn Văn B", 0, 15, 15, "1", 1, "gv2" },
                    { 4, 2, 15, "1", false, 3, "Nguyễn Văn C", 0, 15, 15, "1", 1, "gv3" }
                });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "CourseId", "ExpiryDate", "IssueDate", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3069), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3059), "ReactJS" },
                    { 2, 2, new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3077), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3077), "NodeJS" },
                    { 3, 3, new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3079), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3078), "ASP.NET" },
                    { 4, 4, new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3080), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3080), "C#" },
                    { 5, 5, new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3081), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3081), "JavaScript" },
                    { 6, 6, new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3082), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3082), "Python" },
                    { 7, 7, new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3084), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3083), "React Native" },
                    { 8, 8, new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3085), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3085), "Golang" },
                    { 9, 9, new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3086), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3086), "VueJS" },
                    { 10, 10, new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3087), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3087), "Angular" },
                    { 11, 11, new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3088), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3088), "Flutter" },
                    { 12, 12, new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3089), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3089), "Java" },
                    { 13, 13, new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3091), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3090), "C++" },
                    { 14, 14, new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3095), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3094), "C" },
                    { 15, 15, new DateTime(2026, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3096), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3096), "C#" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CourseId", "Name", "NumberOfSessions", "TeacherId", "Total" },
                values: new object[,]
                {
                    { 1, 1, "ReactJS - 1", 10, 2, 0 },
                    { 2, 1, "ReactJS - 2", 10, 2, 0 },
                    { 3, 2, "NodeJS - 1", 10, 3, 0 },
                    { 4, 2, "NodeJS - 2", 10, 3, 0 },
                    { 5, 3, "ASP.NET - 1", 10, 4, 0 },
                    { 6, 3, "ASP.NET - 2", 10, 4, 0 },
                    { 7, 4, "C# - 1", 10, 2, 0 },
                    { 8, 4, "C# - 2", 10, 2, 0 },
                    { 9, 5, "JavaScript - 1", 10, 3, 0 },
                    { 10, 5, "JavaScript - 2", 10, 3, 0 },
                    { 11, 6, "Python - 1", 10, 4, 0 },
                    { 12, 6, "Python - 2", 10, 4, 0 },
                    { 13, 7, "React Native - 1", 10, 2, 0 },
                    { 14, 7, "React Native - 2", 10, 2, 0 },
                    { 15, 8, "Golang - 1", 10, 3, 0 },
                    { 16, 8, "Golang - 2", 10, 3, 0 },
                    { 17, 9, "VueJS - 1", 10, 4, 0 },
                    { 18, 9, "VueJS - 2", 10, 4, 0 },
                    { 19, 10, "Angular - 1", 10, 2, 0 },
                    { 20, 10, "Angular - 2", 10, 2, 0 },
                    { 21, 11, "Flutter - 1", 10, 3, 0 },
                    { 22, 11, "Flutter - 1", 10, 3, 0 },
                    { 23, 12, "Java - 1", 10, 4, 0 },
                    { 24, 12, "Java - 2", 10, 4, 0 },
                    { 25, 13, "C++ - 1", 10, 2, 0 },
                    { 26, 13, "C++ - 2", 10, 2, 0 },
                    { 27, 14, "C - 1", 10, 3, 0 },
                    { 28, 14, "C - 2", 10, 3, 0 },
                    { 29, 15, "C# - 1", 10, 4, 0 },
                    { 30, 15, "C# - 2", 10, 4, 0 }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "ClassroomId", "GradeId", "SchoolShiftId" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_LiteracyId",
                table: "Accounts",
                column: "LiteracyId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_CourseId",
                table: "Certificates",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_CourseId",
                table: "Grades",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_TeacherId",
                table: "Grades",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ClassroomId",
                table: "Schedules",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_GradeId",
                table: "Schedules",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_SchoolShiftId",
                table: "Schedules",
                column: "SchoolShiftId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "SchoolShifts");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Literacies");
        }
    }
}
