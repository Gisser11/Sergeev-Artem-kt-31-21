using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sol.Domain.Migrations
{
    /// <inheritdoc />
    public partial class l : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_AcademicGroup_AcademicGroupId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameIndex(
                name: "IX_Students_AcademicGroupId",
                table: "Student",
                newName: "IX_Student_AcademicGroupId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AcademicGroup",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");

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
                    { 1, false, "Матеша1", true },
                    { 2, false, "Матеша2", true },
                    { 3, false, "Матеша3", true }
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

            migrationBuilder.AddForeignKey(
                name: "FK_Student_AcademicGroup_AcademicGroupId",
                table: "Student",
                column: "AcademicGroupId",
                principalTable: "AcademicGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_AcademicGroup_AcademicGroupId",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DeleteData(
                table: "AcademicGroup",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AcademicGroup",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AcademicGroupAndDisciplines",
                keyColumns: new[] { "AcademicGroupId", "DisciplineId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AcademicGroupAndDisciplines",
                keyColumns: new[] { "AcademicGroupId", "DisciplineId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "AcademicGroupAndDisciplines",
                keyColumns: new[] { "AcademicGroupId", "DisciplineId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "AcademicGroupAndDisciplines",
                keyColumns: new[] { "AcademicGroupId", "DisciplineId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "AcademicGroupAndDisciplines",
                keyColumns: new[] { "AcademicGroupId", "DisciplineId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "AcademicGroupAndDisciplines",
                keyColumns: new[] { "AcademicGroupId", "DisciplineId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AcademicGroup",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AcademicGroup",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AcademicGroup",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Discipline",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Discipline",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Discipline",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AcademicGroup");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameIndex(
                name: "IX_Student_AcademicGroupId",
                table: "Students",
                newName: "IX_Students_AcademicGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_AcademicGroup_AcademicGroupId",
                table: "Students",
                column: "AcademicGroupId",
                principalTable: "AcademicGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
