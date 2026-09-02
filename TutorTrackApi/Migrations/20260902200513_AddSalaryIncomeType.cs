using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TutorTrackApi.Migrations
{
    /// <inheritdoc />
    public partial class AddSalaryIncomeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 4);

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

            migrationBuilder.InsertData(
                table: "IncomeTypes",
                columns: new[] { "Id", "CreatedAt", "Key" },
                values: new object[] { 4, new DateTime(2026, 9, 2, 20, 5, 13, 117, DateTimeKind.Utc).AddTicks(895), "SALARY" });

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

            migrationBuilder.InsertData(
                table: "IncomeTypeTranslations",
                columns: new[] { "Id", "CreatedAt", "IncomeTypeId", "LanguageId", "Name" },
                values: new object[,]
                {
                    { 7, new DateTime(2026, 9, 2, 20, 5, 13, 117, DateTimeKind.Utc).AddTicks(915), 4, 1, "Stipendio" },
                    { 8, new DateTime(2026, 9, 2, 20, 5, 13, 117, DateTimeKind.Utc).AddTicks(916), 4, 2, "Salary" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 14, 14, 37, 52, 607, DateTimeKind.Utc).AddTicks(2098));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 14, 14, 37, 52, 607, DateTimeKind.Utc).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 14, 14, 37, 52, 607, DateTimeKind.Utc).AddTicks(2104));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 14, 14, 37, 52, 607, DateTimeKind.Utc).AddTicks(2105));

            migrationBuilder.InsertData(
                table: "IncomeTypeTranslations",
                columns: new[] { "Id", "CreatedAt", "IncomeTypeId", "LanguageId", "Name" },
                values: new object[,]
                {
                    { 3, new DateTime(2026, 4, 14, 14, 37, 52, 607, DateTimeKind.Utc).AddTicks(2102), 2, 1, "Traslochi" },
                    { 4, new DateTime(2026, 4, 14, 14, 37, 52, 607, DateTimeKind.Utc).AddTicks(2103), 2, 2, "Moving" }
                });

            migrationBuilder.UpdateData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 14, 14, 37, 52, 607, DateTimeKind.Utc).AddTicks(2083));

            migrationBuilder.UpdateData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 14, 14, 37, 52, 607, DateTimeKind.Utc).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 14, 14, 37, 52, 607, DateTimeKind.Utc).AddTicks(2002));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 14, 14, 37, 52, 607, DateTimeKind.Utc).AddTicks(2005));
        }
    }
}
