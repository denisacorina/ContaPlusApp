using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContaPlusAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreatedProductPurchaseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductPurchase",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    BoughtPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BoughtQuantity = table.Column<int>(type: "int", nullable: false),
                    TvaFromBoughtPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPriceWithoutTva = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPriceWithTva = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPurchase", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_ProductPurchase_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK_ProductPurchase_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_ProductPurchase_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "TransactionId");
                });

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 105,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 107,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 121,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 129,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 167,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 201,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 203,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 205,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 206,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 208,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 211,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 212,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 214,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 215,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 216,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 217,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 223,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 224,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 227,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 231,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 235,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 261,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 262,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 263,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 264,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 265,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 266,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 301,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 303,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 308,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 321,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 322,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 323,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 326,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 327,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 328,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 331,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 332,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 341,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 345,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 346,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 347,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 348,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 351,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 354,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 356,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 357,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 358,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 361,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 368,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 371,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 378,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 381,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 388,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 391,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 393,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 396,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 397,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 398,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 401,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 403,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 404,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 405,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 408,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 413,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 418,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 419,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 421,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 423,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 424,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 425,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 426,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 427,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 431,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 436,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 444,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 446,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 447,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 456,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 457,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 461,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 462,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 463,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 467,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 471,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 472,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 473,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 475,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 478,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 481,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 482,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 491,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 495,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 496,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 501,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 505,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 506,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 507,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 542,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 581,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 591,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 595,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 596,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 598,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 601,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 602,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 603,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 604,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 605,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 606,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 607,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 608,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 609,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 611,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 612,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 613,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 614,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 615,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 621,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 622,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 623,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 624,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 625,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 626,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 627,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 628,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 635,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 641,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 642,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 643,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 644,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 645,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 646,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 652,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 654,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 655,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 658,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 663,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 664,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 665,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 666,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 667,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 668,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 681,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 686,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 691,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 693,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 694,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 695,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 698,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 701,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 702,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 703,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 704,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 705,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 706,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 707,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 708,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 709,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 711,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 712,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 721,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 722,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 725,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 741,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 754,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 755,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 758,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 761,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 762,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 764,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 765,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 766,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 767,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 768,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 781,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 786,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 792,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 794,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 801,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 802,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 803,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 804,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 805,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 806,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 807,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 808,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 809,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 891,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 892,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 899,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1011,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1012,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1015,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1016,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1017,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1018,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1031,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1033,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1038,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1041,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1042,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1043,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1044,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1061,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1063,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1068,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1081,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1082,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1091,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1092,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1095,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1171,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1172,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1173,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1174,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1175,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1176,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1411,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1412,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1491,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1495,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1498,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1511,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1512,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1513,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1514,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1515,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1516,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1517,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1518,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1614,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1615,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1617,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1618,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1621,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1622,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1623,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1624,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1625,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1626,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1627,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1661,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1663,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1681,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1682,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1685,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1686,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1687,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1691,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1692,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2071,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2075,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2111,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2112,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2131,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2132,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2133,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2671,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2672,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2673,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2674,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2675,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2676,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2677,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2678,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2679,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2691,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2692,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2693,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2695,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2801,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2803,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2805,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2806,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2807,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2808,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2811,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2812,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2813,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2814,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2815,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2816,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2817,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2903,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2905,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2906,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2908,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2911,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2912,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2913,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2914,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2915,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2916,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2917,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2931,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2935,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2961,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2962,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2963,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2964,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2965,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2966,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2968,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3021,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3022,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3023,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3024,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3025,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3026,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3028,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3921,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3922,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3941,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3945,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3946,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3947,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3951,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3952,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3953,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3954,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3955,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3956,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3957,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3958,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4091,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4092,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4093,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4094,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4111,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4118,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4281,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4282,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4311,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4312,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4313,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4314,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4315,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4316,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4318,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4371,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4372,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4381,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4382,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4411,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4413,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4415,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4418,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4423,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4424,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4426,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4427,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4428,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4451,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4452,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4458,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4481,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4482,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4511,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4518,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4531,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4538,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4551,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4558,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4581,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4582,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4661,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4662,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4751,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4752,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4753,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4754,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4758,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4901,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4902,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4903,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4904,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5081,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5088,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5091,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5092,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5112,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5113,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5114,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5121,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5124,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5125,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5126,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5127,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5186,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5187,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5191,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5192,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5193,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5194,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5195,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5196,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5197,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5198,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5311,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5314,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5321,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5322,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5323,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5328,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5411,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5414,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6021,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6022,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6023,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6024,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6025,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6026,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6028,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6051,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6052,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6053,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6058,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6231,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6232,
                column: "Product_Service",
                value: "Serviciu");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6421,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6422,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6451,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6452,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6453,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6455,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6456,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6457,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6458,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6461,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6462,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6511,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6512,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6513,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6565,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6581,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6582,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6583,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6584,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6586,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6587,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6588,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6641,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6642,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6651,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6652,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6811,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6812,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6813,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6814,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6817,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6818,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6861,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6863,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6864,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6865,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6868,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7015,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7017,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7018,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7411,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7412,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7413,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7414,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7415,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7416,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7417,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7418,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7419,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7511,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7512,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7513,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7565,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7581,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7582,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7583,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7584,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7586,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7588,
                column: "Product_Service",
                value: "Bun");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7611,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7612,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7613,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7615,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7641,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7642,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7651,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7652,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7812,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7813,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7814,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7815,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7818,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7863,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7864,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7865,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8011,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8018,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8021,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8028,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8031,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8032,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8033,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8034,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8035,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8036,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8037,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8038,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8039,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8051,
                column: "Product_Service",
                value: "");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8052,
                column: "Product_Service",
                value: "");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPurchase_CompanyId",
                table: "ProductPurchase",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPurchase_ProductId",
                table: "ProductPurchase",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPurchase_TransactionId",
                table: "ProductPurchase",
                column: "TransactionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPurchase");

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 105,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 107,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 121,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 129,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 167,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 201,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 203,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 205,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 206,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 208,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 211,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 212,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 214,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 215,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 216,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 217,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 223,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 224,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 227,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 231,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 235,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 261,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 262,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 263,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 264,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 265,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 266,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 301,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 303,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 308,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 321,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 322,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 323,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 326,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 327,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 328,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 331,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 332,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 341,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 345,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 346,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 347,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 348,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 351,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 354,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 356,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 357,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 358,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 361,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 368,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 371,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 378,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 381,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 388,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 391,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 393,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 396,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 397,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 398,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 401,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 403,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 404,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 405,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 408,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 413,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 418,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 419,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 421,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 423,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 424,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 425,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 426,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 427,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 431,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 436,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 444,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 446,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 447,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 456,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 457,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 461,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 462,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 463,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 467,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 471,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 472,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 473,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 475,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 478,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 481,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 482,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 491,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 495,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 496,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 501,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 505,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 506,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 507,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 542,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 581,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 591,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 595,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 596,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 598,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 601,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 602,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 603,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 604,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 605,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 606,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 607,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 608,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 609,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 611,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 612,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 613,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 614,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 615,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 621,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 622,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 623,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 624,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 625,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 626,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 627,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 628,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 635,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 641,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 642,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 643,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 644,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 645,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 646,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 652,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 654,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 655,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 658,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 663,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 664,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 665,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 666,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 667,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 668,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 681,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 686,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 691,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 693,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 694,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 695,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 698,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 701,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 702,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 703,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 704,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 705,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 706,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 707,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 708,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 709,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 711,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 712,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 721,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 722,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 725,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 741,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 754,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 755,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 758,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 761,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 762,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 764,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 765,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 766,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 767,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 768,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 781,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 786,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 792,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 794,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 801,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 802,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 803,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 804,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 805,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 806,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 807,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 808,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 809,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 891,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 892,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 899,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1011,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1012,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1015,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1016,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1017,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1018,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1031,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1033,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1038,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1041,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1042,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1043,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1044,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1061,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1063,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1068,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1081,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1082,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1091,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1092,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1095,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1171,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1172,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1173,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1174,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1175,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1176,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1411,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1412,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1491,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1495,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1498,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1511,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1512,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1513,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1514,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1515,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1516,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1517,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1518,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1614,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1615,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1617,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1618,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1621,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1622,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1623,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1624,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1625,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1626,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1627,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1661,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1663,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1681,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1682,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1685,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1686,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1687,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1691,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 1692,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2071,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2075,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2111,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2112,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2131,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2132,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2133,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2671,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2672,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2673,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2674,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2675,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2676,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2677,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2678,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2679,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2691,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2692,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2693,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2695,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2801,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2803,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2805,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2806,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2807,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2808,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2811,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2812,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2813,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2814,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2815,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2816,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2817,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2903,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2905,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2906,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2908,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2911,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2912,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2913,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2914,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2915,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2916,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2917,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2931,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2935,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2961,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2962,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2963,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2964,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2965,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2966,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 2968,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3021,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3022,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3023,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3024,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3025,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3026,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3028,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3921,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3922,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3941,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3945,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3946,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3947,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3951,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3952,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3953,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3954,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3955,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3956,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3957,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 3958,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4091,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4092,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4093,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4094,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4111,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4118,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4281,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4282,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4311,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4312,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4313,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4314,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4315,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4316,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4318,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4371,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4372,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4381,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4382,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4411,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4413,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4415,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4418,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4423,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4424,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4426,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4427,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4428,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4451,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4452,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4458,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4481,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4482,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4511,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4518,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4531,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4538,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4551,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4558,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4581,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4582,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4661,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4662,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4751,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4752,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4753,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4754,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4758,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4901,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4902,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4903,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 4904,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5081,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5088,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5091,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5092,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5112,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5113,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5114,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5121,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5124,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5125,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5126,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5127,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5186,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5187,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5191,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5192,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5193,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5194,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5195,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5196,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5197,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5198,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5311,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5314,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5321,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5322,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5323,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5328,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5411,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 5414,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6021,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6022,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6023,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6024,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6025,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6026,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6028,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6051,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6052,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6053,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6058,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6231,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6232,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6421,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6422,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6451,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6452,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6453,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6455,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6456,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6457,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6458,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6461,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6462,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6511,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6512,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6513,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6565,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6581,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6582,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6583,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6584,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6586,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6587,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6588,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6641,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6642,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6651,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6652,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6811,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6812,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6813,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6814,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6817,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6818,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6861,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6863,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6864,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6865,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 6868,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7015,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7017,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7018,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7411,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7412,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7413,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7414,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7415,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7416,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7417,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7418,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7419,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7511,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7512,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7513,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7565,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7581,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7582,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7583,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7584,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7586,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7588,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7611,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7612,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7613,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7615,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7641,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7642,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7651,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7652,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7812,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7813,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7814,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7815,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7818,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7863,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7864,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 7865,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8011,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8018,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8021,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8028,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8031,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8032,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8033,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8034,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8035,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8036,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8037,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8038,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8039,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8051,
                column: "Product_Service",
                value: null);

            migrationBuilder.UpdateData(
                table: "GeneralChartOfAccounts",
                keyColumn: "AccountCode",
                keyValue: 8052,
                column: "Product_Service",
                value: null);
        }
    }
}
