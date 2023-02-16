using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KatmanliBlogSitesi.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 2, 14, 18, 42, 40, 76, DateTimeKind.Local).AddTicks(7718));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2022, 12, 28, 20, 52, 54, 980, DateTimeKind.Local).AddTicks(5977));
        }
    }
}
