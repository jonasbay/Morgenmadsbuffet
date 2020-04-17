using Microsoft.EntityFrameworkCore.Migrations;

namespace Morgenmadsbuffet.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckIns_BreakfastBookings_Date_RoomId",
                table: "CheckIns");

            migrationBuilder.DropIndex(
                name: "IX_CheckIns_Date_RoomId",
                table: "CheckIns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BreakfastBookings",
                table: "BreakfastBookings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BreakfastBookings",
                table: "BreakfastBookings",
                columns: new[] { "RoomId", "Date" });

            migrationBuilder.CreateIndex(
                name: "IX_CheckIns_RoomId_Date",
                table: "CheckIns",
                columns: new[] { "RoomId", "Date" });

            migrationBuilder.AddForeignKey(
                name: "FK_CheckIns_BreakfastBookings_RoomId_Date",
                table: "CheckIns",
                columns: new[] { "RoomId", "Date" },
                principalTable: "BreakfastBookings",
                principalColumns: new[] { "RoomId", "Date" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CheckIns_BreakfastBookings_RoomId_Date",
                table: "CheckIns");

            migrationBuilder.DropIndex(
                name: "IX_CheckIns_RoomId_Date",
                table: "CheckIns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BreakfastBookings",
                table: "BreakfastBookings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BreakfastBookings",
                table: "BreakfastBookings",
                columns: new[] { "Date", "RoomId" });

            migrationBuilder.CreateIndex(
                name: "IX_CheckIns_Date_RoomId",
                table: "CheckIns",
                columns: new[] { "Date", "RoomId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CheckIns_BreakfastBookings_Date_RoomId",
                table: "CheckIns",
                columns: new[] { "Date", "RoomId" },
                principalTable: "BreakfastBookings",
                principalColumns: new[] { "Date", "RoomId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
