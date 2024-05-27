using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructurre.Migrations
{
    /// <inheritdoc />
    public partial class new8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "quantity",
                schema: "DBSchema",
                table: "Sales",
                newName: "return_amount");

            migrationBuilder.AddColumn<decimal>(
                name: "due_amount",
                schema: "DBSchema",
                table: "Sales",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "due_amount",
                schema: "DBSchema",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "return_amount",
                schema: "DBSchema",
                table: "Sales",
                newName: "quantity");
        }
    }
}
