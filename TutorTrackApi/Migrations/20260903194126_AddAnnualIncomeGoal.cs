using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorTrackApi.Migrations
{
    /// <inheritdoc />
    public partial class AddAnnualIncomeGoal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "AnnualAmount",
                table: "IncomeGoals",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 41, 26, 169, DateTimeKind.Utc).AddTicks(9243));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 41, 26, 169, DateTimeKind.Utc).AddTicks(9247));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 41, 26, 169, DateTimeKind.Utc).AddTicks(9248));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 41, 26, 169, DateTimeKind.Utc).AddTicks(9248));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 41, 26, 169, DateTimeKind.Utc).AddTicks(9249));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 41, 26, 169, DateTimeKind.Utc).AddTicks(9250));

            migrationBuilder.UpdateData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 41, 26, 169, DateTimeKind.Utc).AddTicks(9224));

            migrationBuilder.UpdateData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 41, 26, 169, DateTimeKind.Utc).AddTicks(9225));

            migrationBuilder.UpdateData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 41, 26, 169, DateTimeKind.Utc).AddTicks(9226));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 41, 26, 169, DateTimeKind.Utc).AddTicks(9106));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 41, 26, 169, DateTimeKind.Utc).AddTicks(9109));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnualAmount",
                table: "IncomeGoals");

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
    }
}
