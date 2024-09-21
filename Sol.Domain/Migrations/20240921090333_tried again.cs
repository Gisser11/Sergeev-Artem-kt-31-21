using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sol.Domain.Migrations
{
    /// <inheritdoc />
    public partial class triedagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerfomanceMark_Discipline_fk_cd_perfomance_marks_discipline~",
                table: "PerfomanceMark");

            migrationBuilder.DropForeignKey(
                name: "FK_PerfomanceMark_Student_fk_cd_perfomance_marks_student_id",
                table: "PerfomanceMark");

            migrationBuilder.DropForeignKey(
                name: "FK_PerformanceBool_Discipline_DisciplineId",
                table: "PerformanceBool");

            migrationBuilder.DropForeignKey(
                name: "FK_PerformanceBool_Student_StudentId",
                table: "PerformanceBool");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Student",
                newName: "pk_cd_Student_id");

            migrationBuilder.RenameColumn(
                name: "b_result",
                table: "PerfomanceMark",
                newName: "n_result");

            migrationBuilder.RenameIndex(
                name: "IX_PerfomanceMark_fk_cd_perfomance_marks_student_id",
                table: "PerfomanceMark",
                newName: "fk_student_id");

            migrationBuilder.RenameIndex(
                name: "IX_PerfomanceMark_fk_cd_perfomance_marks_discipline_id",
                table: "PerfomanceMark",
                newName: "fk_discipline_id");

            migrationBuilder.RenameColumn(
                name: "i_speciality",
                table: "Discipline",
                newName: "n_speciality");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AcademicGroup",
                newName: "pk_cd_AcademicGroup_academic_group_id");

            migrationBuilder.AlterColumn<bool>(
                name: "b_result",
                table: "PerformanceBool",
                type: "bool",
                nullable: false,
                comment: "Первичный ключ",
                oldClrType: typeof(int),
                oldType: "int4",
                oldComment: "Первичный ключ");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "PerformanceBool",
                type: "int4",
                nullable: false,
                comment: "вторичный ключ",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "DisciplineId",
                table: "PerformanceBool",
                type: "int4",
                nullable: false,
                comment: "вторичный ключ",
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "c_name",
                table: "AcademicGroup",
                type: "varchar",
                nullable: false,
                comment: "Имя студента",
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "PerformanceBool",
                keyColumn: "Id",
                keyValue: 1,
                column: "b_result",
                value: true);

            migrationBuilder.UpdateData(
                table: "PerformanceBool",
                keyColumn: "Id",
                keyValue: 2,
                column: "b_result",
                value: false);

            migrationBuilder.UpdateData(
                table: "PerformanceBool",
                keyColumn: "Id",
                keyValue: 3,
                column: "b_result",
                value: true);

            migrationBuilder.UpdateData(
                table: "PerformanceBool",
                keyColumn: "Id",
                keyValue: 4,
                column: "b_result",
                value: true);

            migrationBuilder.UpdateData(
                table: "PerformanceBool",
                keyColumn: "Id",
                keyValue: 5,
                column: "b_result",
                value: true);

            migrationBuilder.UpdateData(
                table: "PerformanceBool",
                keyColumn: "Id",
                keyValue: 6,
                column: "b_result",
                value: true);

            migrationBuilder.UpdateData(
                table: "PerformanceBool",
                keyColumn: "Id",
                keyValue: 7,
                column: "b_result",
                value: false);

            migrationBuilder.AddForeignKey(
                name: "fk_discipline_id",
                table: "PerfomanceMark",
                column: "fk_cd_perfomance_marks_discipline_id",
                principalTable: "Discipline",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_student_id",
                table: "PerfomanceMark",
                column: "fk_cd_perfomance_marks_student_id",
                principalTable: "Student",
                principalColumn: "pk_cd_Student_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_discipline_id",
                table: "PerformanceBool",
                column: "DisciplineId",
                principalTable: "Discipline",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_student_id",
                table: "PerformanceBool",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "pk_cd_Student_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_discipline_id",
                table: "PerfomanceMark");

            migrationBuilder.DropForeignKey(
                name: "fk_student_id",
                table: "PerfomanceMark");

            migrationBuilder.DropForeignKey(
                name: "fk_discipline_id",
                table: "PerformanceBool");

            migrationBuilder.DropForeignKey(
                name: "fk_student_id",
                table: "PerformanceBool");

            migrationBuilder.RenameColumn(
                name: "pk_cd_Student_id",
                table: "Student",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "n_result",
                table: "PerfomanceMark",
                newName: "b_result");

            migrationBuilder.RenameIndex(
                name: "fk_student_id",
                table: "PerfomanceMark",
                newName: "IX_PerfomanceMark_fk_cd_perfomance_marks_student_id");

            migrationBuilder.RenameIndex(
                name: "fk_discipline_id",
                table: "PerfomanceMark",
                newName: "IX_PerfomanceMark_fk_cd_perfomance_marks_discipline_id");

            migrationBuilder.RenameColumn(
                name: "n_speciality",
                table: "Discipline",
                newName: "i_speciality");

            migrationBuilder.RenameColumn(
                name: "pk_cd_AcademicGroup_academic_group_id",
                table: "AcademicGroup",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "b_result",
                table: "PerformanceBool",
                type: "int4",
                nullable: false,
                comment: "Первичный ключ",
                oldClrType: typeof(bool),
                oldType: "bool",
                oldComment: "Первичный ключ");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "PerformanceBool",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4",
                oldComment: "вторичный ключ");

            migrationBuilder.AlterColumn<int>(
                name: "DisciplineId",
                table: "PerformanceBool",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int4",
                oldComment: "вторичный ключ");

            migrationBuilder.AlterColumn<string>(
                name: "c_name",
                table: "AcademicGroup",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar",
                oldComment: "Имя студента");

            migrationBuilder.UpdateData(
                table: "PerformanceBool",
                keyColumn: "Id",
                keyValue: 1,
                column: "b_result",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PerformanceBool",
                keyColumn: "Id",
                keyValue: 2,
                column: "b_result",
                value: 0);

            migrationBuilder.UpdateData(
                table: "PerformanceBool",
                keyColumn: "Id",
                keyValue: 3,
                column: "b_result",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PerformanceBool",
                keyColumn: "Id",
                keyValue: 4,
                column: "b_result",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PerformanceBool",
                keyColumn: "Id",
                keyValue: 5,
                column: "b_result",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PerformanceBool",
                keyColumn: "Id",
                keyValue: 6,
                column: "b_result",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PerformanceBool",
                keyColumn: "Id",
                keyValue: 7,
                column: "b_result",
                value: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfomanceMark_Discipline_fk_cd_perfomance_marks_discipline~",
                table: "PerfomanceMark",
                column: "fk_cd_perfomance_marks_discipline_id",
                principalTable: "Discipline",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerfomanceMark_Student_fk_cd_perfomance_marks_student_id",
                table: "PerfomanceMark",
                column: "fk_cd_perfomance_marks_student_id",
                principalTable: "Student",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerformanceBool_Discipline_DisciplineId",
                table: "PerformanceBool",
                column: "DisciplineId",
                principalTable: "Discipline",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PerformanceBool_Student_StudentId",
                table: "PerformanceBool",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
