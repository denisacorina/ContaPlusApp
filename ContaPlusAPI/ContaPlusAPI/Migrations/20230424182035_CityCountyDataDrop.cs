using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContaPlusAPI.Migrations
{
    /// <inheritdoc />
    public partial class CityCountyDataDrop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Cities_Counties_CityCountyDataRegionNumber",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities_Counties",
                table: "Cities_Counties");

            migrationBuilder.RenameTable(
                name: "Cities_Counties",
                newName: "CityCountyData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CityCountyData",
                table: "CityCountyData",
                column: "RegionNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CityCountyData_CityCountyDataRegionNumber",
                table: "Companies",
                column: "CityCountyDataRegionNumber",
                principalTable: "CityCountyData",
                principalColumn: "RegionNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CityCountyData_CityCountyDataRegionNumber",
                table: "Companies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CityCountyData",
                table: "CityCountyData");

            migrationBuilder.RenameTable(
                name: "CityCountyData",
                newName: "Cities_Counties");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities_Counties",
                table: "Cities_Counties",
                column: "RegionNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Cities_Counties_CityCountyDataRegionNumber",
                table: "Companies",
                column: "CityCountyDataRegionNumber",
                principalTable: "Cities_Counties",
                principalColumn: "RegionNumber");
        }
    }
}
