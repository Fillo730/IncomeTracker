using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TutorTrackApi.Migrations
{
    /// <inheritdoc />
    public partial class AddUserAuthentication : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 52, 52, 955, DateTimeKind.Utc).AddTicks(609));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 52, 52, 955, DateTimeKind.Utc).AddTicks(611));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 52, 52, 955, DateTimeKind.Utc).AddTicks(613));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 52, 52, 955, DateTimeKind.Utc).AddTicks(613));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 52, 52, 955, DateTimeKind.Utc).AddTicks(614));

            migrationBuilder.UpdateData(
                table: "IncomeTypeTranslations",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 52, 52, 955, DateTimeKind.Utc).AddTicks(615));

            migrationBuilder.UpdateData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 52, 52, 955, DateTimeKind.Utc).AddTicks(591));

            migrationBuilder.UpdateData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 52, 52, 955, DateTimeKind.Utc).AddTicks(592));

            migrationBuilder.UpdateData(
                table: "IncomeTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 52, 52, 955, DateTimeKind.Utc).AddTicks(593));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 52, 52, 955, DateTimeKind.Utc).AddTicks(507));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 9, 3, 19, 52, 52, 955, DateTimeKind.Utc).AddTicks(510));

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

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
    }
}
