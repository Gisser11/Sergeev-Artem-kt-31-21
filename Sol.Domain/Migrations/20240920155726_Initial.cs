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
                    c_name = table.Column<string>(type: "text", nullable: false),
                    n_specialty = table.Column<int>(type: "integer", nullable: false),
                    n_year = table.Column<int>(type: "integer", nullable: false)
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
                    c_name = table.Column<string>(type: "varchar", maxLength: 100, nullable: false, comment: "Имя студента"),
                    i_speciality = table.Column<int>(type: "int4", nullable: false, comment: "Специальность студента"),
                    b_deleted = table.Column<bool>(type: "bool", nullable: false, comment: "Существует ли студент")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_discipline_discipline_id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    с_surname = table.Column<string>(type: "varchar", nullable: false, comment: "Фамилия студента"),
                    c_name = table.Column<string>(type: "varchar", nullable: false, comment: "Имя студента"),
                    c_thirdname = table.Column<string>(type: "varchar", nullable: false, comment: "Фамилия студента"),
                    b_deleted = table.Column<bool>(type: "bool", nullable: false, comment: "существует ли студента"),
                    i_academic_group = table.Column<int>(type: "int4", nullable: false, comment: "группа студента")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.id);
                    table.ForeignKey(
                        name: "FK_Student_AcademicGroup_i_academic_group",
                        column: x => x.i_academic_group,
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
                name: "PerfomanceMark",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    b_result = table.Column<int>(type: "int4", nullable: false, comment: "Первичный ключ"),
                    fk_cd_perfomance_marks_discipline_id = table.Column<int>(type: "int4", nullable: false, comment: "вторичный ключ"),
                    fk_cd_perfomance_marks_student_id = table.Column<int>(type: "int4", nullable: false, comment: "вторичный ключ")
                },
                constraints: table =>
                {
                    table.PrimaryKey("cd_cd_perfomance_marks_perf_marks_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerfomanceMark_Discipline_fk_cd_perfomance_marks_discipline~",
                        column: x => x.fk_cd_perfomance_marks_discipline_id,
                        principalTable: "Discipline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PerfomanceMark_Student_fk_cd_perfomance_marks_student_id",
                        column: x => x.fk_cd_perfomance_marks_student_id,
                        principalTable: "Student",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerformanceBool",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int4", nullable: false, comment: "Первичный ключ")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    b_result = table.Column<int>(type: "int4", nullable: false, comment: "Первичный ключ"),
                    DisciplineId = table.Column<int>(type: "integer", nullable: false),
                    StudentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_perfomance_bools_perf_bools_id", x => x.Id);
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
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AcademicGroup",
                columns: new[] { "Id", "c_name", "n_specialty", "n_year" },
                values: new object[,]
                {
                    { 1, "kt-41-21", 1, 2021 },
                    { 2, "kt-51-21", 1, 2021 },
                    { 3, "kt-55-21", 2, 2021 },
                    { 4, "kt-41-22", 2, 2022 },
                    { 5, "kt-41-22", 1, 2022 }
                });

            migrationBuilder.InsertData(
                table: "Discipline",
                columns: new[] { "Id", "b_deleted", "c_name", "i_speciality" },
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
                columns: new[] { "id", "i_academic_group", "b_deleted", "c_name", "с_surname", "c_thirdname" },
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
                columns: new[] { "Id", "DisciplineId", "b_result", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 0, 1 },
                    { 3, 3, 1, 1 },
                    { 4, 3, 1, 2 },
                    { 5, 3, 1, 3 },
                    { 6, 3, 1, 4 },
                    { 7, 1, 0, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicGroupAndDisciplines_DisciplineId",
                table: "AcademicGroupAndDisciplines",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_PerfomanceMark_fk_cd_perfomance_marks_discipline_id",
                table: "PerfomanceMark",
                column: "fk_cd_perfomance_marks_discipline_id");

            migrationBuilder.CreateIndex(
                name: "IX_PerfomanceMark_fk_cd_perfomance_marks_student_id",
                table: "PerfomanceMark",
                column: "fk_cd_perfomance_marks_student_id");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceBool_DisciplineId",
                table: "PerformanceBool",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceBool_StudentId",
                table: "PerformanceBool",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_i_academic_group",
                table: "Student",
                column: "i_academic_group");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicGroupAndDisciplines");

            migrationBuilder.DropTable(
                name: "PerfomanceMark");

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
