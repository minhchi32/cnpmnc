using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cnpmnc.backend.Migrations
{
    public partial class ChangeConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Username",
                value: "gv0001");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Username",
                value: "gv0002");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Username",
                value: "gv0003");

            migrationBuilder.InsertData(
                table: "AssignmentGrades",
                columns: new[] { "Id", "AssignDate", "AssignToTeacherId", "CourseId", "Semester", "State", "Total" },
                values: new object[,]
                {
                    { 2, new DateTime(2021, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 2, 2, 40 },
                    { 3, new DateTime(2021, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 2, 2, 40 },
                    { 4, new DateTime(2021, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, 3, 2, 40 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AssignmentGrades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AssignmentGrades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AssignmentGrades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Username",
                value: "gv1");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Username",
                value: "gv2");

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Username",
                value: "gv3");
        }
    }
}
