using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cnpmnc.backend.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountType = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    IdCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    NumberOfHoursInClass = table.Column<int>(type: "int", nullable: true),
                    ActualNumberOfHoursInClass = table.Column<int>(type: "int", nullable: true),
                    NumberOfTeachingSessions = table.Column<int>(type: "int", nullable: true),
                    NumberOfBreaks = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Literacies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Literacies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Literacies_Accounts_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudyConditions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tuition = table.Column<int>(type: "int", nullable: false),
                    CertificateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Certificates_CertificateId",
                        column: x => x.CertificateId,
                        principalTable: "Certificates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    NumberOfSessions = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeId = table.Column<int>(type: "int", nullable: false),
                    ClassroomId = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "TeacherGrades",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherGrades", x => x.TeacherId);
                    table.ForeignKey(
                        name: "FK_TeacherGrades_Accounts_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherGrades_Grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolShifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchoolShifts_Schedules_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountType", "ActualNumberOfHoursInClass", "IdCard", "Name", "NumberOfBreaks", "NumberOfHoursInClass", "NumberOfTeachingSessions", "Password", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { 1, 1, null, "1", "1", null, null, null, "1", 1, "admin" },
                    { 2, 2, null, "1", "2", null, null, null, "1", 1, "leturer" }
                });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "ExpiryDate", "IssueDate", "Name" },
                values: new object[] { 1, new DateTime(2025, 4, 15, 15, 52, 3, 807, DateTimeKind.Local).AddTicks(2639), new DateTime(2022, 4, 15, 15, 52, 3, 807, DateTimeKind.Local).AddTicks(2630), "Software" });

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
                columns: new[] { "Id", "CertificateId", "Content", "Detail", "EndDate", "Name", "StartDate", "StudyConditions", "Tuition" },
                values: new object[,]
                {
                    { 1, 1, "1", "1", new DateTime(2022, 7, 15, 15, 52, 3, 807, DateTimeKind.Local).AddTicks(2662), "Andora", new DateTime(2022, 4, 15, 15, 52, 3, 807, DateTimeKind.Local).AddTicks(2661), "1", 0 },
                    { 2, 1, "1", "1", new DateTime(2022, 7, 15, 15, 52, 3, 807, DateTimeKind.Local).AddTicks(2665), "Andora", new DateTime(2022, 4, 15, 15, 52, 3, 807, DateTimeKind.Local).AddTicks(2664), "1", 0 },
                    { 3, 1, "1", "1", new DateTime(2022, 7, 15, 15, 52, 3, 807, DateTimeKind.Local).AddTicks(2666), "Andora", new DateTime(2022, 4, 15, 15, 52, 3, 807, DateTimeKind.Local).AddTicks(2666), "1", 0 }
                });

            migrationBuilder.InsertData(
                table: "Literacies",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[] { 1, "Andora", 2 });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CourseId", "Name", "NumberOfSessions", "Total" },
                values: new object[] { 1, 1, "Andora", 0, 0 });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "ClassroomId", "GradeId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "TeacherGrades",
                columns: new[] { "TeacherId", "GradeId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "SchoolShifts",
                columns: new[] { "Id", "EndTime", "Name", "ScheduleId", "StartTime" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andora", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CertificateId",
                table: "Courses",
                column: "CertificateId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_CourseId",
                table: "Grades",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Literacies_TeacherId",
                table: "Literacies",
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
                name: "IX_SchoolShifts_ScheduleId",
                table: "SchoolShifts",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherGrades_GradeId",
                table: "TeacherGrades",
                column: "GradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Literacies");

            migrationBuilder.DropTable(
                name: "SchoolShifts");

            migrationBuilder.DropTable(
                name: "TeacherGrades");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Certificates");
        }
    }
}
