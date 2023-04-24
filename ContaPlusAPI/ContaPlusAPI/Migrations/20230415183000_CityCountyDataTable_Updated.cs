using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContaPlusAPI.Migrations
{
    /// <inheritdoc />
    public partial class CityCountyDataTableUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Cities_Counties_CityCountyDataRegionNumber",
                table: "Companies");

            migrationBuilder.AlterColumn<int>(
                name: "CityCountyDataRegionNumber",
                table: "Companies",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Cities_Counties_CityCountyDataRegionNumber",
                table: "Companies",
                column: "CityCountyDataRegionNumber",
                principalTable: "Cities_Counties",
                principalColumn: "RegionNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Cities_Counties_CityCountyDataRegionNumber",
                table: "Companies");

            migrationBuilder.AlterColumn<int>(
                name: "CityCountyDataRegionNumber",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Cities_Counties_CityCountyDataRegionNumber",
                table: "Companies",
                column: "CityCountyDataRegionNumber",
                principalTable: "Cities_Counties",
                principalColumn: "RegionNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
