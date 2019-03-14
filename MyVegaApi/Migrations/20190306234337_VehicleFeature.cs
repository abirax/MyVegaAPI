using Microsoft.EntityFrameworkCore.Migrations;

namespace MyVegaApi.Migrations
{
    public partial class VehicleFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleFeature",
                columns: table => new
                {
                    VehicleID = table.Column<int>(nullable: false),
                    FeatureID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleFeature", x => new { x.VehicleID, x.FeatureID });
                    table.ForeignKey(
                        name: "FK_VehicleFeature_Features_FeatureID",
                        column: x => x.FeatureID,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VehicleFeature_Vehicles_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleFeature_FeatureID",
                table: "VehicleFeature",
                column: "FeatureID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleFeature");
        }
    }
}
