using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorTrackApi.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "IncomeEntries",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 18, 9, 9, 121, DateTimeKind.Utc).AddTicks(4662));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 18, 9, 9, 121, DateTimeKind.Utc).AddTicks(4666));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 18, 9, 9, 121, DateTimeKind.Utc).AddTicks(4667));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 18, 9, 9, 121, DateTimeKind.Utc).AddTicks(4668));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 18, 9, 9, 121, DateTimeKind.Utc).AddTicks(4668));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 18, 9, 9, 121, DateTimeKind.Utc).AddTicks(4669));

            migrationBuilder.UpdateData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 18, 9, 9, 121, DateTimeKind.Utc).AddTicks(4642));

            migrationBuilder.UpdateData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 18, 9, 9, 121, DateTimeKind.Utc).AddTicks(4645));

            migrationBuilder.UpdateData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 18, 9, 9, 121, DateTimeKind.Utc).AddTicks(4646));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 18, 9, 9, 121, DateTimeKind.Utc).AddTicks(4556));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 18, 9, 9, 121, DateTimeKind.Utc).AddTicks(4559));

            migrationBuilder.CreateIndex(
                name: "IX_IncomeEntries_StudentId",
                table: "IncomeEntries",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_IncomeEntries_Students_StudentId",
                table: "IncomeEntries",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IncomeEntries_Students_StudentId",
                table: "IncomeEntries");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropIndex(
                name: "IX_IncomeEntries_StudentId",
                table: "IncomeEntries");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "IncomeEntries");

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 2, 20, 5, 13, 117, DateTimeKind.Utc).AddTicks(909));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 2, 20, 5, 13, 117, DateTimeKind.Utc).AddTicks(912));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 2, 20, 5, 13, 117, DateTimeKind.Utc).AddTicks(913));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 2, 20, 5, 13, 117, DateTimeKind.Utc).AddTicks(914));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 2, 20, 5, 13, 117, DateTimeKind.Utc).AddTicks(915));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 2, 20, 5, 13, 117, DateTimeKind.Utc).AddTicks(916));

            migrationBuilder.UpdateData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 2, 20, 5, 13, 117, DateTimeKind.Utc).AddTicks(892));

            migrationBuilder.UpdateData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 2, 20, 5, 13, 117, DateTimeKind.Utc).AddTicks(894));

            migrationBuilder.UpdateData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 2, 20, 5, 13, 117, DateTimeKind.Utc).AddTicks(895));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 2, 20, 5, 13, 117, DateTimeKind.Utc).AddTicks(823));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 2, 20, 5, 13, 117, DateTimeKind.Utc).AddTicks(826));
        }
    }
}
