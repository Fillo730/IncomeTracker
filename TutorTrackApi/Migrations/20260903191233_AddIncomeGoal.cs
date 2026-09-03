using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorTrackApi.Migrations
{
    /// <inheritdoc />
    public partial class AddIncomeGoal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IncomeGoals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MonthlyAmount = table.Column<double>(type: "REAL", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeGoals", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 12, 33, 138, DateTimeKind.Utc).AddTicks(9022));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 12, 33, 138, DateTimeKind.Utc).AddTicks(9024));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 12, 33, 138, DateTimeKind.Utc).AddTicks(9025));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 12, 33, 138, DateTimeKind.Utc).AddTicks(9026));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 12, 33, 138, DateTimeKind.Utc).AddTicks(9026));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 12, 33, 138, DateTimeKind.Utc).AddTicks(9027));

            migrationBuilder.UpdateData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 12, 33, 138, DateTimeKind.Utc).AddTicks(9004));

            migrationBuilder.UpdateData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 12, 33, 138, DateTimeKind.Utc).AddTicks(9005));

            migrationBuilder.UpdateData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 12, 33, 138, DateTimeKind.Utc).AddTicks(9006));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 12, 33, 138, DateTimeKind.Utc).AddTicks(8915));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 12, 33, 138, DateTimeKind.Utc).AddTicks(8918));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncomeGoals");

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
        }
    }
}
