using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorTrackApi.Migrations
{
    /// <inheritdoc />
    public partial class RemovedIncomeTYpe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 2);

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
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 14, 14, 37, 52, 607, DateTimeKind.Utc).AddTicks(2102));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 14, 14, 37, 52, 607, DateTimeKind.Utc).AddTicks(2103));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2608));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2609));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2610));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2611));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2612));

            migrationBuilder.UpdateData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2592));

            migrationBuilder.UpdateData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2594));

            migrationBuilder.InsertData(
                table: "IncomeTypes",
                columns: new[] { "Id", "CreatedAt", "Key" },
                values: new object[] { 2, new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2593), "MOVING" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2505));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 4, 14, 14, 28, 17, 7, DateTimeKind.Utc).AddTicks(2507));
        }
    }
}
