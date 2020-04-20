using Microsoft.EntityFrameworkCore.Migrations;

namespace Morgenmadsbuffet.Migrations
{
    public partial class fixed_dataseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BreakfastBookings",
                columns: new[] { "BreakfastBookingsModelId", "AdultCount", "ChildCount", "Date", "RoomId" },
                values: new object[,]
                {
                    { 1, 1, 1, "01-01-2020", 1 },
                    { 2, 2, 2, "01-01-2020", 2 },
                    { 3, 2, 2, "01-01-2020", 3 },
                    { 4, 2, 2, "02-01-2020", 4 }
                });

            migrationBuilder.InsertData(
                table: "CheckIns",
                columns: new[] { "CheckInsModelId", "AdultCount", "BreakfastBookingsModelsBreakfastBookingsModelId", "ChildCount", "Date", "RoomId" },
                values: new object[,]
                {
                    { 1, 1, null, 0, "01-01-2020", 1 },
                    { 2, 0, null, 1, "01-01-2020", 1 },
                    { 3, 2, null, 2, "01-01-2020", 2 },
                    { 4, 2, null, 2, "02-01-2020", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BreakfastBookings",
                keyColumn: "BreakfastBookingsModelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BreakfastBookings",
                keyColumn: "BreakfastBookingsModelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BreakfastBookings",
                keyColumn: "BreakfastBookingsModelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BreakfastBookings",
                keyColumn: "BreakfastBookingsModelId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CheckIns",
                keyColumn: "CheckInsModelId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CheckIns",
                keyColumn: "CheckInsModelId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CheckIns",
                keyColumn: "CheckInsModelId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CheckIns",
                keyColumn: "CheckInsModelId",
                keyValue: 4);
        }
    }
}
