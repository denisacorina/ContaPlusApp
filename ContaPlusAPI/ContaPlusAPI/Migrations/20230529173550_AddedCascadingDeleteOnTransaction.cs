using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContaPlusAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedCascadingDeleteOnTransaction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FiscalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeRegister = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CashBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TvaPayer = table.Column<bool>(type: "bit", nullable: false),
                    SocialCapital = table.Column<int>(type: "int", nullable: false),
                    Logo = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Signature = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "GeneralChartOfAccounts",
                columns: table => new
                {
                    AccountCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountType = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ProductService = table.Column<string>(name: "Product_Service", type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralChartOfAccounts", x => x.AccountCode);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RememberMe = table.Column<bool>(type: "bit", nullable: false),
                    ProfilePicture = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResetPasswordToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetTokenExpiration = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiscalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Clients_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsService = table.Column<bool>(type: "bit", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId");
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiscalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankAccount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                    table.ForeignKey(
                        name: "FK_Suppliers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId");
                });

            migrationBuilder.CreateTable(
                name: "CompanyChartOfAccounts",
                columns: table => new
                {
                    CompanyChartOfAccountsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountCode = table.Column<int>(type: "int", nullable: false),
                    InitialBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GeneralChartOfAccountsAccountCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyChartOfAccounts", x => x.CompanyChartOfAccountsId);
                    table.ForeignKey(
                        name: "FK_CompanyChartOfAccounts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK_CompanyChartOfAccounts_GeneralChartOfAccounts_GeneralChartOfAccountsAccountCode",
                        column: x => x.GeneralChartOfAccountsAccountCode,
                        principalTable: "GeneralChartOfAccounts",
                        principalColumn: "AccountCode");
                });

            migrationBuilder.CreateTable(
                name: "CompanyUser",
                columns: table => new
                {
                    CompaniesCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyUser", x => new { x.CompaniesCompanyId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_CompanyUser_Companies_CompaniesCompanyId",
                        column: x => x.CompaniesCompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCompanyRoles",
                columns: table => new
                {
                    UserCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCompanyRoles", x => x.UserCompanyId);
                    table.ForeignKey(
                        name: "FK_UserCompanyRoles_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK_UserCompanyRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentSeries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemainingAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebitAccountCode = table.Column<int>(type: "int", nullable: false),
                    CreditAccountCode = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId");
                    table.ForeignKey(
                        name: "FK_Transactions_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK_Transactions_GeneralChartOfAccounts_CreditAccountCode",
                        column: x => x.CreditAccountCode,
                        principalTable: "GeneralChartOfAccounts",
                        principalColumn: "AccountCode");
                    table.ForeignKey(
                        name: "FK_Transactions_GeneralChartOfAccounts_DebitAccountCode",
                        column: x => x.DebitAccountCode,
                        principalTable: "GeneralChartOfAccounts",
                        principalColumn: "AccountCode");
                    table.ForeignKey(
                        name: "FK_Transactions_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "RoleUserCompanyRole",
                columns: table => new
                {
                    RolesRoleId = table.Column<int>(type: "int", nullable: false),
                    RolesUserCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUserCompanyRole", x => new { x.RolesRoleId, x.RolesUserCompanyId });
                    table.ForeignKey(
                        name: "FK_RoleUserCompanyRole_Roles_RolesRoleId",
                        column: x => x.RolesRoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUserCompanyRole_UserCompanyRoles_RolesUserCompanyId",
                        column: x => x.RolesUserCompanyId,
                        principalTable: "UserCompanyRoles",
                        principalColumn: "UserCompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    PdfFile = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TransactionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Documents_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    SoldQuantity = table.Column<int>(type: "int", nullable: false),
                    TvaFromSellingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPriceWithoutTva = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPriceWithTva = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransactionId = table.Column<int>(type: "int", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSales", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_ProductSales_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId");
                    table.ForeignKey(
                        name: "FK_ProductSales_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_ProductSales_Transactions_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "TransactionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "GeneralChartOfAccounts",
                columns: new[] { "AccountCode", "AccountDescription", "AccountName", "AccountNumber", "AccountType", "Product_Service" },
                values: new object[,]
                {
                    { 105, "Rezerve din reevaluare", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 107, "Diferenţe de curs valutar din conversie", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 121, "Profit sau pierdere", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 129, "Repartizarea profitului", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", "" },
                    { 167, "Alte împrumuturi şi datorii asimilate", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "Serviciu" },
                    { 201, "Cheltuieli de constituire", "Conturi de imobilizari", 2, "A", "Serviciu" },
                    { 203, "Cheltuieli de dezvoltare", "Conturi de imobilizari", 2, "A", "Serviciu" },
                    { 205, "Concesiuni,Brevete, licenţe, mărci comerciale, drepturi şi active similare", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 206, "Active necorporale de explorare şi evaluare a resurselor minerale", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 208, "Alte imobilizări necorporale", "Conturi de imobilizari", 2, "A", "" },
                    { 211, "Terenuri şi amenajări de terenuri", "Conturi de imobilizari", 2, "A", "" },
                    { 212, "Construcţii", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 214, "Mobilier, aparaturăBirotică, echipamente de protecţie a valorilor umane şi materiale şi alte active corporale", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 215, "Investiţii imobiliare", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 216, "Active corporale de explorare şi evaluare a resurselor minerale", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 217, "ActiveBiologice productive", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 223, "Instalaţii tehnice şi mijloace de transport în curs de aprovizionare", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 224, "Mobilier, aparaturăBirotică, echipamente de protecţie a valorilor umane şi materiale şi alte active corporale în curs de aprovizionare", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 227, "ActiveBiologice productive în curs de aprovizionare", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 231, "Imobilizări corporale în curs de execuţie", "Conturi de imobilizari", 2, "A", "" },
                    { 235, "Investiţii imobiliare în curs de execuţie", "Conturi de imobilizari", 2, "A", "" },
                    { 261, "Acţiuni deţinute la entităţile afiliate", "Conturi de imobilizari", 2, "A", "" },
                    { 262, "Acţiuni deţinute la entităţi asociate", "Conturi de imobilizari", 2, "A", "" },
                    { 263, "Acţiuni deţinute la entităţi controlate în comun", "Conturi de imobilizari", 2, "A", "" },
                    { 264, "Titluri puse în echivalenţă", "Conturi de imobilizari", 2, "A", "" },
                    { 265, "Alte titluri imobilizate", "Conturi de imobilizari", 2, "A", "" },
                    { 266, "Certificate verzi amânate", "Conturi de imobilizari", 2, "A", "" },
                    { 301, "Materii prime", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 303, "Materiale de natura obiectelor de inventar", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 308, "Diferenţe de preţ la materii prime şi materiale", "Conturi de stocuri si productie in curs de executie", 3, "B", "Bun" },
                    { 321, "Materii prime în curs de aprovizionare", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 322, "Materiale consumabile în curs de aprovizionare", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 323, "Materiale de natura obiectelor de inventar în curs de aprovizionare", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 326, "ActiveBiologice de natura stocurilor în curs de aprovizionare", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 327, "Mărfuri în curs de aprovizionare", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 328, "Ambalaje în curs de aprovizionare", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 331, "Produse în curs de execuţie", "Conturi de stocuri si productie in curs de executie", 3, "A", "" },
                    { 332, "Servicii în curs de execuţie", "Conturi de stocuri si productie in curs de executie", 3, "A", "" },
                    { 341, "Semifabricate", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 345, "Produse finite", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 346, "Produse reziduale", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 347, "Produse agricole", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 348, "Diferenţe de preţ la produse", "Conturi de stocuri si productie in curs de executie", 3, "B", "" },
                    { 351, "Materii şi materiale aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "A", "" },
                    { 354, "Produse aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "A", "" },
                    { 356, "ActiveBiologice de natura stocurilor aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "A", "" },
                    { 357, "Mărfuri aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "A", "" },
                    { 358, "Ambalaje aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "A", "" },
                    { 361, "ActiveBiologice de natura stocurilor", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 368, "Diferenţe de preţ la activeBiologice de natura stocurilor", "Conturi de stocuri si productie in curs de executie", 3, "B", "" },
                    { 371, "Mărfuri", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 378, "Diferenţe de preţ la mărfuri", "Conturi de stocuri si productie in curs de executie", 3, "B", "" },
                    { 381, "Ambalaje", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 388, "Diferenţe de preţ la ambalaje", "Conturi de stocuri si productie in curs de executie", 3, "B", "" },
                    { 391, "Ajustări pentru deprecierea materiilor prime", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 393, "Ajustări pentru deprecierea producţiei în curs de execuţie", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 396, "Ajustări pentru deprecierea activelorBiologice de natura stocurilor", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 397, "Ajustări pentru deprecierea mărfurilor", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 398, "Ajustări pentru deprecierea ambalajelor", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 401, "Furnizori", "Conturi de terti", 4, "P", "" },
                    { 403, "Efecte de plătit", "Conturi de terti", 4, "P", "" },
                    { 404, "Furnizori de imobilizări", "Conturi de terti", 4, "P", "" },
                    { 405, "Efecte de plătit pentru imobilizări", "Conturi de terti", 4, "P", "" },
                    { 408, "Furnizori - facturi nesosite", "Conturi de terti", 4, "P", "Bun" },
                    { 413, "Efecte de primit de la clienţi", "Conturi de terti", 4, "A", "" },
                    { 418, "Clienţi - facturi de întocmit", "Conturi de terti", 4, "A", "Bun" },
                    { 419, "Clienţi - creditori", "Conturi de terti", 4, "P", "Bun" },
                    { 421, "Personal - salarii datorate", "Conturi de terti", 4, "P", "" },
                    { 423, "Personal - ajutoare materiale datorate", "Conturi de terti", 4, "P", "" },
                    { 424, "Prime reprezentând participarea personalului la profit", "Conturi de terti", 4, "P", "" },
                    { 425, "Avansuri acordate personalului", "Conturi de terti", 4, "A", "" },
                    { 426, "Drepturi de personal neridicate", "Conturi de terti", 4, "P", "" },
                    { 427, "Reţineri din salarii datorate terţilor", "Conturi de terti", 4, "P", "" },
                    { 431, "Asigurări sociale", "Conturi de terti", 4, "P", "" },
                    { 436, "Contribuţia asiguratorie pentru muncă", "Conturi de terti", 4, "P", "" },
                    { 444, "Impozitul pe venituri de natura salariilor", "Conturi de terti", 4, "P", "" },
                    { 446, "Alte impozite, taxe şi vărsăminte asimilate", "Conturi de terti", 4, "P", "" },
                    { 447, "Fonduri speciale - taxe şi vărsăminte asimilate", "Conturi de terti", 4, "P", "" },
                    { 456, "Decontări cu acţionarii/asociaţii privind capitalul", "Conturi de terti", 4, "B", "" },
                    { 457, "Dividende de plată", "Conturi de terti", 4, "P", "" },
                    { 461, "Debitori diverşi", "Conturi de terti", 4, "A", "" },
                    { 462, "Creditori diverşi", "Conturi de terti", 4, "P", "" },
                    { 463, "Creanţe reprezentând dividende repartizate în cursul exerciţiului financiar", "Conturi de terti", 4, "A", "" },
                    { 467, "Datorii aferente distribuirilor interimare de dividende", "Conturi de terti", 4, "P", "" },
                    { 471, "Cheltuieli înregistrate în avans", "Conturi de terti", 4, "A", "Serviciu" },
                    { 472, "Venituri înregistrate în avans", "Conturi de terti", 4, "P", "Serviciu" },
                    { 473, "Decontări din operaţiuni în curs de clarificare", "Conturi de terti", 4, "B", "" },
                    { 475, "Subvenţii pentru investiţii", "Conturi de terti", 4, "P", "" },
                    { 478, "Venituri în avans aferente activelor primite prin transfer de la clienţi", "Conturi de terti", 4, "P", "" },
                    { 481, "Decontări între unitate şi subunităţi", "Conturi de terti", 4, "B", "" },
                    { 482, "Decontări între subunităţi", "Conturi de terti", 4, "B", "" },
                    { 491, "Ajustări pentru deprecierea creanţelor - clienţi", "Conturi de terti", 4, "P", "" },
                    { 495, "Ajustări pentru deprecierea creanţelor - decontări în cadrul grupului şi cu acţionarii/asociaţii", "Conturi de terti", 4, "P", "" },
                    { 496, "Ajustări pentru deprecierea creanţelor - debitori diverşi", "Conturi de terti", 4, "P", "" },
                    { 501, "Acţiuni deţinute la entităţile afiliate", "Conturi de trezorerie", 5, "A", "" },
                    { 505, "Obligaţiuni emise şi răscumpărate", "Conturi de trezorerie", 5, "A", "" },
                    { 506, "Obligaţiuni", "Conturi de trezorerie", 5, "A", "" },
                    { 507, "Certificate verzi primite", "Conturi de trezorerie", 5, "A", "" },
                    { 542, "Avansuri de trezorerie", "Conturi de trezorerie", 5, "A", "" },
                    { 581, "Viramente interne", "Conturi de trezorerie", 5, "B", "" },
                    { 591, "Ajustări pentru pierderea de valoare a acţiunilor deţinute la entităţile afiliate", "Conturi de trezorerie", 5, "P", "" },
                    { 595, "Ajustări pentru pierderea de valoare a obligaţiunilor emise şi răscumpărate", "Conturi de trezorerie", 5, "P", "" },
                    { 596, "Ajustări pentru pierderea de valoare a obligaţiunilor", "Conturi de trezorerie", 5, "P", "" },
                    { 598, "Ajustări pentru pierderea de valoare a altor investiţii pe termen scurt şi creanţe asimilate", "Conturi de trezorerie", 5, "P", "" },
                    { 601, "Cheltuieli cu materiile prime", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 602, "Cheltuieli cu materialele consumabile", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 603, "Cheltuieli privind materialele de natura obiectelor de inventar", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 604, "Cheltuieli privind materialele nestocate", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 605, "Cheltuieli privind utilitățile", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 606, "Cheltuieli privind activeleBiologice de natura stocurilor", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 607, "Cheltuieli privind mărfurile", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 608, "Cheltuieli privind ambalajele", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 609, "Reduceri comerciale primite", "Conturi de cheltuieli", 6, "P", "Bun" },
                    { 611, "Cheltuieli cu întreţinerea şi reparaţiile", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 612, "Cheltuieli cu redevenţele, locaţiile de gestiune şi chiriile", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 613, "Cheltuieli cu primele de asigurare", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 614, "Cheltuieli cu studiile şi cercetările", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 615, "Cheltuieli cu pregătirea personalului", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 621, "Cheltuieli cu colaboratorii", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 622, "Cheltuieli privind comisioanele şi onorariile", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 623, "Cheltuieli de protocol, reclamă şi publicitate", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 624, "Cheltuieli cu transportul deBunuri şi personal", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 625, "Cheltuieli cu deplasări, detaşări şi transferări", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 626, "Cheltuieli poştale şi taxe de telecomunicaţii", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 627, "Cheltuieli cu serviciileBancare şi asimilate", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 628, "Alte cheltuieli cu serviciile executate de terţi", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 635, "Cheltuieli cu alte impozite, taxe şi vărsăminte asimilate", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 641, "Cheltuieli cu salariile personalului", "Conturi de cheltuieli", 6, "A", "" },
                    { 642, "Cheltuieli cu avantajele în natură şi tichetele acordate salariaţilor", "Conturi de cheltuieli", 6, "A", "" },
                    { 643, "Cheltuieli cu remunerarea în instrumente de capitaluri proprii", "Conturi de cheltuieli", 6, "A", "" },
                    { 644, "Cheltuieli cu primele reprezentând participarea personalului la profit", "Conturi de cheltuieli", 6, "A", "" },
                    { 645, "Cheltuieli privind asigurările şi protecţia socială", "Conturi de cheltuieli", 6, "A", "" },
                    { 646, "Cheltuieli privind contribuţia asiguratorie pentru muncă", "Conturi de cheltuieli", 6, "A", "" },
                    { 652, "Cheltuieli cu protecţia mediului înconjurător", "Conturi de cheltuieli", 6, "A", "" },
                    { 654, "Pierderi din creanţe şi debitori diverşi", "Conturi de cheltuieli", 6, "A", "" },
                    { 655, "Cheltuieli din reevaluarea imobilizărilor corporale", "Conturi de cheltuieli", 6, "A", "" },
                    { 658, "Alte cheltuieli de exploatare", "Conturi de cheltuieli", 6, "A", "" },
                    { 663, "Pierderi din creanţe legate de participaţii", "Conturi de cheltuieli", 6, "A", "" },
                    { 664, "Cheltuieli privind investiţiile financiare cedate", "Conturi de cheltuieli", 6, "A", "" },
                    { 665, "Cheltuieli din diferenţe de curs valutar", "Conturi de cheltuieli", 6, "A", "" },
                    { 666, "Cheltuieli privind dobânzile", "Conturi de cheltuieli", 6, "A", "" },
                    { 667, "Cheltuieli privind sconturile acordate", "Conturi de cheltuieli", 6, "A", "" },
                    { 668, "Alte cheltuieli financiare", "Conturi de cheltuieli", 6, "A", "" },
                    { 681, "Cheltuieli de exploatare privind amortizările, provizioanele şi ajustările pentru depreciere", "Conturi de cheltuieli", 6, "A", "" },
                    { 686, "Cheltuieli financiare privind amortizările, provizioanele şi ajustările pentru pierdere de valoare", "Conturi de cheltuieli", 6, "A", "" },
                    { 691, "Cheltuieli cu impozitul pe profit", "Conturi de cheltuieli", 6, "A", "" },
                    { 693, "Cheltuieli cu impozitul pe profit, determinate de incertitudinile legate de tratamentele fiscale", "Conturi de cheltuieli", 6, "A", "" },
                    { 694, "Cheltuieli cu impozitul pe profit rezultat din decontările în cadrul grupului fiscal în domeniul impozitului pe profit", "Conturi de cheltuieli", 6, "A", "" },
                    { 695, "Cheltuieli cu impozitul specific unor activităţi", "Conturi de cheltuieli", 6, "A", "" },
                    { 698, "Cheltuieli cu impozitul pe venit şi cu alte impozite care nu apar în elementele de mai sus", "Conturi de cheltuieli", 6, "A", "" },
                    { 701, "Venituri din vânzarea produselor finite, produselor agricole şi a activelorBiologice de natura stocurilor", "Conturi de venituri", 7, "P", "Bun" },
                    { 702, "Venituri din vânzarea semifabricatelor", "Conturi de venituri", 7, "P", "Bun" },
                    { 703, "Venituri din vânzarea produselor reziduale", "Conturi de venituri", 7, "P", "Bun" },
                    { 704, "Venituri din servicii prestate", "Conturi de venituri", 7, "P", "Serviciu" },
                    { 705, "Venituri din studii şi cercetări", "Conturi de venituri", 7, "P", "Serviciu" },
                    { 706, "Venituri din redevenţe, locaţii de gestiune şi chirii", "Conturi de venituri", 7, "P", "Serviciu" },
                    { 707, "Venituri din vânzarea mărfurilor", "Conturi de venituri", 7, "P", "Bun" },
                    { 708, "Venituri din activităţi diverse", "Conturi de venituri", 7, "P", "Bun" },
                    { 709, "Reduceri comerciale acordate", "Conturi de venituri", 7, "A", "Serviciu" },
                    { 711, "Venituri aferente costurilor stocurilor de produse", "Conturi de venituri", 7, "B", "" },
                    { 712, "Venituri aferente costurilor serviciilor în curs de execuţie", "Conturi de venituri", 7, "P", "" },
                    { 721, "Venituri din producţia de imobilizări necorporale", "Conturi de venituri", 7, "P", "" },
                    { 722, "Venituri din producţia de imobilizări corporale", "Conturi de venituri", 7, "P", "" },
                    { 725, "Venituri din producţia de investiţii imobiliare", "Conturi de venituri", 7, "P", "" },
                    { 741, "Venituri din subvenţii de exploatare", "Conturi de venituri", 7, "P", "" },
                    { 754, "Venituri din creanţe reactivate şi debitori diverşi", "Conturi de venituri", 7, "P", "" },
                    { 755, "Venituri din reevaluarea imobilizărilor corporale", "Conturi de venituri", 7, "P", "" },
                    { 758, "Alte venituri din exploatare", "Conturi de venituri", 7, "P", "" },
                    { 761, "Venituri din imobilizări financiare", "Conturi de venituri", 7, "P", "" },
                    { 762, "Venituri din investiţii financiare pe termen scurt", "Conturi de venituri", 7, "P", "" },
                    { 764, "Venituri din investiţii financiare cedate", "Conturi de venituri", 7, "P", "" },
                    { 765, "Venituri din diferenţe de curs valutar", "Conturi de venituri", 7, "P", "" },
                    { 766, "Venituri din dobânzi", "Conturi de venituri", 7, "P", "" },
                    { 767, "Venituri din sconturi obţinute", "Conturi de venituri", 7, "P", "" },
                    { 768, "Alte venituri financiare", "Conturi de venituri", 7, "P", "" },
                    { 781, "Venituri din provizioane şi ajustări pentru depreciere privind activitatea de exploatare", "Conturi de venituri", 7, "P", "" },
                    { 786, "Venituri financiare din amortizări şi ajustări pentru pierdere de valoare", "Conturi de venituri", 7, "P", "" },
                    { 792, "Venituri din impozitul pe profit amânat", "Conturi de venituri", 7, "P", "" },
                    { 794, "Venituri din impozitul pe profit rezultat din decontările în cadrul grupului fiscal în domeniul impozitului pe profit", "Conturi de venituri", 7, "P", "" },
                    { 801, "Angajamente acordate", "Conturi speciale", 8, "B", "" },
                    { 802, "Angajamente primite", "Conturi speciale", 8, "B", "" },
                    { 803, "Alte conturi în afaraBilanţului", "Conturi speciale", 8, "B", "" },
                    { 804, "Certificate verzi", "Conturi speciale", 8, "B", "" },
                    { 805, "Dobânzi aferente contractelor de leasing şi altor contracte asimilate, neajunse la scadenţă", "Conturi speciale", 8, "B", "" },
                    { 806, "Certificate de emisii de gaze cu efect de seră", "Conturi speciale", 8, "B", "" },
                    { 807, "Active contingente", "Conturi speciale", 8, "B", "" },
                    { 808, "Datorii contingente", "Conturi speciale", 8, "B", "" },
                    { 809, "Creanţe preluate prin cesionare", "Conturi speciale", 8, "B", "" },
                    { 891, "Bilanţ de deschidere", "Conturi speciale", 8, "B", "" },
                    { 892, "Bilanţ de închidere", "Conturi speciale", 8, "B", "" },
                    { 899, "Contrapartida", "Conturi speciale", 8, "B", "" },
                    { 1011, "Capital subscris nevărsat", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1012, "Capital subscris vărsat", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1015, "Patrimoniul regiei", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1016, "Patrimoniul public", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1017, "Patrimoniul privat", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1018, "Patrimoniul institutelor naţionale de cercetare-dezvoltare", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1031, "Beneficii acordate angajaţilor sub forma instrumentelor de capitaluri proprii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1033, "Diferenţe de curs valutar în relaţie cu investiţia netă într-o entitate străină", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 1038, "Diferenţe din modificarea valorii juste a activelor financiare disponibile în vederea vânzării şi alte elemente de capitaluri proprii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 1041, "Prime de emisiune", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1042, "Prime de fuziune/divizare", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1043, "Prime de aport", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1044, "Prime de conversie a obligaţiunilor în acţiuni", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1061, "Rezerve legale", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1063, "Rezerve statutare sau contractuale", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1068, "Alte rezerve", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1081, "Interese care nu controlează - rezultatul exerciţiului financiar", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 1082, "Interese care nu controlează - alte capitaluri proprii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 1091, "Acţiuni proprii deţinute pe termen scurt", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", "" },
                    { 1092, "Acţiuni proprii deţinute pe termen lung", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", "" },
                    { 1095, "Acţiuni proprii reprezentând titluri deţinute de societatea absorbită la societatea absorbantă", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", "" },
                    { 1171, "Rezultatul reportat reprezentând profitul nerepartizat sau pierderea neacoperită", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 1172, "Rezultatul reportat provenit din adoptarea pentru prima dată a IAS, mai puţin IAS 2911 ", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 1173, "Rezultatul reportat provenit din modificările politicilor contabile", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 1174, "Rezultatul reportat provenit din corectarea erorilor contabile", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 1175, "Rezultatul reportat reprezentând surplusul realizat din rezerve din reevaluare", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1176, "Rezultatul reportat provenit din trecerea la aplicarea reglementărilor contabile conforme cu directivele europene", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", "" },
                    { 1411, "Câştiguri legate de vânzarea instrumentelor de capitaluri proprii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1412, "Câştiguri legate de anularea instrumentelor de capitaluri proprii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1491, "Pierderi rezultate din vânzarea instrumentelor de capitaluri proprii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", "" },
                    { 1495, "Pierderi rezultate din reorganizări, care sunt determinate de anularea titlurilor deţinute", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", "" },
                    { 1498, "Alte pierderi legate de instrumentele de capitaluri proprii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", "" },
                    { 1511, "Provizioane pentru litigii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1512, "Provizioane pentru garanţii acordate clienţilor", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1513, "Provizioane pentru dezafectare imobilizări corporale şi alte acţiuni similare legate de acestea", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1514, "Provizioane pentru restructurare", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1515, "Provizioane pentru pensii şi obligaţii similare", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1516, "Provizioane pentru impozite", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1517, "Provizioane pentru terminarea contractului de muncă", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1518, "Alte provizioane", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1614, "Împrumuturi externe din emisiuni de obligaţiuni garantate de stat", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1615, "Împrumuturi externe din emisiuni de obligaţiuni garantate deBănci", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1617, "Împrumuturi interne din emisiuni de obligaţiuni garantate de stat", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1618, "Alte împrumuturi din emisiuni de obligaţiuni", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1621, "CrediteBancare pe termen lung", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1622, "CrediteBancare pe termen lung nerambursate la scadenţă", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1623, "Credite externe guvernamentale", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1624, "CrediteBancare externe garantate de stat", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1625, "CrediteBancare externe garantate deBănci", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1626, "Credite de la trezoreria statului", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1627, "CrediteBancare interne garantate de stat", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1661, "Datorii faţă de entităţile afiliate", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1663, "Datorii faţă de entităţile asociate şi entităţile controlate în comun", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1681, "Dobânzi aferente împrumuturilor din emisiuni de obligaţiuni", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1682, "Dobânzi aferente creditelorBancare pe termen lung", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1685, "Dobânzi aferente datoriilor faţă de entităţile afiliate", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1686, "Dobânzi aferente datoriilor faţă de entităţile asociate şi entităţile controlate în comun", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1687, "Dobânzi aferente altor împrumuturi şi datorii asimilate", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", "" },
                    { 1691, "Prime privind rambursarea obligaţiunilor", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", "" },
                    { 1692, "Prime privind rambursarea altor datorii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", "" },
                    { 2071, "Fond comercial pozitiv", "Conturi de imobilizari", 2, "A", "" },
                    { 2075, "Fond comercial negativ", "Conturi de imobilizari", 2, "P", "" },
                    { 2111, "Terenuri", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 2112, "Amenajări de terenuri", "Conturi de imobilizari", 2, "A", "" },
                    { 2131, "Echipamente tehnologice, maşini, utilaje şi instalaţii de lucru", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 2132, "Aparate şi instalaţii de măsurare, control şi reglare", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 2133, "Mijloace de transport", "Conturi de imobilizari", 2, "A", "Bun" },
                    { 2671, "Sume de încasat de la entităţile afiliate", "Conturi de imobilizari", 2, "A", "" },
                    { 2672, "Dobânda aferentă sumelor de încasat de la entităţile afiliate", "Conturi de imobilizari", 2, "A", "" },
                    { 2673, "Creanţe faţă de entităţile asociate şi entităţile controlate în comun", "Conturi de imobilizari", 2, "A", "" },
                    { 2674, "Dobânda aferentă creanţelor faţă de entităţile asociate şi entităţile controlate în comun", "Conturi de imobilizari", 2, "A", "" },
                    { 2675, "Împrumuturi acordate pe termen lung", "Conturi de imobilizari", 2, "A", "" },
                    { 2676, "Dobânda aferentă împrumuturilor acordate pe termen lung", "Conturi de imobilizari", 2, "A", "" },
                    { 2677, "Obligaţiuni achiziţionate cu ocazia emisiunilor efectuate de terţi", "Conturi de imobilizari", 2, "A", "" },
                    { 2678, "Alte creanţe imobilizate", "Conturi de imobilizari", 2, "A", "" },
                    { 2679, "Dobânzi aferente altor creanţe imobilizate", "Conturi de imobilizari", 2, "A", "" },
                    { 2691, "Vărsăminte de efectuat privind acţiunile deţinute la entităţile afiliate", "Conturi de imobilizari", 2, "P", "" },
                    { 2692, "Vărsăminte de efectuat privind acţiunile deţinute la entităţi asociate", "Conturi de imobilizari", 2, "P", "" },
                    { 2693, "Vărsăminte de efectuat privind acţiunile deţinute la entităţi controlate în comun", "Conturi de imobilizari", 2, "P", "" },
                    { 2695, "Vărsăminte de efectuat pentru alte imobilizări financiare", "Conturi de imobilizari", 2, "P", "" },
                    { 2801, "Amortizarea cheltuielilor de constituire", "Conturi de imobilizari", 2, "P", "" },
                    { 2803, "Amortizarea cheltuielilor de dezvoltare", "Conturi de imobilizari", 2, "P", "" },
                    { 2805, "Amortizarea concesiunilor,Brevetelor, licenţelor, mărcilor comerciale, drepturilor şi activelor similare", "Conturi de imobilizari", 2, "P", "" },
                    { 2806, "Amortizarea activelor necorporale de explorare şi evaluare a resurselor minerale", "Conturi de imobilizari", 2, "P", "" },
                    { 2807, "Amortizarea fondului comercial", "Conturi de imobilizari", 2, "P", "" },
                    { 2808, "Amortizarea altor imobilizări necorporale", "Conturi de imobilizari", 2, "P", "" },
                    { 2811, "Amortizarea amenajărilor de terenuri", "Conturi de imobilizari", 2, "P", "" },
                    { 2812, "Amortizarea construcţiilor", "Conturi de imobilizari", 2, "P", "" },
                    { 2813, "Amortizarea instalaţiilor şi mijloacelor de transport", "Conturi de imobilizari", 2, "P", "" },
                    { 2814, "Amortizarea altor imobilizări corporale", "Conturi de imobilizari", 2, "P", "" },
                    { 2815, "Amortizarea investiţiilor imobiliare", "Conturi de imobilizari", 2, "P", "" },
                    { 2816, "Amortizarea activelor corporale de explorare şi evaluare a resurselor minerale", "Conturi de imobilizari", 2, "P", "" },
                    { 2817, "Amortizarea activelorBiologice productive", "Conturi de imobilizari", 2, "P", "" },
                    { 2903, "Ajustări pentru deprecierea cheltuielilor de dezvoltare", "Conturi de imobilizari", 2, "P", "" },
                    { 2905, "Ajustări pentru deprecierea concesiunilor,Brevetelor, licenţelor, mărcilor comerciale, drepturilor şi activelor similare", "Conturi de imobilizari", 2, "P", "" },
                    { 2906, "Ajustări pentru deprecierea activelor necorporale de explorare şi evaluare a resurselor minerale", "Conturi de imobilizari", 2, "P", "" },
                    { 2908, "Ajustări pentru deprecierea altor imobilizări necorporale", "Conturi de imobilizari", 2, "P", "" },
                    { 2911, "Ajustări pentru deprecierea terenurilor şi amenajărilor de terenuri", "Conturi de imobilizari", 2, "P", "" },
                    { 2912, "Ajustări pentru deprecierea construcţiilor", "Conturi de imobilizari", 2, "P", "" },
                    { 2913, "Ajustări pentru deprecierea instalaţiilor şi mijloacelor de transport", "Conturi de imobilizari", 2, "P", "" },
                    { 2914, "Ajustări pentru deprecierea altor imobilizări corporale", "Conturi de imobilizari", 2, "P", "" },
                    { 2915, "Ajustări pentru deprecierea investiţiilor imobiliare", "Conturi de imobilizari", 2, "P", "" },
                    { 2916, "Ajustări pentru deprecierea activelor corporale de explorare şi evaluare a resurselor minerale", "Conturi de imobilizari", 2, "P", "" },
                    { 2917, "Ajustări pentru deprecierea activelorBiologice productive", "Conturi de imobilizari", 2, "P", "" },
                    { 2931, "Ajustări pentru deprecierea imobilizărilor corporale în curs de execuţie", "Conturi de imobilizari", 2, "P", "" },
                    { 2935, "Ajustări pentru deprecierea investiţiilor imobiliare în curs de execuţie", "Conturi de imobilizari", 2, "P", "" },
                    { 2961, "Ajustări pentru pierderea de valoare a acţiunilor deţinute la entităţile afiliate", "Conturi de imobilizari", 2, "P", "" },
                    { 2962, "Ajustări pentru pierderea de valoare a acţiunilor deţinute la entităţi asociate şi entităţi controlate în comun", "Conturi de imobilizari", 2, "P", "" },
                    { 2963, "Ajustări pentru pierderea de valoare a altor titluri imobilizate", "Conturi de imobilizari", 2, "P", "" },
                    { 2964, "Ajustări pentru pierderea de valoare a sumelor de încasat de la entităţile afiliate", "Conturi de imobilizari", 2, "P", "" },
                    { 2965, "Ajustări pentru pierderea de valoare a creanţelor faţă de entităţile asociate şi entităţile controlate în comun", "Conturi de imobilizari", 2, "P", "" },
                    { 2966, "Ajustări pentru pierderea de valoare a împrumuturilor acordate pe termen lung", "Conturi de imobilizari", 2, "P", "" },
                    { 2968, "Ajustări pentru pierderea de valoare a altor creanţe imobilizate", "Conturi de imobilizari", 2, "P", "" },
                    { 3021, "Materiale auxiliare", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 3022, "Combustibili", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 3023, "Materiale pentru ambalat", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 3024, "Piese de schimb", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 3025, "Seminţe şi materiale de plantat", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 3026, "Furaje", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 3028, "Alte materiale consumabile", "Conturi de stocuri si productie in curs de executie", 3, "A", "Bun" },
                    { 3921, "Ajustări pentru deprecierea materialelor consumabile", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3922, "Ajustări pentru deprecierea materialelor de natura obiectelor de inventar", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3941, "Ajustări pentru deprecierea semifabricatelor", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3945, "Ajustări pentru deprecierea produselor finite", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3946, "Ajustări pentru deprecierea produselor reziduale", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3947, "Ajustări pentru deprecierea produselor agricole", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3951, "Ajustări pentru deprecierea materiilor şi materialelor aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3952, "Ajustări pentru deprecierea semifabricatelor aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3953, "Ajustări pentru deprecierea produselor finite aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3954, "Ajustări pentru deprecierea produselor reziduale aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3955, "Ajustări pentru deprecierea produselor agricole aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3956, "Ajustări pentru deprecierea activelorBiologice de natura stocurilor aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3957, "Ajustări pentru deprecierea mărfurilor aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 3958, "Ajustări pentru deprecierea ambalajelor aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", "" },
                    { 4091, "Furnizori - debitori pentru cumpărări deBunuri de natura stocurilor", "Conturi de terti", 4, "A", "Bun" },
                    { 4092, "Furnizori - debitori pentru prestări de servicii", "Conturi de terti", 4, "A", "Serviciu" },
                    { 4093, "Avansuri acordate pentru imobilizări corporale", "Conturi de terti", 4, "A", "Bun" },
                    { 4094, "Avansuri acordate pentru imobilizări necorporale", "Conturi de terti", 4, "A", "Bun" },
                    { 4111, "Clienţi", "Conturi de terti", 4, "A", "" },
                    { 4118, "Clienţi incerţi sau în litigiu", "Conturi de terti", 4, "A", "" },
                    { 4281, "Alte datorii în legătură cu personalul", "Conturi de terti", 4, "P", "" },
                    { 4282, "Alte creanţe în legătură cu personalul", "Conturi de terti", 4, "A", "" },
                    { 4311, "Contribuţia unităţii la asigurările sociale", "Conturi de terti", 4, "P", "" },
                    { 4312, "Contribuţia personalului la asigurările sociale", "Conturi de terti", 4, "P", "" },
                    { 4313, "Contribuţia angajatorului pentru asigurările sociale de sănătate", "Conturi de terti", 4, "P", "" },
                    { 4314, "Contribuţia angajaţilor pentru asigurările sociale de sănătate", "Conturi de terti", 4, "P", "" },
                    { 4315, "Contribuţia de asigurări sociale", "Conturi de terti", 4, "P", "" },
                    { 4316, "Contribuţia de asigurări sociale de sănătate", "Conturi de terti", 4, "P", "" },
                    { 4318, "Alte contribuţii pentru asigurările sociale de sănătate", "Conturi de terti", 4, "P", "" },
                    { 4371, "Contribuţia unităţii la fondul de şomaj", "Conturi de terti", 4, "P", "" },
                    { 4372, "Contribuţia personalului la fondul de şomaj", "Conturi de terti", 4, "P", "" },
                    { 4381, "Alte datorii sociale", "Conturi de terti", 4, "P", "" },
                    { 4382, "Alte creanţe sociale", "Conturi de terti", 4, "A", "" },
                    { 4411, "Impozitul pe profit", "Conturi de terti", 4, "P", "" },
                    { 4413, "Diferențe de impozit determinate de incertitudinile legate de tratamentele fiscale", "Conturi de terti", 4, "B", "" },
                    { 4415, "Impozitul specific unor activităţi", "Conturi de terti", 4, "P", "" },
                    { 4418, "Impozitul pe venit", "Conturi de terti", 4, "P", "" },
                    { 4423, "TVA de plată", "Conturi de terti", 4, "P", "" },
                    { 4424, "TVA de recuperat", "Conturi de terti", 4, "A", "" },
                    { 4426, "TVA deductibilă", "Conturi de terti", 4, "A", "" },
                    { 4427, "TVA colectată", "Conturi de terti", 4, "P", "" },
                    { 4428, "TVA neexigibilă", "Conturi de terti", 4, "B", "" },
                    { 4451, "Subvenţii guvernamentale", "Conturi de terti", 4, "A", "" },
                    { 4452, "Împrumuturi nerambursabile cu caracter de subvenţii", "Conturi de terti", 4, "A", "" },
                    { 4458, "Alte sume primite cu caracter de subvenţii", "Conturi de terti", 4, "A", "" },
                    { 4481, "Alte datorii faţă deBugetul statului", "Conturi de terti", 4, "P", "" },
                    { 4482, "Alte creanţe privindBugetul statului", "Conturi de terti", 4, "A", "" },
                    { 4511, "Decontări între entităţile afiliate", "Conturi de terti", 4, "B", "" },
                    { 4518, "Dobânzi aferente decontărilor între entităţile afiliate", "Conturi de terti", 4, "B", "" },
                    { 4531, "Decontări cu entităţile asociate şi entităţile controlate", "Conturi de terti", 4, "B", "" },
                    { 4538, "Dobânzi aferente decontărilor cu entităţile asociate şi entităţile controlate în comun", "Conturi de terti", 4, "B", "" },
                    { 4551, "Acţionari/Asociaţi - conturi curente", "Conturi de terti", 4, "P", "" },
                    { 4558, "Acţionari/Asociaţi - dobânzi la conturi curente", "Conturi de terti", 4, "P", "" },
                    { 4581, "Decontări din operaţiuni în participaţie - pasiv", "Conturi de terti", 4, "P", "" },
                    { 4582, "Decontări din operaţiuni în participaţie - activ", "Conturi de terti", 4, "A", "" },
                    { 4661, "Datorii din operaţiuni de fiducie", "Conturi de terti", 4, "P", "" },
                    { 4662, "Creanţe din operaţiuni de fiducie", "Conturi de terti", 4, "A", "" },
                    { 4751, "Subvenţii guvernamentale pentru investiţii", "Conturi de terti", 4, "P", "" },
                    { 4752, "Împrumuturi nerambursabile cu caracter de subvenţii pentru investiţii", "Conturi de terti", 4, "P", "" },
                    { 4753, "Donaţii pentru investiţii", "Conturi de terti", 4, "P", "" },
                    { 4754, "Plusuri de inventar de natura imobilizărilor", "Conturi de terti", 4, "P", "" },
                    { 4758, "Alte sume primite cu caracter de subvenţii pentru investiţii", "Conturi de terti", 4, "P", "" },
                    { 4901, "Ajustări pentru deprecierea creanţelor aferente cumpărărilor deBunuri de natura stocurilor", "Conturi de terti", 4, "P", "" },
                    { 4902, "Ajustări pentru deprecierea creanţelor aferente prestărilor de servicii", "Conturi de terti", 4, "P", "" },
                    { 4903, "Ajustări pentru deprecierea creanţelor aferente imobilizărilor corporale", "Conturi de terti", 4, "P", "" },
                    { 4904, "Ajustări pentru deprecierea creanţelor aferente imobilizărilor necorporale", "Conturi de terti", 4, "P", "" },
                    { 5081, "Alte titluri de plasament", "Conturi de trezorerie", 5, "A", "" },
                    { 5088, "Dobânzi la obligaţiuni şi titluri de plasament", "Conturi de trezorerie", 5, "A", "" },
                    { 5091, "Vărsăminte de efectuat pentru acţiunile deţinute la entităţile afiliate", "Conturi de trezorerie", 5, "P", "" },
                    { 5092, "Vărsăminte de efectuat pentru alte investiţii pe termen scurt", "Conturi de trezorerie", 5, "P", "" },
                    { 5112, "Cecuri de încasat", "Conturi de trezorerie", 5, "A", "" },
                    { 5113, "Efecte de încasat", "Conturi de trezorerie", 5, "A", "" },
                    { 5114, "Efecte remise spre scontare", "Conturi de trezorerie", 5, "A", "" },
                    { 5121, "Conturi laBănci în lei", "Conturi de trezorerie", 5, "A", "" },
                    { 5124, "Conturi laBănci în valută", "Conturi de trezorerie", 5, "A", "" },
                    { 5125, "Sume în curs de decontare", "Conturi de trezorerie", 5, "A", "" },
                    { 5126, "Conturi laBănci în lei - TVA defalcat", "Conturi de trezorerie", 5, "A", "" },
                    { 5127, "Conturi laBănci în valută - TVA defalcat", "Conturi de trezorerie", 5, "A", "" },
                    { 5186, "Dobânzi de plătit", "Conturi de trezorerie", 5, "P", "" },
                    { 5187, "Dobânzi de încasat", "Conturi de trezorerie", 5, "A", "" },
                    { 5191, "CrediteBancare pe termen scurt", "Conturi de trezorerie", 5, "P", "" },
                    { 5192, "CrediteBancare pe termen scurt nerambursate la scadenţă", "Conturi de trezorerie", 5, "P", "" },
                    { 5193, "Credite externe guvernamentale", "Conturi de trezorerie", 5, "P", "" },
                    { 5194, "Credite externe garantate de stat", "Conturi de trezorerie", 5, "P", "" },
                    { 5195, "Credite externe garantate deBănci", "Conturi de trezorerie", 5, "P", "" },
                    { 5196, "Credite de la Trezoreria Statului", "Conturi de trezorerie", 5, "P", "" },
                    { 5197, "Credite interne garantate de stat", "Conturi de trezorerie", 5, "P", "" },
                    { 5198, "Dobânzi aferente creditelorBancare pe termen scurt", "Conturi de trezorerie", 5, "P", "" },
                    { 5311, "Casa în lei", "Conturi de trezorerie", 5, "A", "" },
                    { 5314, "Casa în valută", "Conturi de trezorerie", 5, "A", "" },
                    { 5321, "Timbre fiscale şi poştale", "Conturi de trezorerie", 5, "A", "" },
                    { 5322, "Bilete de tratament şi odihnă", "Conturi de trezorerie", 5, "A", "" },
                    { 5323, "Tichete şiBilete de călătorie", "Conturi de trezorerie", 5, "A", "" },
                    { 5328, "Alte valori", "Conturi de trezorerie", 5, "A", "" },
                    { 5411, "Acreditive în lei", "Conturi de trezorerie", 5, "A", "" },
                    { 5414, "Acreditive în valută", "Conturi de trezorerie", 5, "A", "" },
                    { 6021, "Cheltuieli cu materialele auxiliare", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6022, "Cheltuieli privind combustibilii", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6023, "Cheltuieli privind materialele pentru ambalat", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6024, "Cheltuieli privind piesele de schimb", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6025, "Cheltuieli privind seminţele şi materialele de plantat", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6026, "Cheltuieli privind furajele", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6028, "Cheltuieli privind alte materiale consumabile", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6051, "Cheltuieli privind consumul de energie", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6052, "Cheltuieli privind consumul de apă", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6053, "Cheltuieli privind consumul de gaze naturale", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6058, "Cheltuieli cu alte utilităţi", "Conturi de cheltuieli", 6, "A", "Bun" },
                    { 6231, "Cheltuieli de protocol", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 6232, "Cheltuieli de reclamă şi publicitate", "Conturi de cheltuieli", 6, "A", "Serviciu" },
                    { 6421, "Cheltuieli cu avantajele în natură acordate salariaţilor", "Conturi de cheltuieli", 6, "A", "" },
                    { 6422, "Cheltuieli cu tichetele acordate salariaţilor", "Conturi de cheltuieli", 6, "A", "" },
                    { 6451, "Cheltuieli privind contribuţia unităţii la asigurările sociale", "Conturi de cheltuieli", 6, "A", "" },
                    { 6452, "Cheltuieli privind contribuţia unităţii pentru ajutorul de şomaj", "Conturi de cheltuieli", 6, "A", "" },
                    { 6453, "Cheltuieli privind contribuţia angajatorului pentru asigurările sociale de sănătate", "Conturi de cheltuieli", 6, "A", "" },
                    { 6455, "Cheltuieli privind contribuţia unităţii la asigurările de viaţă", "Conturi de cheltuieli", 6, "A", "" },
                    { 6456, "Cheltuieli privind contribuţia unităţii la fondurile de pensii facultative", "Conturi de cheltuieli", 6, "A", "" },
                    { 6457, "Cheltuieli privind contribuţia unităţii la primele de asigurare voluntară de sănătate", "Conturi de cheltuieli", 6, "A", "" },
                    { 6458, "Alte cheltuieli privind asigurările şi protecţia socială", "Conturi de cheltuieli", 6, "A", "" },
                    { 6461, "Cheltuieli privind contribuția asiguratorie pentru muncă corespunzătoare salariaților", "Conturi de cheltuieli", 6, "A", "" },
                    { 6462, "Cheltuieli privind contribuția asiguratorie pentru muncă corespunzătoare altor persoane, decât salariații", "Conturi de cheltuieli", 6, "A", "" },
                    { 6511, "Cheltuieli ocazionate de constituirea fiduciei", "Conturi de cheltuieli", 6, "A", "" },
                    { 6512, "Cheltuieli din derularea operaţiunilor de fiducie", "Conturi de cheltuieli", 6, "A", "" },
                    { 6513, "Cheltuieli din lichidarea operaţiunilor de fiducie", "Conturi de cheltuieli", 6, "A", "" },
                    { 6565, "Pierderi din evaluarea la valoarea justă a activelor aferente dreptului de utilizare care corespund definiției unei investiții imobiliare", "Conturi de cheltuieli", 6, "A", "" },
                    { 6581, "Despăgubiri, amenzi şi penalităţi", "Conturi de cheltuieli", 6, "A", "" },
                    { 6582, "Donaţii acordate", "Conturi de cheltuieli", 6, "A", "" },
                    { 6583, "Cheltuieli privind activele cedate şi alte operaţiuni de capital", "Conturi de cheltuieli", 6, "A", "" },
                    { 6584, "Cheltuieli cu sumele sauBunurile acordate ca sponsorizări", "Conturi de cheltuieli", 6, "A", "" },
                    { 6586, "Cheltuieli reprezentând transferuri şi contribuţii datorate înBaza unor acte normative speciale", "Conturi de cheltuieli", 6, "A", "" },
                    { 6587, "Cheltuieli privind calamităţile şi alte evenimente similare", "Conturi de cheltuieli", 6, "A", "" },
                    { 6588, "Alte cheltuieli de exploatare", "Conturi de cheltuieli", 6, "A", "" },
                    { 6641, "Cheltuieli privind imobilizările financiare cedate", "Conturi de cheltuieli", 6, "A", "" },
                    { 6642, "Pierderi din investiţiile pe termen scurt cedate", "Conturi de cheltuieli", 6, "A", "" },
                    { 6651, "Diferenţe nefavorabile de curs valutar legate de elementele monetare exprimate în valută", "Conturi de cheltuieli", 6, "A", "" },
                    { 6652, "Diferenţe nefavorabile de curs valutar din evaluarea elementelor monetare care fac parte din investiţia netă într-o entitate străină", "Conturi de cheltuieli", 6, "A", "" },
                    { 6811, "Cheltuieli de exploatare privind amortizarea imobilizărilor", "Conturi de cheltuieli", 6, "A", "" },
                    { 6812, "Cheltuieli de exploatare privind provizioanele", "Conturi de cheltuieli", 6, "A", "" },
                    { 6813, "Cheltuieli de exploatare privind ajustările pentru deprecierea imobilizărilor", "Conturi de cheltuieli", 6, "A", "" },
                    { 6814, "Cheltuieli de exploatare privind ajustările pentru deprecierea activelor circulante", "Conturi de cheltuieli", 6, "A", "" },
                    { 6817, "Cheltuieli de exploatare privind ajustările pentru deprecierea fondului comercial", "Conturi de cheltuieli", 6, "A", "" },
                    { 6818, "Cheltuieli de exploatare privind ajustările pentru deprecierea creanţelor reprezentând avansuri acordate furnizorilor", "Conturi de cheltuieli", 6, "A", "" },
                    { 6861, "Cheltuieli privind actualizarea provizioanelor", "Conturi de cheltuieli", 6, "A", "" },
                    { 6863, "Cheltuieli financiare privind ajustările pentru pierderea de valoare a imobilizărilor financiare", "Conturi de cheltuieli", 6, "A", "" },
                    { 6864, "Cheltuieli financiare privind ajustările pentru pierderea de valoare a activelor circulante", "Conturi de cheltuieli", 6, "A", "" },
                    { 6865, "Cheltuieli financiare privind amortizarea diferenţelor aferente titlurilor de stat", "Conturi de cheltuieli", 6, "A", "" },
                    { 6868, "Cheltuieli financiare privind amortizarea primelor de rambursare a obligaţiunilor şi a altor datorii", "Conturi de cheltuieli", 6, "A", "" },
                    { 7015, "Venituri din vânzarea produselor finite", "Conturi de venituri", 7, "P", "Bun" },
                    { 7017, "Venituri din vânzarea produselor agricole", "Conturi de venituri", 7, "P", "Bun" },
                    { 7018, "Venituri din vânzarea activelorBiologice de natura stocurilor", "Conturi de venituri", 7, "P", "Bun" },
                    { 7411, "Venituri din subvenţii de exploatare aferente cifrei de afaceri", "Conturi de venituri", 7, "P", "" },
                    { 7412, "Venituri din subvenţii de exploatare pentru materii prime şi materiale", "Conturi de venituri", 7, "P", "" },
                    { 7413, "Venituri din subvenţii de exploatare pentru alte cheltuieli externe", "Conturi de venituri", 7, "P", "" },
                    { 7414, "Venituri din subvenţii de exploatare pentru plata personalului", "Conturi de venituri", 7, "P", "" },
                    { 7415, "Venituri din subvenţii de exploatare pentru asigurări şi protecţie socială", "Conturi de venituri", 7, "P", "" },
                    { 7416, "Venituri din subvenţii de exploatare pentru alte cheltuieli de exploatare", "Conturi de venituri", 7, "P", "" },
                    { 7417, "Venituri din subvenţii de exploatare în caz de calamităţi şi alte evenimente similare", "Conturi de venituri", 7, "P", "" },
                    { 7418, "Venituri din subvenţii de exploatare pentru dobânda datorată", "Conturi de venituri", 7, "P", "" },
                    { 7419, "Venituri din subvenţii de exploatare aferente altor venituri", "Conturi de venituri", 7, "P", "" },
                    { 7511, "Venituri ocazionate de constituirea fiduciei", "Conturi de venituri", 7, "P", "" },
                    { 7512, "Venituri din derularea operaţiunilor de fiducie", "Conturi de venituri", 7, "P", "" },
                    { 7513, "Venituri din lichidarea operaţiunilor de fiducie", "Conturi de venituri", 7, "P", "" },
                    { 7565, "Câștiguri din evaluarea la valoarea justă a activelor aferente dreptului de utilizare care corespund definiției unei investiții imobiliare", "Conturi de venituri", 7, "P", "" },
                    { 7581, "Venituri din despăgubiri, amenzi şi penalităţi", "Conturi de venituri", 7, "P", "" },
                    { 7582, "Venituri din donaţii primite", "Conturi de venituri", 7, "P", "" },
                    { 7583, "Venituri din vânzarea activelor şi alte operaţiuni de capital", "Conturi de venituri", 7, "P", "Bun" },
                    { 7584, "Venituri din subvenţii pentru investiţii", "Conturi de venituri", 7, "P", "" },
                    { 7586, "Venituri reprezentând transferuri cuvenite înBaza unor acte normative speciale", "Conturi de venituri", 7, "P", "" },
                    { 7588, "Alte venituri din exploatare", "Conturi de venituri", 7, "P", "Bun" },
                    { 7611, "Venituri din acţiuni deţinute la entităţile afiliate", "Conturi de venituri", 7, "P", "" },
                    { 7612, "Venituri din acţiuni deţinute la entităţi asociate", "Conturi de venituri", 7, "P", "" },
                    { 7613, "Venituri din acţiuni deţinute la entităţi controlate în comun", "Conturi de venituri", 7, "P", "" },
                    { 7615, "Venituri din alte imobilizări financiare", "Conturi de venituri", 7, "P", "" },
                    { 7641, "Venituri din imobilizări financiare cedate", "Conturi de venituri", 7, "P", "" },
                    { 7642, "Câştiguri din investiţii pe termen scurt cedate", "Conturi de venituri", 7, "P", "" },
                    { 7651, "Diferenţe favorabile de curs valutar legate de elementele monetare exprimate în valută", "Conturi de venituri", 7, "P", "" },
                    { 7652, "Diferenţe favorabile de curs valutar din evaluarea elementelor monetare care fac parte din investiţia netă într-o entitate străină", "Conturi de venituri", 7, "P", "" },
                    { 7812, "Venituri din provizioane", "Conturi de venituri", 7, "P", "" },
                    { 7813, "Venituri din ajustări pentru deprecierea imobilizărilor", "Conturi de venituri", 7, "P", "" },
                    { 7814, "Venituri din ajustări pentru deprecierea activelor circulante", "Conturi de venituri", 7, "P", "" },
                    { 7815, "Venituri din fondul comercial negativ", "Conturi de venituri", 7, "P", "" },
                    { 7818, "Venituri din ajustări pentru deprecierea creanţelor reprezentând avansuri acordate furnizorilor", "Conturi de venituri", 7, "P", "" },
                    { 7863, "Venituri financiare din ajustări pentru pierderea de valoare a imobilizărilor financiare", "Conturi de venituri", 7, "P", "" },
                    { 7864, "Venituri financiare din ajustări pentru pierderea de valoare a activelor circulante", "Conturi de venituri", 7, "P", "" },
                    { 7865, "Venituri financiare din amortizarea diferenţelor aferente titlurilor de stat", "Conturi de venituri", 7, "P", "" },
                    { 8011, "Giruri şi garanţii acordate", "Conturi speciale", 8, "B", "" },
                    { 8018, "Alte angajamente acordate", "Conturi speciale", 8, "B", "" },
                    { 8021, "Giruri şi garanţii primite", "Conturi speciale", 8, "B", "" },
                    { 8028, "Alte angajamente primite", "Conturi speciale", 8, "B", "" },
                    { 8031, "Imobilizări corporale primite cu chirie sau înBaza altor contracte similare", "Conturi speciale", 8, "B", "" },
                    { 8032, "Valori materiale primite spre prelucrare sau reparare", "Conturi speciale", 8, "B", "" },
                    { 8033, "Valori materiale primite în păstrare sau custodie", "Conturi speciale", 8, "B", "" },
                    { 8034, "Debitori scoşi din activ, urmăriţi în continuare", "Conturi speciale", 8, "B", "" },
                    { 8035, "Stocuri de natura obiectelor de inventar date în folosinţă", "Conturi speciale", 8, "B", "" },
                    { 8036, "Redevenţe, locaţii de gestiune, chirii şi alte datorii asimilate", "Conturi speciale", 8, "B", "" },
                    { 8037, "Efecte scontate neajunse la scadenţă", "Conturi speciale", 8, "B", "" },
                    { 8038, "Bunuri primite în administrare, concesiune, cu chirie şi alteBunuri similare", "Conturi speciale", 8, "B", "" },
                    { 8039, "Alte valori în afaraBilanţului", "Conturi speciale", 8, "B", "" },
                    { 8051, "Dobânzi de plătit", "Conturi speciale", 8, "B", "" },
                    { 8052, "Dobânzi de încasat", "Conturi speciale", 8, "B", "" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "accountant" },
                    { 3, "manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CompanyId",
                table: "Clients",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyChartOfAccounts_CompanyId",
                table: "CompanyChartOfAccounts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyChartOfAccounts_GeneralChartOfAccountsAccountCode",
                table: "CompanyChartOfAccounts",
                column: "GeneralChartOfAccountsAccountCode");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyUser_UsersUserId",
                table: "CompanyUser",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TransactionId",
                table: "Documents",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSales_CompanyId",
                table: "ProductSales",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSales_ProductId",
                table: "ProductSales",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSales_TransactionId",
                table: "ProductSales",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUserCompanyRole_RolesUserCompanyId",
                table: "RoleUserCompanyRole",
                column: "RolesUserCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CompanyId",
                table: "Suppliers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ClientId",
                table: "Transactions",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CompanyId",
                table: "Transactions",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CreditAccountCode",
                table: "Transactions",
                column: "CreditAccountCode");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_DebitAccountCode",
                table: "Transactions",
                column: "DebitAccountCode");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_SupplierId",
                table: "Transactions",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanyRoles_CompanyId",
                table: "UserCompanyRoles",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanyRoles_UserId",
                table: "UserCompanyRoles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyChartOfAccounts");

            migrationBuilder.DropTable(
                name: "CompanyUser");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "ProductSales");

            migrationBuilder.DropTable(
                name: "RoleUserCompanyRole");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserCompanyRoles");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "GeneralChartOfAccounts");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
