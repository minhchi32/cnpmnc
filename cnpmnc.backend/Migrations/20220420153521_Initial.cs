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
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Literacies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Literacies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolShifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                });

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
                    LiteracyId = table.Column<int>(type: "int", nullable: false),
                    NumberOfHoursInClass = table.Column<int>(type: "int", nullable: true),
                    ActualNumberOfHoursInClass = table.Column<int>(type: "int", nullable: true),
                    NumberOfTeachingSessions = table.Column<int>(type: "int", nullable: true),
                    NumberOfBreaks = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    Total = table.Column<int>(type: "int", nullable: false),
                    AccountId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id");
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
                });

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
                    { 1, "1", "1", new DateTime(2022, 7, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8927), false, "Đồ án 1", new DateTime(2022, 4, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8926), "1", 0 },
                    { 2, "1", "1", new DateTime(2022, 7, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8931), false, "NodeJS", new DateTime(2022, 4, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8931), "1", 0 },
                    { 3, "1", "1", new DateTime(2022, 7, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8933), false, "ASP.NET", new DateTime(2022, 4, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8933), "1", 0 }
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
                    { 2, 2, 15, "1", false, 2, "2", 0, 15, 15, "1", 1, "gv1" }
                });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "CourseId", "ExpiryDate", "IssueDate", "Name" },
                values: new object[] { 1, 1, new DateTime(2025, 4, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8885), new DateTime(2022, 4, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8876), "Software" });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "AccountId", "CourseId", "Name", "NumberOfSessions", "Total" },
                values: new object[,]
                {
                    { 1, null, 1, "Đồ án 1 - 1", 0, 0 },
                    { 2, null, 1, "Đồ án 1 - 2", 0, 0 }
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
                name: "IX_Grades_AccountId",
                table: "Grades",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_CourseId",
                table: "Grades",
                column: "CourseId");

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
