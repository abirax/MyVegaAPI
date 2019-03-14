using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyVegaApi.Migrations
{
    public partial class ChangingVehicles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
         
            migrationBuilder.DropColumn(
                name: "FeatureID",
                table: "Vehicles");

            
            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdate",
                table: "Vehicles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdate",
                table: "Vehicles");

            migrationBuilder.AddColumn<int>(
                name: "FeatureID",
                table: "Vehicles",
                nullable: false,
                defaultValue: 0);

            

            migrationBuilder.CreateIndex(
                name: "IX_Features_VehicleID",
                table: "Features",
                column: "VehicleID");

            
        }
    }
}
