using Microsoft.EntityFrameworkCore.Migrations;

namespace Morgenmadsbuffet.Migrations
{
    public partial class foreignkeynew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckIns_BreakfastBookings_RoomId",
                table: "CheckIns");

            migrationBuilder.DropIndex(
                name: "IX_CheckIns_RoomId",
                table: "CheckIns");

            migrationBuilder.AddColumn<int>(
                name: "BreakfastBookingsModelsBreakfastBookingsModelId",
                table: "CheckIns",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckIns_BreakfastBookingsModelsBreakfastBookingsModelId",
                table: "CheckIns",
                column: "BreakfastBookingsModelsBreakfastBookingsModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckIns_BreakfastBookings_BreakfastBookingsModelsBreakfastBookingsModelId",
                table: "CheckIns",
                column: "BreakfastBookingsModelsBreakfastBookingsModelId",
                principalTable: "BreakfastBookings",
                principalColumn: "BreakfastBookingsModelId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckIns_BreakfastBookings_BreakfastBookingsModelsBreakfastBookingsModelId",
                table: "CheckIns");

            migrationBuilder.DropIndex(
                name: "IX_CheckIns_BreakfastBookingsModelsBreakfastBookingsModelId",
                table: "CheckIns");

            migrationBuilder.DropColumn(
                name: "BreakfastBookingsModelsBreakfastBookingsModelId",
                table: "CheckIns");

            migrationBuilder.CreateIndex(
                name: "IX_CheckIns_RoomId",
                table: "CheckIns",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_CheckIns_BreakfastBookings_RoomId",
                table: "CheckIns",
                column: "RoomId",
                principalTable: "BreakfastBookings",
                principalColumn: "BreakfastBookingsModelId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
