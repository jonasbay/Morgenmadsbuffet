using Microsoft.EntityFrameworkCore.Migrations;

namespace Morgenmadsbuffet.Migrations
{
    public partial class admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Claim",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ClaimType",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaimType",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Claim",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
