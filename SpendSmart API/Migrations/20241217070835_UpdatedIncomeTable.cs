using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpendSmartAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedIncomeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Incomes",
                newName: "CreatedAt");

            migrationBuilder.AddColumn<string>(
                name: "Investments",
                table: "Incomes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Month",
                table: "Incomes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Incomes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Investments",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Incomes");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Incomes",
                newName: "Date");
        }
    }
}
