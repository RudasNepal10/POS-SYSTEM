using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructurre.Migrations
{
    /// <inheritdoc />
    public partial class new7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "vat_amount",
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
                name: "vat_amount",
                schema: "DBSchema",
                table: "Sales");
        }
    }
}
