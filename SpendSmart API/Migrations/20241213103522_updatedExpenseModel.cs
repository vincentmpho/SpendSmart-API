using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpendSmartAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatedExpenseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Expenses",
                newName: "ExpenseAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpenseAmount",
                table: "Expenses",
                newName: "Amount");
        }
    }
}
