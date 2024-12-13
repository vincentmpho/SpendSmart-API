using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpendSmartAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateExprense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Expenses",
                newName: "Month");

            migrationBuilder.AddColumn<string>(
                name: "ExpenseType",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpenseType",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "Month",
                table: "Expenses",
                newName: "Description");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Expenses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
