using Microsoft.EntityFrameworkCore.Migrations;

namespace MyVegaApi.Migrations
{
    public partial class AddedtheVehicleFeatureTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactAddress",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Vehicles",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "Vehicles",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactAddress",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "Vehicles");
        }
    }
}
