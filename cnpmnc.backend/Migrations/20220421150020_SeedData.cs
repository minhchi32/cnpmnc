using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cnpmnc.backend.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Accounts_AccountId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_AccountId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Grades");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Nguyễn Van A");

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountType", "ActualNumberOfHoursInClass", "IdCard", "IsDeleted", "LiteracyId", "Name", "NumberOfBreaks", "NumberOfHoursInClass", "NumberOfTeachingSessions", "Password", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { 3, 2, 15, "1", false, 3, "Nguyễn Văn B", 0, 15, 15, "1", 1, "gv2" },
                    { 4, 2, 15, "1", false, 3, "Nguyễn Văn C", 0, 15, 15, "1", 1, "gv3" }
                });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpiryDate", "IssueDate", "Name" },
                values: new object[] { new DateTime(2025, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1546), new DateTime(2022, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1538), "ReactJS" });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "CourseId", "ExpiryDate", "IssueDate", "Name" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2025, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1551), new DateTime(2022, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1550), "NodeJS" },
                    { 3, 3, new DateTime(2025, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1553), new DateTime(2022, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1552), "ASP.NET" }
                });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "Name", "StartDate", "Tuition" },
                values: new object[] { new DateTime(2022, 2, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1612), "ReactJS", new DateTime(2021, 12, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1610), 4000000 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate", "Tuition" },
                values: new object[] { new DateTime(2022, 11, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1615), new DateTime(2022, 5, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1614), 4500000 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate", "Tuition" },
                values: new object[] { new DateTime(2021, 10, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1617), new DateTime(2021, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1617), 3000000 });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Content", "Detail", "EndDate", "IsDeleted", "Name", "StartDate", "StudyConditions", "Tuition" },
                values: new object[,]
                {
                    { 4, "1", "1", new DateTime(2022, 7, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1619), false, "C#", new DateTime(2022, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1619), "1", 2000000 },
                    { 5, "1", "1", new DateTime(2022, 10, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1622), false, "JavaScript", new DateTime(2022, 7, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1621), "1", 3500000 },
                    { 6, "1", "1", new DateTime(2022, 12, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1624), false, "Python", new DateTime(2022, 9, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1623), "1", 2500000 },
                    { 7, "1", "1", new DateTime(2023, 1, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1626), false, "React Native", new DateTime(2022, 10, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1625), "1", 5500000 },
                    { 8, "1", "1", new DateTime(2022, 11, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1628), false, "Golang", new DateTime(2022, 8, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1627), "1", 5500000 },
                    { 9, "1", "1", new DateTime(2022, 8, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1630), false, "VueJS", new DateTime(2022, 5, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1629), "1", 5000000 },
                    { 10, "1", "1", new DateTime(2022, 7, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1631), false, "Angular", new DateTime(2022, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1631), "1", 6000000 },
                    { 11, "1", "1", new DateTime(2022, 7, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1634), false, "Flutter", new DateTime(2022, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1633), "1", 6000000 },
                    { 12, "1", "1", new DateTime(2022, 1, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1636), false, "Java", new DateTime(2021, 11, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1635), "1", 1500000 },
                    { 13, "1", "1", new DateTime(2022, 1, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1638), false, "C++", new DateTime(2021, 10, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1637), "1", 1500000 },
                    { 14, "1", "1", new DateTime(2021, 12, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1640), false, "C", new DateTime(2021, 9, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1639), "1", 1000000 },
                    { 15, "1", "1", new DateTime(2022, 8, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1642), false, "C#", new DateTime(2022, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1642), "1", 5500000 }
                });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "NumberOfSessions", "TeacherId" },
                values: new object[] { "ReactJS - 1", 10, 2 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "NumberOfSessions", "TeacherId" },
                values: new object[] { "ReactJS - 2", 10, 2 });

            migrationBuilder.InsertData(
                table: "Certificates",
                columns: new[] { "Id", "CourseId", "ExpiryDate", "IssueDate", "Name" },
                values: new object[,]
                {
                    { 4, 4, new DateTime(2025, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1554), new DateTime(2022, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1554), "C#" },
                    { 5, 5, new DateTime(2025, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1556), new DateTime(2022, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1555), "JavaScript" },
                    { 6, 6, new DateTime(2025, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1558), new DateTime(2022, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1557), "Python" },
                    { 7, 7, new DateTime(2025, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1559), new DateTime(2022, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1559), "React Native" },
                    { 8, 8, new DateTime(2025, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1561), new DateTime(2022, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1560), "Golang" },
                    { 9, 9, new DateTime(2025, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1562), new DateTime(2022, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1562), "VueJS" },
                    { 10, 10, new DateTime(2025, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1564), new DateTime(2022, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1563), "Angular" },
                    { 11, 11, new DateTime(2025, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1566), new DateTime(2022, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1565), "Flutter" },
                    { 12, 12, new DateTime(2025, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1567), new DateTime(2022, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1567), "Java" },
                    { 13, 13, new DateTime(2025, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1569), new DateTime(2022, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1568), "C++" },
                    { 14, 14, new DateTime(2025, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1570), new DateTime(2022, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1570), "C" },
                    { 15, 15, new DateTime(2026, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1572), new DateTime(2022, 4, 21, 22, 0, 19, 929, DateTimeKind.Local).AddTicks(1571), "C#" }
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CourseId", "Name", "NumberOfSessions", "TeacherId", "Total" },
                values: new object[,]
                {
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

            migrationBuilder.CreateIndex(
                name: "IX_Grades_TeacherId",
                table: "Grades",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Accounts_TeacherId",
                table: "Grades",
                column: "TeacherId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Accounts_TeacherId",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_TeacherId",
                table: "Grades");

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Grades");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Grades",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "2");

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpiryDate", "IssueDate", "Name" },
                values: new object[] { new DateTime(2025, 4, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8885), new DateTime(2022, 4, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8876), "Software" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "Name", "StartDate", "Tuition" },
                values: new object[] { new DateTime(2022, 7, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8927), "Đồ án 1", new DateTime(2022, 4, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8926), 0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate", "Tuition" },
                values: new object[] { new DateTime(2022, 7, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8931), new DateTime(2022, 4, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8931), 0 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate", "Tuition" },
                values: new object[] { new DateTime(2022, 7, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8933), new DateTime(2022, 4, 20, 22, 35, 20, 975, DateTimeKind.Local).AddTicks(8933), 0 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "NumberOfSessions" },
                values: new object[] { "Đồ án 1 - 1", 0 });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "NumberOfSessions" },
                values: new object[] { "Đồ án 1 - 2", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Grades_AccountId",
                table: "Grades",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Accounts_AccountId",
                table: "Grades",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }
    }
}
