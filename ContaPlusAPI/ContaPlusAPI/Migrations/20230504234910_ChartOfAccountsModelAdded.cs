using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContaPlusAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChartOfAccountsModelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChartOfAccounts",
                columns: table => new
                {
                    AccountCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ProductService = table.Column<string>(name: "Product_Service", type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isDebit = table.Column<bool>(type: "bit", nullable: false),
                    isCredit = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartOfAccounts", x => x.AccountCode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChartOfAccounts");
        }
    }
}
