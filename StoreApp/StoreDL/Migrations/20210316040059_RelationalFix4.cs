using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreDL.Migrations
{
    public partial class RelationalFix4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Carts_LocationId",
                table: "Carts");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_LocationId",
                table: "Carts",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Carts_LocationId",
                table: "Carts");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_LocationId",
                table: "Carts",
                column: "LocationId",
                unique: true);
        }
    }
}