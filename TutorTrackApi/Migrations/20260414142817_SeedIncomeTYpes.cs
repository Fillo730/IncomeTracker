using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TutorTrackApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedIncomeTYpes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "IncomeTypes",
                columns: new[] { "Id", "CreatedAt", "Key" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2592), "TUTORING" },
                    { 2, new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2593), "MOVING" },
                    { 3, new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2594), "OTHER" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Code", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, "it", new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2505), "Italiano" },
                    { 2, "en", new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2507), "English" }
                });

            migrationBuilder.InsertData(
                table: "IncomeTypeTranslations",
                columns: new[] { "Id", "CreatedAt", "IncomeTypeId", "LanguageId", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2608), 1, 1, "Ripetizioni" },
                    { 2, new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2609), 1, 2, "Tutoring" },
                    { 3, new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2610), 2, 1, "Traslochi" },
                    { 4, new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2611), 2, 2, "Moving" },
                    { 5, new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2612), 3, 1, "Altro" },
                    { 6, new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2612), 3, 2, "Other" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
