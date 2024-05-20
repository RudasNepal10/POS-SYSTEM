using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructurre.Migrations
{
    /// <inheritdoc />
    public partial class new5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Paidamount",
                schema: "DBSchema",
                table: "PaymentMethod",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paidamount",
                schema: "DBSchema",
                table: "PaymentMethod");
        }
    }
}
