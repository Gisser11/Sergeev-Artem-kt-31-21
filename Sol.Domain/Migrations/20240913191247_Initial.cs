using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sol.Domain.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Specialty = table.Column<bool>(type: "boolean", nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Specialty = table.Column<int>(type: "integer", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discipline", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    ThirdName = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    AcademicGroupId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_AcademicGroup_AcademicGroupId",
                        column: x => x.AcademicGroupId,
                        principalTable: "AcademicGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AcademicGroupAndDisciplines",
                columns: table => new
                {
                    AcademicGroupId = table.Column<int>(type: "integer", nullable: false),
                    DisciplineId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicGroupAndDisciplines", x => new { x.AcademicGroupId, x.DisciplineId });
                    table.ForeignKey(
                        name: "FK_AcademicGroupAndDisciplines_AcademicGroup_AcademicGroupId",
                        column: x => x.AcademicGroupId,
                        principalTable: "AcademicGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AcademicGroupAndDisciplines_Discipline_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Discipline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerformanceBool",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Result = table.Column<bool>(type: "boolean", nullable: false),
                    DisciplineId = table.Column<int>(type: "integer", nullable: false),
                    StudentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceBool", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerformanceBool_Discipline_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Discipline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerformanceBool_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AcademicGroup",
                columns: new[] { "Id", "Name", "Specialty", "Year" },
                values: new object[,]
                {
                    { 1, "kt-41-21", false, 2021 },
                    { 2, "kt-51-21", true, 2021 },
                    { 3, "kt-55-21", true, 2021 },
                    { 4, "kt-41-22", false, 2022 },
                    { 5, "kt-41-22", true, 2022 }
                });

            migrationBuilder.InsertData(
                table: "Discipline",
                columns: new[] { "Id", "IsDeleted", "Name", "Specialty" },
                values: new object[,]
                {
                    { 1, false, "Матеша1", 1 },
                    { 2, false, "Матеша2", 2 },
                    { 3, false, "Матеша3", 3 }
                });

            migrationBuilder.InsertData(
                table: "AcademicGroupAndDisciplines",
                columns: new[] { "AcademicGroupId", "DisciplineId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "AcademicGroupId", "IsDeleted", "Name", "Surname", "ThirdName" },
                values: new object[,]
                {
                    { 1, 1, false, "Iskakov", "", "" },
                    { 2, 1, true, "Ivlev", "", "" },
                    { 3, 1, true, "Ileeeva", "", "" },
                    { 4, 2, false, "Stolov", "", "" },
                    { 5, 2, false, "Krovatov", "", "" }
                });

            migrationBuilder.InsertData(
                table: "PerformanceBool",
                columns: new[] { "Id", "DisciplineId", "Result", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, true, 1 },
                    { 2, 2, false, 1 },
                    { 3, 3, true, 1 },
                    { 4, 3, true, 2 },
                    { 5, 3, true, 3 },
                    { 6, 3, true, 4 },
                    { 7, 1, false, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicGroupAndDisciplines_DisciplineId",
                table: "AcademicGroupAndDisciplines",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceBool_DisciplineId",
                table: "PerformanceBool",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceBool_StudentId",
                table: "PerformanceBool",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_AcademicGroupId",
                table: "Student",
                column: "AcademicGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicGroupAndDisciplines");

            migrationBuilder.DropTable(
                name: "PerformanceBool");

            migrationBuilder.DropTable(
                name: "Discipline");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "AcademicGroup");
        }
    }
}
