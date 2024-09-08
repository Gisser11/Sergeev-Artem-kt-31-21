using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sol.Domain.Migrations
{
    /// <inheritdoc />
    public partial class finalchangesihope : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_PerformanceBool_DisciplineId",
                table: "PerformanceBool",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceBool_StudentId",
                table: "PerformanceBool",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerformanceBool");
        }
    }
}
