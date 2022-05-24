using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cnpmnc.backend.Migrations
{
    public partial class TableAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    AssignToTeacherId = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Note = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AssignDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Accounts_AssignToTeacherId",
                        column: x => x.AssignToTeacherId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5699), new DateTime(2022, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5690) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5707), new DateTime(2022, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5707) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5708), new DateTime(2022, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5708) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5710), new DateTime(2022, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5709) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5711), new DateTime(2022, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5710) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5712), new DateTime(2022, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5712) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5713), new DateTime(2022, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5713) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5715), new DateTime(2022, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5714) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5716), new DateTime(2022, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5715) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5717), new DateTime(2022, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5716) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5718), new DateTime(2022, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5717) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5719), new DateTime(2022, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5718) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5720), new DateTime(2022, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5719) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5722), new DateTime(2022, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5722) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2026, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5723), new DateTime(2022, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5723) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 3, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5751), new DateTime(2022, 1, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5748) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5754), new DateTime(2022, 6, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5753) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 11, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5756), new DateTime(2021, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5755) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 8, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5759), new DateTime(2022, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5757) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5760), new DateTime(2022, 8, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5760) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5762), new DateTime(2022, 10, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5761) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5763), new DateTime(2022, 11, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5763) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5764), new DateTime(2022, 9, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5764) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 9, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5766), new DateTime(2022, 6, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5765) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 8, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5767), new DateTime(2022, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5766) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 8, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5768), new DateTime(2022, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5768) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 2, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5769), new DateTime(2021, 12, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5769) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 2, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5771), new DateTime(2021, 11, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5770) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5797), new DateTime(2021, 10, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5796) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 9, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5798), new DateTime(2022, 5, 24, 15, 7, 10, 84, DateTimeKind.Local).AddTicks(5798) });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssignToTeacherId",
                table: "Assignments",
                column: "AssignToTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_CourseId",
                table: "Assignments",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3069), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3059) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3077), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3077) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3079), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3078) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3080), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3080) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3081), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3081) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3082), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3082) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3084), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3083) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3085), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3085) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3086), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3086) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3087), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3087) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3088), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3088) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3089), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3089) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3091), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3090) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3095), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3094) });

            migrationBuilder.UpdateData(
                table: "Certificates",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ExpiryDate", "IssueDate" },
                values: new object[] { new DateTime(2026, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3096), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3096) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 3, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3132), new DateTime(2022, 1, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3128) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3135), new DateTime(2022, 6, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3134) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 11, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3137), new DateTime(2021, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3136) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 8, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3139), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3138) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 11, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3140), new DateTime(2022, 8, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3140) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3142), new DateTime(2022, 10, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3141) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3143), new DateTime(2022, 11, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3143) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3145), new DateTime(2022, 9, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3144) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 9, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3147), new DateTime(2022, 6, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3146) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 8, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3148), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3148) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 8, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3150), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3150) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 2, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3152), new DateTime(2021, 12, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3151) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 2, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3153), new DateTime(2021, 11, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3152) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 1, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3155), new DateTime(2021, 10, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3154) });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 9, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3156), new DateTime(2022, 5, 23, 14, 48, 58, 364, DateTimeKind.Local).AddTicks(3156) });
        }
    }
}
