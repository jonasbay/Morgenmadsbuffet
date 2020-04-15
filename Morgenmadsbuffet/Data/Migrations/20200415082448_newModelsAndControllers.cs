using Microsoft.EntityFrameworkCore.Migrations;

namespace Morgenmadsbuffet.Data.Migrations
{
    public partial class newModelsAndControllers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreakfastBookings",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: false),
                    AdultCount = table.Column<int>(nullable: false),
                    ChildCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreakfastBookings", x => new { x.RoomId, x.Date });
                });

            migrationBuilder.CreateTable(
                name: "CheckIns",
                columns: table => new
                {
                    CheckInsModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(nullable: false),
                    Date = table.Column<string>(nullable: true),
                    AdultCount = table.Column<int>(nullable: false),
                    ChildCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckIns", x => x.CheckInsModelId);
                    table.ForeignKey(
                        name: "FK_CheckIns_BreakfastBookings_RoomId_Date",
                        columns: x => new { x.RoomId, x.Date },
                        principalTable: "BreakfastBookings",
                        principalColumns: new[] { "RoomId", "Date" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckIns_RoomId_Date",
                table: "CheckIns",
                columns: new[] { "RoomId", "Date" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckIns");

            migrationBuilder.DropTable(
                name: "BreakfastBookings");
        }
    }
}
