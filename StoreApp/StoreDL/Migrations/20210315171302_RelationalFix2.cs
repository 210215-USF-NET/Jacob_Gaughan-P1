using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;

namespace StoreDL.Migrations
{
    public partial class RelationalFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<int>>(
                name: "ProductIds",
                table: "Orders",
                type: "integer[]",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductIds",
                table: "Orders");
        }
    }
}