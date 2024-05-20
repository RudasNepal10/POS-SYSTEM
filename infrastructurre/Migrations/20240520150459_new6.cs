using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructurre.Migrations
{
    /// <inheritdoc />
    public partial class new6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "total_prod_amount",
                schema: "DBSchema",
                table: "SalesProduct",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "paid_amount",
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
                name: "total_prod_amount",
                schema: "DBSchema",
                table: "SalesProduct");

            migrationBuilder.DropColumn(
                name: "paid_amount",
                schema: "DBSchema",
                table: "Sales");
        }
    }
}
