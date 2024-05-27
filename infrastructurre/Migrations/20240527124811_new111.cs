using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructurre.Migrations
{
    /// <inheritdoc />
    public partial class new111 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "sales_date",
                schema: "DBSchema",
                table: "Sales",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sales_date",
                schema: "DBSchema",
                table: "Sales");
        }
    }
}
