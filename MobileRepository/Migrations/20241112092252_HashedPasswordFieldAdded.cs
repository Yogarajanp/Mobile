using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MobileRepository.Migrations
{
    /// <inheritdoc />
    public partial class HashedPasswordFieldAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HashedPassword",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedDate", "HashedPassword" },
                values: new object[] { new DateTime(2024, 11, 12, 14, 52, 50, 760, DateTimeKind.Local).AddTicks(6430), "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashedPassword",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2024, 11, 12, 12, 6, 0, 64, DateTimeKind.Local).AddTicks(6579));
        }
    }
}
