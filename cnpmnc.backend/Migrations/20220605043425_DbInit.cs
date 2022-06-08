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
                    Content = table.Column<string>(type: "longtext", nullable: false, defaultValue: "")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Detail = table.Column<string>(type: "longtext", nullable: false, defaultValue: "")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StudyConditions = table.Column<string>(type: "longtext", nullable: false, defaultValue: "")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tuition = table.Column<int>(type: "int", nullable: false),
                    NumberOfLesson = table.Column<int>(type: "int", nullable: false, defaultValue: 15)
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
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCard = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    LiteracyId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
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
                name: "AssignmentGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    AssignToTeacherId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "longtext", nullable: false, defaultValue: "")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Total = table.Column<int>(type: "int", nullable: false, defaultValue: 40),
                    AssignDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentGrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssignmentGrades_Accounts_AssignToTeacherId",
                        column: x => x.AssignToTeacherId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentGrades_Courses_CourseId",
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
                    AssignmentGradeId = table.Column<int>(type: "int", nullable: false),
                    ClassroomId = table.Column<int>(type: "int", nullable: false),
                    SchoolShiftId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedules_AssignmentGrades_AssignmentGradeId",
                        column: x => x.AssignmentGradeId,
                        principalTable: "AssignmentGrades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Schedules_Classrooms_ClassroomId",
                        column: x => x.ClassroomId,
                        principalTable: "Classrooms",
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
                columns: new[] { "Id", "Content", "Detail", "Name", "NumberOfLesson", "StudyConditions", "Tuition" },
                values: new object[,]
                {
                    { 1, "", "", "ReactJS", 15, "", 4000000 },
                    { 2, "", "", "NodeJS", 15, "", 4500000 },
                    { 3, "", "", "ASP.NET", 15, "", 3000000 },
                    { 4, "", "", "C#", 15, "", 2000000 },
                    { 5, "", "", "JavaScript", 15, "", 3500000 },
                    { 6, "", "", "Python", 15, "", 2500000 },
                    { 7, "", "", "React Native", 15, "", 5500000 },
                    { 8, "", "", "Golang", 15, "", 5500000 },
                    { 9, "", "", "VueJS", 15, "", 5000000 },
                    { 10, "", "", "Angular", 15, "", 6000000 },
                    { 11, "", "", "Flutter", 15, "", 6000000 },
                    { 12, "", "", "Java", 15, "", 1500000 },
                    { 13, "", "", "C++", 15, "", 1500000 },
                    { 14, "", "", "C", 15, "", 1000000 },
                    { 15, "", "", "C#", 15, "", 5500000 }
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
                columns: new[] { "Id", "AccountType", "Address", "IdCard", "LiteracyId", "Name", "Password", "PhoneNumber", "Status", "Username" },
                values: new object[,]
                {
                    { 1, 1, "abc123@gmail.com", "1", 1, "admin", "1", 1, 1, "admin" },
                    { 2, 2, "abc123@gmail.com", "1", 2, "Nguyễn Van A", "1", 1, 1, "gv1" },
                    { 3, 2, "abc123@gmail.com", "1", 3, "Nguyễn Văn B", "1", 1, 1, "gv2" },
                    { 4, 2, "abc123@gmail.com", "1", 3, "Nguyễn Văn C", "1", 1, 1, "gv3" }
                });

            migrationBuilder.InsertData(
                table: "AssignmentGrades",
                columns: new[] { "Id", "AssignDate", "AssignToTeacherId", "CourseId", "Semester", "State", "Total" },
                values: new object[] { 1, new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 2, 2, 40 });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "AssignmentGradeId", "ClassroomId", "EndDate", "SchoolShiftId", "StartDate" },
                values: new object[] { 1, 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_LiteracyId",
                table: "Accounts",
                column: "LiteracyId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentGrades_AssignToTeacherId",
                table: "AssignmentGrades",
                column: "AssignToTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentGrades_CourseId",
                table: "AssignmentGrades",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_AssignmentGradeId",
                table: "Schedules",
                column: "AssignmentGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_ClassroomId",
                table: "Schedules",
                column: "ClassroomId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_SchoolShiftId",
                table: "Schedules",
                column: "SchoolShiftId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "AssignmentGrades");

            migrationBuilder.DropTable(
                name: "Classrooms");

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
