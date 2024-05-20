using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace infrastructurre.Migrations
{
    /// <inheritdoc />
    public partial class new4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SalesProduct_product_id",
                schema: "DBSchema",
                table: "SalesProduct",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesProduct_Product_product_id",
                schema: "DBSchema",
                table: "SalesProduct",
                column: "product_id",
                principalSchema: "DBSchema",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesProduct_Product_product_id",
                schema: "DBSchema",
                table: "SalesProduct");

            migrationBuilder.DropIndex(
                name: "IX_SalesProduct_product_id",
                schema: "DBSchema",
                table: "SalesProduct");
        }
    }
}
