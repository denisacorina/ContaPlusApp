using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContaPlusAPI.Migrations
{
    /// <inheritdoc />
    public partial class ReAddTables : Migration
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
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "CompanyChartOfAccounts",
                columns: table => new
                {
                    CompanyChartOfAccountsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountCode = table.Column<int>(type: "int", nullable: false),
                    InitialBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CurrentBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyChartOfAccounts", x => x.CompanyChartOfAccountsId);
                    table.ForeignKey(
                        name: "FK_CompanyChartOfAccounts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId");
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_Inventory_Companies_CompanyId",
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
                name: "GeneralChartOfAccounts",
                columns: table => new
                {
                    AccountCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountType = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    ProductService = table.Column<string>(name: "Product_Service", type: "nvarchar(max)", nullable: true),
                    AccountNumber = table.Column<int>(type: "int", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyChartOfAccountsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralChartOfAccounts", x => x.AccountCode);
                    table.ForeignKey(
                        name: "FK_GeneralChartOfAccounts_CompanyChartOfAccounts_CompanyChartOfAccountsId",
                        column: x => x.CompanyChartOfAccountsId,
                        principalTable: "CompanyChartOfAccounts",
                        principalColumn: "CompanyChartOfAccountsId");
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
                    InventoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "InventoryId");
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
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TransactionType = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebitAccountCode = table.Column<int>(type: "int", nullable: false),
                    CreditAccountCode = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InventoryId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_Transactions_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "InventoryId");
                    table.ForeignKey(
                        name: "FK_Transactions_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.InsertData(
                table: "GeneralChartOfAccounts",
                columns: new[] { "AccountCode", "AccountDescription", "AccountName", "AccountNumber", "AccountType", "CompanyChartOfAccountsId", "Product_Service" },
                values: new object[,]
                {
                    { 105, "Rezerve din reevaluare", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 107, "Diferenţe de curs valutar din conversie", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", null, "" },
                    { 121, "Profit sau pierdere", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", null, "" },
                    { 129, "Repartizarea profitului", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", null, "" },
                    { 167, "Alte împrumuturi şi datorii asimilate", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "Serviciu" },
                    { 201, "Cheltuieli de constituire", "Conturi de imobilizari", 2, "A", null, "Serviciu" },
                    { 203, "Cheltuieli de dezvoltare", "Conturi de imobilizari", 2, "A", null, "Serviciu" },
                    { 205, "Concesiuni,Brevete, licenţe, mărci comerciale, drepturi şi active similare", "Conturi de imobilizari", 2, "A", null, "Bun" },
                    { 206, "Active necorporale de explorare şi evaluare a resurselor minerale", "Conturi de imobilizari", 2, "A", null, "Bun" },
                    { 208, "Alte imobilizări necorporale", "Conturi de imobilizari", 2, "A", null, "" },
                    { 211, "Terenuri şi amenajări de terenuri", "Conturi de imobilizari", 2, "A", null, "" },
                    { 212, "Construcţii", "Conturi de imobilizari", 2, "A", null, "Bun" },
                    { 214, "Mobilier, aparaturăBirotică, echipamente de protecţie a valorilor umane şi materiale şi alte active corporale", "Conturi de imobilizari", 2, "A", null, "Bun" },
                    { 215, "Investiţii imobiliare", "Conturi de imobilizari", 2, "A", null, "Bun" },
                    { 216, "Active corporale de explorare şi evaluare a resurselor minerale", "Conturi de imobilizari", 2, "A", null, "Bun" },
                    { 217, "ActiveBiologice productive", "Conturi de imobilizari", 2, "A", null, "Bun" },
                    { 223, "Instalaţii tehnice şi mijloace de transport în curs de aprovizionare", "Conturi de imobilizari", 2, "A", null, "Bun" },
                    { 224, "Mobilier, aparaturăBirotică, echipamente de protecţie a valorilor umane şi materiale şi alte active corporale în curs de aprovizionare", "Conturi de imobilizari", 2, "A", null, "Bun" },
                    { 227, "ActiveBiologice productive în curs de aprovizionare", "Conturi de imobilizari", 2, "A", null, "Bun" },
                    { 231, "Imobilizări corporale în curs de execuţie", "Conturi de imobilizari", 2, "A", null, "" },
                    { 235, "Investiţii imobiliare în curs de execuţie", "Conturi de imobilizari", 2, "A", null, "" },
                    { 261, "Acţiuni deţinute la entităţile afiliate", "Conturi de imobilizari", 2, "A", null, "" },
                    { 262, "Acţiuni deţinute la entităţi asociate", "Conturi de imobilizari", 2, "A", null, "" },
                    { 263, "Acţiuni deţinute la entităţi controlate în comun", "Conturi de imobilizari", 2, "A", null, "" },
                    { 264, "Titluri puse în echivalenţă", "Conturi de imobilizari", 2, "A", null, "" },
                    { 265, "Alte titluri imobilizate", "Conturi de imobilizari", 2, "A", null, "" },
                    { 266, "Certificate verzi amânate", "Conturi de imobilizari", 2, "A", null, "" },
                    { 301, "Materii prime", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 303, "Materiale de natura obiectelor de inventar", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 308, "Diferenţe de preţ la materii prime şi materiale", "Conturi de stocuri si productie in curs de executie", 3, "B", null, "Bun" },
                    { 321, "Materii prime în curs de aprovizionare", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 322, "Materiale consumabile în curs de aprovizionare", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 323, "Materiale de natura obiectelor de inventar în curs de aprovizionare", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 326, "ActiveBiologice de natura stocurilor în curs de aprovizionare", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 327, "Mărfuri în curs de aprovizionare", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 328, "Ambalaje în curs de aprovizionare", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 331, "Produse în curs de execuţie", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "" },
                    { 332, "Servicii în curs de execuţie", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "" },
                    { 341, "Semifabricate", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 345, "Produse finite", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 346, "Produse reziduale", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 347, "Produse agricole", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 348, "Diferenţe de preţ la produse", "Conturi de stocuri si productie in curs de executie", 3, "B", null, "" },
                    { 351, "Materii şi materiale aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "" },
                    { 354, "Produse aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "" },
                    { 356, "ActiveBiologice de natura stocurilor aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "" },
                    { 357, "Mărfuri aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "" },
                    { 358, "Ambalaje aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "" },
                    { 361, "ActiveBiologice de natura stocurilor", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 368, "Diferenţe de preţ la activeBiologice de natura stocurilor", "Conturi de stocuri si productie in curs de executie", 3, "B", null, "" },
                    { 371, "Mărfuri", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 378, "Diferenţe de preţ la mărfuri", "Conturi de stocuri si productie in curs de executie", 3, "B", null, "" },
                    { 381, "Ambalaje", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 388, "Diferenţe de preţ la ambalaje", "Conturi de stocuri si productie in curs de executie", 3, "B", null, "" },
                    { 391, "Ajustări pentru deprecierea materiilor prime", "Conturi de stocuri si productie in curs de executie", 3, "P", null, "" },
                    { 393, "Ajustări pentru deprecierea producţiei în curs de execuţie", "Conturi de stocuri si productie in curs de executie", 3, "P", null, "" },
                    { 396, "Ajustări pentru deprecierea activelorBiologice de natura stocurilor", "Conturi de stocuri si productie in curs de executie", 3, "P", null, "" },
                    { 397, "Ajustări pentru deprecierea mărfurilor", "Conturi de stocuri si productie in curs de executie", 3, "P", null, "" },
                    { 398, "Ajustări pentru deprecierea ambalajelor", "Conturi de stocuri si productie in curs de executie", 3, "P", null, "" },
                    { 401, "Furnizori", "Conturi de terti", 4, "P", null, "" },
                    { 403, "Efecte de plătit", "Conturi de terti", 4, "P", null, "" },
                    { 404, "Furnizori de imobilizări", "Conturi de terti", 4, "P", null, "" },
                    { 405, "Efecte de plătit pentru imobilizări", "Conturi de terti", 4, "P", null, "" },
                    { 408, "Furnizori - facturi nesosite", "Conturi de terti", 4, "P", null, "Bun" },
                    { 413, "Efecte de primit de la clienţi", "Conturi de terti", 4, "A", null, "" },
                    { 418, "Clienţi - facturi de întocmit", "Conturi de terti", 4, "A", null, "Bun" },
                    { 419, "Clienţi - creditori", "Conturi de terti", 4, "P", null, "Bun" },
                    { 421, "Personal - salarii datorate", "Conturi de terti", 4, "P", null, "" },
                    { 423, "Personal - ajutoare materiale datorate", "Conturi de terti", 4, "P", null, "" },
                    { 424, "Prime reprezentând participarea personalului la profit", "Conturi de terti", 4, "P", null, "" },
                    { 425, "Avansuri acordate personalului", "Conturi de terti", 4, "A", null, "" },
                    { 426, "Drepturi de personal neridicate", "Conturi de terti", 4, "P", null, "" },
                    { 427, "Reţineri din salarii datorate terţilor", "Conturi de terti", 4, "P", null, "" },
                    { 431, "Asigurări sociale", "Conturi de terti", 4, "P", null, "" },
                    { 436, "Contribuţia asiguratorie pentru muncă", "Conturi de terti", 4, "P", null, "" },
                    { 444, "Impozitul pe venituri de natura salariilor", "Conturi de terti", 4, "P", null, "" },
                    { 446, "Alte impozite, taxe şi vărsăminte asimilate", "Conturi de terti", 4, "P", null, "" },
                    { 447, "Fonduri speciale - taxe şi vărsăminte asimilate", "Conturi de terti", 4, "P", null, "" },
                    { 456, "Decontări cu acţionarii/asociaţii privind capitalul", "Conturi de terti", 4, "B", null, "" },
                    { 457, "Dividende de plată", "Conturi de terti", 4, "P", null, "" },
                    { 461, "Debitori diverşi", "Conturi de terti", 4, "A", null, "" },
                    { 462, "Creditori diverşi", "Conturi de terti", 4, "P", null, "" },
                    { 463, "Creanţe reprezentând dividende repartizate în cursul exerciţiului financiar", "Conturi de terti", 4, "A", null, "" },
                    { 467, "Datorii aferente distribuirilor interimare de dividende", "Conturi de terti", 4, "P", null, "" },
                    { 471, "Cheltuieli înregistrate în avans", "Conturi de terti", 4, "A", null, "Serviciu" },
                    { 472, "Venituri înregistrate în avans", "Conturi de terti", 4, "P", null, "Serviciu" },
                    { 473, "Decontări din operaţiuni în curs de clarificare", "Conturi de terti", 4, "B", null, "" },
                    { 475, "Subvenţii pentru investiţii", "Conturi de terti", 4, "P", null, "" },
                    { 478, "Venituri în avans aferente activelor primite prin transfer de la clienţi", "Conturi de terti", 4, "P", null, "" },
                    { 481, "Decontări între unitate şi subunităţi", "Conturi de terti", 4, "B", null, "" },
                    { 482, "Decontări între subunităţi", "Conturi de terti", 4, "B", null, "" },
                    { 491, "Ajustări pentru deprecierea creanţelor - clienţi", "Conturi de terti", 4, "P", null, "" },
                    { 495, "Ajustări pentru deprecierea creanţelor - decontări în cadrul grupului şi cu acţionarii/asociaţii", "Conturi de terti", 4, "P", null, "" },
                    { 496, "Ajustări pentru deprecierea creanţelor - debitori diverşi", "Conturi de terti", 4, "P", null, "" },
                    { 501, "Acţiuni deţinute la entităţile afiliate", "Conturi de trezorerie", 5, "A", null, "" },
                    { 505, "Obligaţiuni emise şi răscumpărate", "Conturi de trezorerie", 5, "A", null, "" },
                    { 506, "Obligaţiuni", "Conturi de trezorerie", 5, "A", null, "" },
                    { 507, "Certificate verzi primite", "Conturi de trezorerie", 5, "A", null, "" },
                    { 542, "Avansuri de trezorerie", "Conturi de trezorerie", 5, "A", null, "" },
                    { 581, "Viramente interne", "Conturi de trezorerie", 5, "B", null, "" },
                    { 591, "Ajustări pentru pierderea de valoare a acţiunilor deţinute la entităţile afiliate", "Conturi de trezorerie", 5, "P", null, "" },
                    { 595, "Ajustări pentru pierderea de valoare a obligaţiunilor emise şi răscumpărate", "Conturi de trezorerie", 5, "P", null, "" },
                    { 596, "Ajustări pentru pierderea de valoare a obligaţiunilor", "Conturi de trezorerie", 5, "P", null, "" },
                    { 598, "Ajustări pentru pierderea de valoare a altor investiţii pe termen scurt şi creanţe asimilate", "Conturi de trezorerie", 5, "P", null, "" },
                    { 601, "Cheltuieli cu materiile prime", "Conturi de cheltuieli", 6, "A", null, "Bun" },
                    { 602, "Cheltuieli cu materialele consumabile", "Conturi de cheltuieli", 6, "A", null, "Bun" },
                    { 603, "Cheltuieli privind materialele de natura obiectelor de inventar", "Conturi de cheltuieli", 6, "A", null, "Bun" },
                    { 604, "Cheltuieli privind materialele nestocate", "Conturi de cheltuieli", 6, "A", null, "Bun" },
                    { 605, "Cheltuieli privind utilitățile", "Conturi de cheltuieli", 6, "A", null, "Bun" },
                    { 606, "Cheltuieli privind activeleBiologice de natura stocurilor", "Conturi de cheltuieli", 6, "A", null, "Bun" },
                    { 607, "Cheltuieli privind mărfurile", "Conturi de cheltuieli", 6, "A", null, "Bun" },
                    { 608, "Cheltuieli privind ambalajele", "Conturi de cheltuieli", 6, "A", null, "Bun" },
                    { 609, "Reduceri comerciale primite", "Conturi de cheltuieli", 6, "P", null, "Bun" },
                    { 611, "Cheltuieli cu întreţinerea şi reparaţiile", "Conturi de cheltuieli", 6, "A", null, "Serviciu" },
                    { 612, "Cheltuieli cu redevenţele, locaţiile de gestiune şi chiriile", "Conturi de cheltuieli", 6, "A", null, "Serviciu" },
                    { 613, "Cheltuieli cu primele de asigurare", "Conturi de cheltuieli", 6, "A", null, "Serviciu" },
                    { 614, "Cheltuieli cu studiile şi cercetările", "Conturi de cheltuieli", 6, "A", null, "Serviciu" },
                    { 615, "Cheltuieli cu pregătirea personalului", "Conturi de cheltuieli", 6, "A", null, "Serviciu" },
                    { 621, "Cheltuieli cu colaboratorii", "Conturi de cheltuieli", 6, "A", null, "Serviciu" },
                    { 622, "Cheltuieli privind comisioanele şi onorariile", "Conturi de cheltuieli", 6, "A", null, "Serviciu" },
                    { 623, "Cheltuieli de protocol, reclamă şi publicitate", "Conturi de cheltuieli", 6, "A", null, "Serviciu" },
                    { 624, "Cheltuieli cu transportul deBunuri şi personal", "Conturi de cheltuieli", 6, "A", null, "Serviciu" },
                    { 625, "Cheltuieli cu deplasări, detaşări şi transferări", "Conturi de cheltuieli", 6, "A", null, "Serviciu" },
                    { 626, "Cheltuieli poştale şi taxe de telecomunicaţii", "Conturi de cheltuieli", 6, "A", null, "Serviciu" },
                    { 627, "Cheltuieli cu serviciileBancare şi asimilate", "Conturi de cheltuieli", 6, "A", null, "Serviciu" },
                    { 628, "Alte cheltuieli cu serviciile executate de terţi", "Conturi de cheltuieli", 6, "A", null, "Serviciu" },
                    { 635, "Cheltuieli cu alte impozite, taxe şi vărsăminte asimilate", "Conturi de cheltuieli", 6, "A", null, "Serviciu" },
                    { 641, "Cheltuieli cu salariile personalului", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 642, "Cheltuieli cu avantajele în natură şi tichetele acordate salariaţilor", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 643, "Cheltuieli cu remunerarea în instrumente de capitaluri proprii", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 644, "Cheltuieli cu primele reprezentând participarea personalului la profit", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 645, "Cheltuieli privind asigurările şi protecţia socială", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 646, "Cheltuieli privind contribuţia asiguratorie pentru muncă", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 652, "Cheltuieli cu protecţia mediului înconjurător", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 654, "Pierderi din creanţe şi debitori diverşi", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 655, "Cheltuieli din reevaluarea imobilizărilor corporale", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 658, "Alte cheltuieli de exploatare", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 663, "Pierderi din creanţe legate de participaţii", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 664, "Cheltuieli privind investiţiile financiare cedate", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 665, "Cheltuieli din diferenţe de curs valutar", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 666, "Cheltuieli privind dobânzile", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 667, "Cheltuieli privind sconturile acordate", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 668, "Alte cheltuieli financiare", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 681, "Cheltuieli de exploatare privind amortizările, provizioanele şi ajustările pentru depreciere", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 686, "Cheltuieli financiare privind amortizările, provizioanele şi ajustările pentru pierdere de valoare", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 691, "Cheltuieli cu impozitul pe profit", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 693, "Cheltuieli cu impozitul pe profit, determinate de incertitudinile legate de tratamentele fiscale", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 694, "Cheltuieli cu impozitul pe profit rezultat din decontările în cadrul grupului fiscal în domeniul impozitului pe profit", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 695, "Cheltuieli cu impozitul specific unor activităţi", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 698, "Cheltuieli cu impozitul pe venit şi cu alte impozite care nu apar în elementele de mai sus", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 701, "Venituri din vânzarea produselor finite, produselor agricole şi a activelorBiologice de natura stocurilor", "Conturi de venituri", 7, "P", null, "Bun" },
                    { 702, "Venituri din vânzarea semifabricatelor", "Conturi de venituri", 7, "P", null, "Bun" },
                    { 703, "Venituri din vânzarea produselor reziduale", "Conturi de venituri", 7, "P", null, "Bun" },
                    { 704, "Venituri din servicii prestate", "Conturi de venituri", 7, "P", null, "Serviciu" },
                    { 705, "Venituri din studii şi cercetări", "Conturi de venituri", 7, "P", null, "Serviciu" },
                    { 706, "Venituri din redevenţe, locaţii de gestiune şi chirii", "Conturi de venituri", 7, "P", null, "Serviciu" },
                    { 707, "Venituri din vânzarea mărfurilor", "Conturi de venituri", 7, "P", null, "Bun" },
                    { 708, "Venituri din activităţi diverse", "Conturi de venituri", 7, "P", null, "Bun" },
                    { 709, "Reduceri comerciale acordate", "Conturi de venituri", 7, "A", null, "Serviciu" },
                    { 711, "Venituri aferente costurilor stocurilor de produse", "Conturi de venituri", 7, "B", null, "" },
                    { 712, "Venituri aferente costurilor serviciilor în curs de execuţie", "Conturi de venituri", 7, "P", null, "" },
                    { 721, "Venituri din producţia de imobilizări necorporale", "Conturi de venituri", 7, "P", null, "" },
                    { 722, "Venituri din producţia de imobilizări corporale", "Conturi de venituri", 7, "P", null, "" },
                    { 725, "Venituri din producţia de investiţii imobiliare", "Conturi de venituri", 7, "P", null, "" },
                    { 741, "Venituri din subvenţii de exploatare", "Conturi de venituri", 7, "P", null, "" },
                    { 754, "Venituri din creanţe reactivate şi debitori diverşi", "Conturi de venituri", 7, "P", null, "" },
                    { 755, "Venituri din reevaluarea imobilizărilor corporale", "Conturi de venituri", 7, "P", null, "" },
                    { 758, "Alte venituri din exploatare", "Conturi de venituri", 7, "P", null, "" },
                    { 761, "Venituri din imobilizări financiare", "Conturi de venituri", 7, "P", null, "" },
                    { 762, "Venituri din investiţii financiare pe termen scurt", "Conturi de venituri", 7, "P", null, "" },
                    { 764, "Venituri din investiţii financiare cedate", "Conturi de venituri", 7, "P", null, "" },
                    { 765, "Venituri din diferenţe de curs valutar", "Conturi de venituri", 7, "P", null, "" },
                    { 766, "Venituri din dobânzi", "Conturi de venituri", 7, "P", null, "" },
                    { 767, "Venituri din sconturi obţinute", "Conturi de venituri", 7, "P", null, "" },
                    { 768, "Alte venituri financiare", "Conturi de venituri", 7, "P", null, "" },
                    { 781, "Venituri din provizioane şi ajustări pentru depreciere privind activitatea de exploatare", "Conturi de venituri", 7, "P", null, "" },
                    { 786, "Venituri financiare din amortizări şi ajustări pentru pierdere de valoare", "Conturi de venituri", 7, "P", null, "" },
                    { 792, "Venituri din impozitul pe profit amânat", "Conturi de venituri", 7, "P", null, "" },
                    { 794, "Venituri din impozitul pe profit rezultat din decontările în cadrul grupului fiscal în domeniul impozitului pe profit", "Conturi de venituri", 7, "P", null, "" },
                    { 801, "Angajamente acordate", "Conturi speciale", 8, "B", null, "" },
                    { 802, "Angajamente primite", "Conturi speciale", 8, "B", null, "" },
                    { 803, "Alte conturi în afaraBilanţului", "Conturi speciale", 8, "B", null, "" },
                    { 804, "Certificate verzi", "Conturi speciale", 8, "B", null, "" },
                    { 805, "Dobânzi aferente contractelor de leasing şi altor contracte asimilate, neajunse la scadenţă", "Conturi speciale", 8, "B", null, "" },
                    { 806, "Certificate de emisii de gaze cu efect de seră", "Conturi speciale", 8, "B", null, "" },
                    { 807, "Active contingente", "Conturi speciale", 8, "B", null, "" },
                    { 808, "Datorii contingente", "Conturi speciale", 8, "B", null, "" },
                    { 809, "Creanţe preluate prin cesionare", "Conturi speciale", 8, "B", null, "" },
                    { 891, "Bilanţ de deschidere", "Conturi speciale", 8, "B", null, "" },
                    { 892, "Bilanţ de închidere", "Conturi speciale", 8, "B", null, "" },
                    { 899, "Contrapartida", "Conturi speciale", 8, "B", null, "" },
                    { 1011, "Capital subscris nevărsat", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1012, "Capital subscris vărsat", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1015, "Patrimoniul regiei", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1016, "Patrimoniul public", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1017, "Patrimoniul privat", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1018, "Patrimoniul institutelor naţionale de cercetare-dezvoltare", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1031, "Beneficii acordate angajaţilor sub forma instrumentelor de capitaluri proprii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1033, "Diferenţe de curs valutar în relaţie cu investiţia netă într-o entitate străină", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", null, "" },
                    { 1038, "Diferenţe din modificarea valorii juste a activelor financiare disponibile în vederea vânzării şi alte elemente de capitaluri proprii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", null, "" },
                    { 1041, "Prime de emisiune", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1042, "Prime de fuziune/divizare", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1043, "Prime de aport", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1044, "Prime de conversie a obligaţiunilor în acţiuni", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1061, "Rezerve legale", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1063, "Rezerve statutare sau contractuale", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1068, "Alte rezerve", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1081, "Interese care nu controlează - rezultatul exerciţiului financiar", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", null, "" },
                    { 1082, "Interese care nu controlează - alte capitaluri proprii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", null, "" },
                    { 1091, "Acţiuni proprii deţinute pe termen scurt", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", null, "" },
                    { 1092, "Acţiuni proprii deţinute pe termen lung", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", null, "" },
                    { 1095, "Acţiuni proprii reprezentând titluri deţinute de societatea absorbită la societatea absorbantă", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", null, "" },
                    { 1171, "Rezultatul reportat reprezentând profitul nerepartizat sau pierderea neacoperită", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", null, "" },
                    { 1172, "Rezultatul reportat provenit din adoptarea pentru prima dată a IAS, mai puţin IAS 2911 ", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", null, "" },
                    { 1173, "Rezultatul reportat provenit din modificările politicilor contabile", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", null, "" },
                    { 1174, "Rezultatul reportat provenit din corectarea erorilor contabile", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", null, "" },
                    { 1175, "Rezultatul reportat reprezentând surplusul realizat din rezerve din reevaluare", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1176, "Rezultatul reportat provenit din trecerea la aplicarea reglementărilor contabile conforme cu directivele europene", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "B", null, "" },
                    { 1411, "Câştiguri legate de vânzarea instrumentelor de capitaluri proprii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1412, "Câştiguri legate de anularea instrumentelor de capitaluri proprii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1491, "Pierderi rezultate din vânzarea instrumentelor de capitaluri proprii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", null, "" },
                    { 1495, "Pierderi rezultate din reorganizări, care sunt determinate de anularea titlurilor deţinute", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", null, "" },
                    { 1498, "Alte pierderi legate de instrumentele de capitaluri proprii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", null, "" },
                    { 1511, "Provizioane pentru litigii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1512, "Provizioane pentru garanţii acordate clienţilor", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1513, "Provizioane pentru dezafectare imobilizări corporale şi alte acţiuni similare legate de acestea", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1514, "Provizioane pentru restructurare", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1515, "Provizioane pentru pensii şi obligaţii similare", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1516, "Provizioane pentru impozite", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1517, "Provizioane pentru terminarea contractului de muncă", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1518, "Alte provizioane", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1614, "Împrumuturi externe din emisiuni de obligaţiuni garantate de stat", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1615, "Împrumuturi externe din emisiuni de obligaţiuni garantate deBănci", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1617, "Împrumuturi interne din emisiuni de obligaţiuni garantate de stat", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1618, "Alte împrumuturi din emisiuni de obligaţiuni", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1621, "CrediteBancare pe termen lung", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1622, "CrediteBancare pe termen lung nerambursate la scadenţă", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1623, "Credite externe guvernamentale", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1624, "CrediteBancare externe garantate de stat", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1625, "CrediteBancare externe garantate deBănci", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1626, "Credite de la trezoreria statului", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1627, "CrediteBancare interne garantate de stat", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1661, "Datorii faţă de entităţile afiliate", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1663, "Datorii faţă de entităţile asociate şi entităţile controlate în comun", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1681, "Dobânzi aferente împrumuturilor din emisiuni de obligaţiuni", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1682, "Dobânzi aferente creditelorBancare pe termen lung", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1685, "Dobânzi aferente datoriilor faţă de entităţile afiliate", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1686, "Dobânzi aferente datoriilor faţă de entităţile asociate şi entităţile controlate în comun", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1687, "Dobânzi aferente altor împrumuturi şi datorii asimilate", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "P", null, "" },
                    { 1691, "Prime privind rambursarea obligaţiunilor", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", null, "" },
                    { 1692, "Prime privind rambursarea altor datorii", "Conturi de capitaluri, provizioane, imprumuturi si datorii asimilate", 1, "A", null, "" },
                    { 2071, "Fond comercial pozitiv", "Conturi de imobilizari", 2, "A", null, "" },
                    { 2075, "Fond comercial negativ", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2111, "Terenuri", "Conturi de imobilizari", 2, "A", null, "Bun" },
                    { 2112, "Amenajări de terenuri", "Conturi de imobilizari", 2, "A", null, "" },
                    { 2131, "Echipamente tehnologice, maşini, utilaje şi instalaţii de lucru", "Conturi de imobilizari", 2, "A", null, "Bun" },
                    { 2132, "Aparate şi instalaţii de măsurare, control şi reglare", "Conturi de imobilizari", 2, "A", null, "Bun" },
                    { 2133, "Mijloace de transport", "Conturi de imobilizari", 2, "A", null, "Bun" },
                    { 2671, "Sume de încasat de la entităţile afiliate", "Conturi de imobilizari", 2, "A", null, "" },
                    { 2672, "Dobânda aferentă sumelor de încasat de la entităţile afiliate", "Conturi de imobilizari", 2, "A", null, "" },
                    { 2673, "Creanţe faţă de entităţile asociate şi entităţile controlate în comun", "Conturi de imobilizari", 2, "A", null, "" },
                    { 2674, "Dobânda aferentă creanţelor faţă de entităţile asociate şi entităţile controlate în comun", "Conturi de imobilizari", 2, "A", null, "" },
                    { 2675, "Împrumuturi acordate pe termen lung", "Conturi de imobilizari", 2, "A", null, "" },
                    { 2676, "Dobânda aferentă împrumuturilor acordate pe termen lung", "Conturi de imobilizari", 2, "A", null, "" },
                    { 2677, "Obligaţiuni achiziţionate cu ocazia emisiunilor efectuate de terţi", "Conturi de imobilizari", 2, "A", null, "" },
                    { 2678, "Alte creanţe imobilizate", "Conturi de imobilizari", 2, "A", null, "" },
                    { 2679, "Dobânzi aferente altor creanţe imobilizate", "Conturi de imobilizari", 2, "A", null, "" },
                    { 2691, "Vărsăminte de efectuat privind acţiunile deţinute la entităţile afiliate", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2692, "Vărsăminte de efectuat privind acţiunile deţinute la entităţi asociate", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2693, "Vărsăminte de efectuat privind acţiunile deţinute la entităţi controlate în comun", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2695, "Vărsăminte de efectuat pentru alte imobilizări financiare", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2801, "Amortizarea cheltuielilor de constituire", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2803, "Amortizarea cheltuielilor de dezvoltare", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2805, "Amortizarea concesiunilor,Brevetelor, licenţelor, mărcilor comerciale, drepturilor şi activelor similare", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2806, "Amortizarea activelor necorporale de explorare şi evaluare a resurselor minerale", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2807, "Amortizarea fondului comercial", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2808, "Amortizarea altor imobilizări necorporale", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2811, "Amortizarea amenajărilor de terenuri", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2812, "Amortizarea construcţiilor", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2813, "Amortizarea instalaţiilor şi mijloacelor de transport", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2814, "Amortizarea altor imobilizări corporale", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2815, "Amortizarea investiţiilor imobiliare", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2816, "Amortizarea activelor corporale de explorare şi evaluare a resurselor minerale", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2817, "Amortizarea activelorBiologice productive", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2903, "Ajustări pentru deprecierea cheltuielilor de dezvoltare", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2905, "Ajustări pentru deprecierea concesiunilor,Brevetelor, licenţelor, mărcilor comerciale, drepturilor şi activelor similare", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2906, "Ajustări pentru deprecierea activelor necorporale de explorare şi evaluare a resurselor minerale", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2908, "Ajustări pentru deprecierea altor imobilizări necorporale", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2911, "Ajustări pentru deprecierea terenurilor şi amenajărilor de terenuri", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2912, "Ajustări pentru deprecierea construcţiilor", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2913, "Ajustări pentru deprecierea instalaţiilor şi mijloacelor de transport", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2914, "Ajustări pentru deprecierea altor imobilizări corporale", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2915, "Ajustări pentru deprecierea investiţiilor imobiliare", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2916, "Ajustări pentru deprecierea activelor corporale de explorare şi evaluare a resurselor minerale", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2917, "Ajustări pentru deprecierea activelorBiologice productive", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2931, "Ajustări pentru deprecierea imobilizărilor corporale în curs de execuţie", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2935, "Ajustări pentru deprecierea investiţiilor imobiliare în curs de execuţie", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2961, "Ajustări pentru pierderea de valoare a acţiunilor deţinute la entităţile afiliate", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2962, "Ajustări pentru pierderea de valoare a acţiunilor deţinute la entităţi asociate şi entităţi controlate în comun", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2963, "Ajustări pentru pierderea de valoare a altor titluri imobilizate", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2964, "Ajustări pentru pierderea de valoare a sumelor de încasat de la entităţile afiliate", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2965, "Ajustări pentru pierderea de valoare a creanţelor faţă de entităţile asociate şi entităţile controlate în comun", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2966, "Ajustări pentru pierderea de valoare a împrumuturilor acordate pe termen lung", "Conturi de imobilizari", 2, "P", null, "" },
                    { 2968, "Ajustări pentru pierderea de valoare a altor creanţe imobilizate", "Conturi de imobilizari", 2, "P", null, "" },
                    { 3021, "Materiale auxiliare", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 3022, "Combustibili", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 3023, "Materiale pentru ambalat", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 3024, "Piese de schimb", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 3025, "Seminţe şi materiale de plantat", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 3026, "Furaje", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 3028, "Alte materiale consumabile", "Conturi de stocuri si productie in curs de executie", 3, "A", null, "Bun" },
                    { 3921, "Ajustări pentru deprecierea materialelor consumabile", "Conturi de stocuri si productie in curs de executie", 3, "P", null, "" },
                    { 3922, "Ajustări pentru deprecierea materialelor de natura obiectelor de inventar", "Conturi de stocuri si productie in curs de executie", 3, "P", null, "" },
                    { 3941, "Ajustări pentru deprecierea semifabricatelor", "Conturi de stocuri si productie in curs de executie", 3, "P", null, "" },
                    { 3945, "Ajustări pentru deprecierea produselor finite", "Conturi de stocuri si productie in curs de executie", 3, "P", null, "" },
                    { 3946, "Ajustări pentru deprecierea produselor reziduale", "Conturi de stocuri si productie in curs de executie", 3, "P", null, "" },
                    { 3947, "Ajustări pentru deprecierea produselor agricole", "Conturi de stocuri si productie in curs de executie", 3, "P", null, "" },
                    { 3951, "Ajustări pentru deprecierea materiilor şi materialelor aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", null, "" },
                    { 3952, "Ajustări pentru deprecierea semifabricatelor aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", null, "" },
                    { 3953, "Ajustări pentru deprecierea produselor finite aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", null, "" },
                    { 3954, "Ajustări pentru deprecierea produselor reziduale aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", null, "" },
                    { 3955, "Ajustări pentru deprecierea produselor agricole aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", null, "" },
                    { 3956, "Ajustări pentru deprecierea activelorBiologice de natura stocurilor aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", null, "" },
                    { 3957, "Ajustări pentru deprecierea mărfurilor aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", null, "" },
                    { 3958, "Ajustări pentru deprecierea ambalajelor aflate la terţi", "Conturi de stocuri si productie in curs de executie", 3, "P", null, "" },
                    { 4091, "Furnizori - debitori pentru cumpărări deBunuri de natura stocurilor", "Conturi de terti", 4, "A", null, "Bun" },
                    { 4092, "Furnizori - debitori pentru prestări de servicii", "Conturi de terti", 4, "A", null, "Serviciu" },
                    { 4093, "Avansuri acordate pentru imobilizări corporale", "Conturi de terti", 4, "A", null, "Bun" },
                    { 4094, "Avansuri acordate pentru imobilizări necorporale", "Conturi de terti", 4, "A", null, "Bun" },
                    { 4111, "Clienţi", "Conturi de terti", 4, "A", null, "" },
                    { 4118, "Clienţi incerţi sau în litigiu", "Conturi de terti", 4, "A", null, "" },
                    { 4281, "Alte datorii în legătură cu personalul", "Conturi de terti", 4, "P", null, "" },
                    { 4282, "Alte creanţe în legătură cu personalul", "Conturi de terti", 4, "A", null, "" },
                    { 4311, "Contribuţia unităţii la asigurările sociale", "Conturi de terti", 4, "P", null, "" },
                    { 4312, "Contribuţia personalului la asigurările sociale", "Conturi de terti", 4, "P", null, "" },
                    { 4313, "Contribuţia angajatorului pentru asigurările sociale de sănătate", "Conturi de terti", 4, "P", null, "" },
                    { 4314, "Contribuţia angajaţilor pentru asigurările sociale de sănătate", "Conturi de terti", 4, "P", null, "" },
                    { 4315, "Contribuţia de asigurări sociale", "Conturi de terti", 4, "P", null, "" },
                    { 4316, "Contribuţia de asigurări sociale de sănătate", "Conturi de terti", 4, "P", null, "" },
                    { 4318, "Alte contribuţii pentru asigurările sociale de sănătate", "Conturi de terti", 4, "P", null, "" },
                    { 4371, "Contribuţia unităţii la fondul de şomaj", "Conturi de terti", 4, "P", null, "" },
                    { 4372, "Contribuţia personalului la fondul de şomaj", "Conturi de terti", 4, "P", null, "" },
                    { 4381, "Alte datorii sociale", "Conturi de terti", 4, "P", null, "" },
                    { 4382, "Alte creanţe sociale", "Conturi de terti", 4, "A", null, "" },
                    { 4411, "Impozitul pe profit", "Conturi de terti", 4, "P", null, "" },
                    { 4413, "Diferențe de impozit determinate de incertitudinile legate de tratamentele fiscale", "Conturi de terti", 4, "B", null, "" },
                    { 4415, "Impozitul specific unor activităţi", "Conturi de terti", 4, "P", null, "" },
                    { 4418, "Impozitul pe venit", "Conturi de terti", 4, "P", null, "" },
                    { 4423, "TVA de plată", "Conturi de terti", 4, "P", null, "" },
                    { 4424, "TVA de recuperat", "Conturi de terti", 4, "A", null, "" },
                    { 4426, "TVA deductibilă", "Conturi de terti", 4, "A", null, "" },
                    { 4427, "TVA colectată", "Conturi de terti", 4, "P", null, "" },
                    { 4428, "TVA neexigibilă", "Conturi de terti", 4, "B", null, "" },
                    { 4451, "Subvenţii guvernamentale", "Conturi de terti", 4, "A", null, "" },
                    { 4452, "Împrumuturi nerambursabile cu caracter de subvenţii", "Conturi de terti", 4, "A", null, "" },
                    { 4458, "Alte sume primite cu caracter de subvenţii", "Conturi de terti", 4, "A", null, "" },
                    { 4481, "Alte datorii faţă deBugetul statului", "Conturi de terti", 4, "P", null, "" },
                    { 4482, "Alte creanţe privindBugetul statului", "Conturi de terti", 4, "A", null, "" },
                    { 4511, "Decontări între entităţile afiliate", "Conturi de terti", 4, "B", null, "" },
                    { 4518, "Dobânzi aferente decontărilor între entităţile afiliate", "Conturi de terti", 4, "B", null, "" },
                    { 4531, "Decontări cu entităţile asociate şi entităţile controlate", "Conturi de terti", 4, "B", null, "" },
                    { 4538, "Dobânzi aferente decontărilor cu entităţile asociate şi entităţile controlate în comun", "Conturi de terti", 4, "B", null, "" },
                    { 4551, "Acţionari/Asociaţi - conturi curente", "Conturi de terti", 4, "P", null, "" },
                    { 4558, "Acţionari/Asociaţi - dobânzi la conturi curente", "Conturi de terti", 4, "P", null, "" },
                    { 4581, "Decontări din operaţiuni în participaţie - pasiv", "Conturi de terti", 4, "P", null, "" },
                    { 4582, "Decontări din operaţiuni în participaţie - activ", "Conturi de terti", 4, "A", null, "" },
                    { 4661, "Datorii din operaţiuni de fiducie", "Conturi de terti", 4, "P", null, "" },
                    { 4662, "Creanţe din operaţiuni de fiducie", "Conturi de terti", 4, "A", null, "" },
                    { 4751, "Subvenţii guvernamentale pentru investiţii", "Conturi de terti", 4, "P", null, "" },
                    { 4752, "Împrumuturi nerambursabile cu caracter de subvenţii pentru investiţii", "Conturi de terti", 4, "P", null, "" },
                    { 4753, "Donaţii pentru investiţii", "Conturi de terti", 4, "P", null, "" },
                    { 4754, "Plusuri de inventar de natura imobilizărilor", "Conturi de terti", 4, "P", null, "" },
                    { 4758, "Alte sume primite cu caracter de subvenţii pentru investiţii", "Conturi de terti", 4, "P", null, "" },
                    { 4901, "Ajustări pentru deprecierea creanţelor aferente cumpărărilor deBunuri de natura stocurilor", "Conturi de terti", 4, "P", null, "" },
                    { 4902, "Ajustări pentru deprecierea creanţelor aferente prestărilor de servicii", "Conturi de terti", 4, "P", null, "" },
                    { 4903, "Ajustări pentru deprecierea creanţelor aferente imobilizărilor corporale", "Conturi de terti", 4, "P", null, "" },
                    { 4904, "Ajustări pentru deprecierea creanţelor aferente imobilizărilor necorporale", "Conturi de terti", 4, "P", null, "" },
                    { 5081, "Alte titluri de plasament", "Conturi de trezorerie", 5, "A", null, "" },
                    { 5088, "Dobânzi la obligaţiuni şi titluri de plasament", "Conturi de trezorerie", 5, "A", null, "" },
                    { 5091, "Vărsăminte de efectuat pentru acţiunile deţinute la entităţile afiliate", "Conturi de trezorerie", 5, "P", null, "" },
                    { 5092, "Vărsăminte de efectuat pentru alte investiţii pe termen scurt", "Conturi de trezorerie", 5, "P", null, "" },
                    { 5112, "Cecuri de încasat", "Conturi de trezorerie", 5, "A", null, "" },
                    { 5113, "Efecte de încasat", "Conturi de trezorerie", 5, "A", null, "" },
                    { 5114, "Efecte remise spre scontare", "Conturi de trezorerie", 5, "A", null, "" },
                    { 5121, "Conturi laBănci în lei", "Conturi de trezorerie", 5, "A", null, "" },
                    { 5124, "Conturi laBănci în valută", "Conturi de trezorerie", 5, "A", null, "" },
                    { 5125, "Sume în curs de decontare", "Conturi de trezorerie", 5, "A", null, "" },
                    { 5126, "Conturi laBănci în lei - TVA defalcat", "Conturi de trezorerie", 5, "A", null, "" },
                    { 5127, "Conturi laBănci în valută - TVA defalcat", "Conturi de trezorerie", 5, "A", null, "" },
                    { 5186, "Dobânzi de plătit", "Conturi de trezorerie", 5, "P", null, "" },
                    { 5187, "Dobânzi de încasat", "Conturi de trezorerie", 5, "A", null, "" },
                    { 5191, "CrediteBancare pe termen scurt", "Conturi de trezorerie", 5, "P", null, "" },
                    { 5192, "CrediteBancare pe termen scurt nerambursate la scadenţă", "Conturi de trezorerie", 5, "P", null, "" },
                    { 5193, "Credite externe guvernamentale", "Conturi de trezorerie", 5, "P", null, "" },
                    { 5194, "Credite externe garantate de stat", "Conturi de trezorerie", 5, "P", null, "" },
                    { 5195, "Credite externe garantate deBănci", "Conturi de trezorerie", 5, "P", null, "" },
                    { 5196, "Credite de la Trezoreria Statului", "Conturi de trezorerie", 5, "P", null, "" },
                    { 5197, "Credite interne garantate de stat", "Conturi de trezorerie", 5, "P", null, "" },
                    { 5198, "Dobânzi aferente creditelorBancare pe termen scurt", "Conturi de trezorerie", 5, "P", null, "" },
                    { 5311, "Casa în lei", "Conturi de trezorerie", 5, "A", null, "" },
                    { 5314, "Casa în valută", "Conturi de trezorerie", 5, "A", null, "" },
                    { 5321, "Timbre fiscale şi poştale", "Conturi de trezorerie", 5, "A", null, "" },
                    { 5322, "Bilete de tratament şi odihnă", "Conturi de trezorerie", 5, "A", null, "" },
                    { 5323, "Tichete şiBilete de călătorie", "Conturi de trezorerie", 5, "A", null, "" },
                    { 5328, "Alte valori", "Conturi de trezorerie", 5, "A", null, "" },
                    { 5411, "Acreditive în lei", "Conturi de trezorerie", 5, "A", null, "" },
                    { 5414, "Acreditive în valută", "Conturi de trezorerie", 5, "A", null, "" },
                    { 6021, "Cheltuieli cu materialele auxiliare", "Conturi de cheltuieli", 6, "A", null, "Bun" },
                    { 6022, "Cheltuieli privind combustibilii", "Conturi de cheltuieli", 6, "A", null, "Bun" },
                    { 6023, "Cheltuieli privind materialele pentru ambalat", "Conturi de cheltuieli", 6, "A", null, "Bun" },
                    { 6024, "Cheltuieli privind piesele de schimb", "Conturi de cheltuieli", 6, "A", null, "Bun" },
                    { 6025, "Cheltuieli privind seminţele şi materialele de plantat", "Conturi de cheltuieli", 6, "A", null, "Bun" },
                    { 6026, "Cheltuieli privind furajele", "Conturi de cheltuieli", 6, "A", null, "Bun" },
                    { 6028, "Cheltuieli privind alte materiale consumabile", "Conturi de cheltuieli", 6, "A", null, "Bun" },
                    { 6051, "Cheltuieli privind consumul de energie", "Conturi de cheltuieli", 6, "A", null, "Bun" },
                    { 6052, "Cheltuieli privind consumul de apă", "Conturi de cheltuieli", 6, "A", null, "Bun" },
                    { 6053, "Cheltuieli privind consumul de gaze naturale", "Conturi de cheltuieli", 6, "A", null, "Bun" },
                    { 6058, "Cheltuieli cu alte utilităţi", "Conturi de cheltuieli", 6, "A", null, "Bun" },
                    { 6231, "Cheltuieli de protocol", "Conturi de cheltuieli", 6, "A", null, "Serviciu" },
                    { 6232, "Cheltuieli de reclamă şi publicitate", "Conturi de cheltuieli", 6, "A", null, "Serviciu" },
                    { 6421, "Cheltuieli cu avantajele în natură acordate salariaţilor", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6422, "Cheltuieli cu tichetele acordate salariaţilor", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6451, "Cheltuieli privind contribuţia unităţii la asigurările sociale", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6452, "Cheltuieli privind contribuţia unităţii pentru ajutorul de şomaj", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6453, "Cheltuieli privind contribuţia angajatorului pentru asigurările sociale de sănătate", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6455, "Cheltuieli privind contribuţia unităţii la asigurările de viaţă", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6456, "Cheltuieli privind contribuţia unităţii la fondurile de pensii facultative", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6457, "Cheltuieli privind contribuţia unităţii la primele de asigurare voluntară de sănătate", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6458, "Alte cheltuieli privind asigurările şi protecţia socială", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6461, "Cheltuieli privind contribuția asiguratorie pentru muncă corespunzătoare salariaților", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6462, "Cheltuieli privind contribuția asiguratorie pentru muncă corespunzătoare altor persoane, decât salariații", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6511, "Cheltuieli ocazionate de constituirea fiduciei", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6512, "Cheltuieli din derularea operaţiunilor de fiducie", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6513, "Cheltuieli din lichidarea operaţiunilor de fiducie", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6565, "Pierderi din evaluarea la valoarea justă a activelor aferente dreptului de utilizare care corespund definiției unei investiții imobiliare", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6581, "Despăgubiri, amenzi şi penalităţi", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6582, "Donaţii acordate", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6583, "Cheltuieli privind activele cedate şi alte operaţiuni de capital", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6584, "Cheltuieli cu sumele sauBunurile acordate ca sponsorizări", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6586, "Cheltuieli reprezentând transferuri şi contribuţii datorate înBaza unor acte normative speciale", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6587, "Cheltuieli privind calamităţile şi alte evenimente similare", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6588, "Alte cheltuieli de exploatare", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6641, "Cheltuieli privind imobilizările financiare cedate", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6642, "Pierderi din investiţiile pe termen scurt cedate", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6651, "Diferenţe nefavorabile de curs valutar legate de elementele monetare exprimate în valută", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6652, "Diferenţe nefavorabile de curs valutar din evaluarea elementelor monetare care fac parte din investiţia netă într-o entitate străină", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6811, "Cheltuieli de exploatare privind amortizarea imobilizărilor", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6812, "Cheltuieli de exploatare privind provizioanele", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6813, "Cheltuieli de exploatare privind ajustările pentru deprecierea imobilizărilor", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6814, "Cheltuieli de exploatare privind ajustările pentru deprecierea activelor circulante", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6817, "Cheltuieli de exploatare privind ajustările pentru deprecierea fondului comercial", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6818, "Cheltuieli de exploatare privind ajustările pentru deprecierea creanţelor reprezentând avansuri acordate furnizorilor", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6861, "Cheltuieli privind actualizarea provizioanelor", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6863, "Cheltuieli financiare privind ajustările pentru pierderea de valoare a imobilizărilor financiare", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6864, "Cheltuieli financiare privind ajustările pentru pierderea de valoare a activelor circulante", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6865, "Cheltuieli financiare privind amortizarea diferenţelor aferente titlurilor de stat", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 6868, "Cheltuieli financiare privind amortizarea primelor de rambursare a obligaţiunilor şi a altor datorii", "Conturi de cheltuieli", 6, "A", null, "" },
                    { 7015, "Venituri din vânzarea produselor finite", "Conturi de venituri", 7, "P", null, "Bun" },
                    { 7017, "Venituri din vânzarea produselor agricole", "Conturi de venituri", 7, "P", null, "Bun" },
                    { 7018, "Venituri din vânzarea activelorBiologice de natura stocurilor", "Conturi de venituri", 7, "P", null, "Bun" },
                    { 7411, "Venituri din subvenţii de exploatare aferente cifrei de afaceri", "Conturi de venituri", 7, "P", null, "" },
                    { 7412, "Venituri din subvenţii de exploatare pentru materii prime şi materiale", "Conturi de venituri", 7, "P", null, "" },
                    { 7413, "Venituri din subvenţii de exploatare pentru alte cheltuieli externe", "Conturi de venituri", 7, "P", null, "" },
                    { 7414, "Venituri din subvenţii de exploatare pentru plata personalului", "Conturi de venituri", 7, "P", null, "" },
                    { 7415, "Venituri din subvenţii de exploatare pentru asigurări şi protecţie socială", "Conturi de venituri", 7, "P", null, "" },
                    { 7416, "Venituri din subvenţii de exploatare pentru alte cheltuieli de exploatare", "Conturi de venituri", 7, "P", null, "" },
                    { 7417, "Venituri din subvenţii de exploatare în caz de calamităţi şi alte evenimente similare", "Conturi de venituri", 7, "P", null, "" },
                    { 7418, "Venituri din subvenţii de exploatare pentru dobânda datorată", "Conturi de venituri", 7, "P", null, "" },
                    { 7419, "Venituri din subvenţii de exploatare aferente altor venituri", "Conturi de venituri", 7, "P", null, "" },
                    { 7511, "Venituri ocazionate de constituirea fiduciei", "Conturi de venituri", 7, "P", null, "" },
                    { 7512, "Venituri din derularea operaţiunilor de fiducie", "Conturi de venituri", 7, "P", null, "" },
                    { 7513, "Venituri din lichidarea operaţiunilor de fiducie", "Conturi de venituri", 7, "P", null, "" },
                    { 7565, "Câștiguri din evaluarea la valoarea justă a activelor aferente dreptului de utilizare care corespund definiției unei investiții imobiliare", "Conturi de venituri", 7, "P", null, "" },
                    { 7581, "Venituri din despăgubiri, amenzi şi penalităţi", "Conturi de venituri", 7, "P", null, "" },
                    { 7582, "Venituri din donaţii primite", "Conturi de venituri", 7, "P", null, "" },
                    { 7583, "Venituri din vânzarea activelor şi alte operaţiuni de capital", "Conturi de venituri", 7, "P", null, "Bun" },
                    { 7584, "Venituri din subvenţii pentru investiţii", "Conturi de venituri", 7, "P", null, "" },
                    { 7586, "Venituri reprezentând transferuri cuvenite înBaza unor acte normative speciale", "Conturi de venituri", 7, "P", null, "" },
                    { 7588, "Alte venituri din exploatare", "Conturi de venituri", 7, "P", null, "Bun" },
                    { 7611, "Venituri din acţiuni deţinute la entităţile afiliate", "Conturi de venituri", 7, "P", null, "" },
                    { 7612, "Venituri din acţiuni deţinute la entităţi asociate", "Conturi de venituri", 7, "P", null, "" },
                    { 7613, "Venituri din acţiuni deţinute la entităţi controlate în comun", "Conturi de venituri", 7, "P", null, "" },
                    { 7615, "Venituri din alte imobilizări financiare", "Conturi de venituri", 7, "P", null, "" },
                    { 7641, "Venituri din imobilizări financiare cedate", "Conturi de venituri", 7, "P", null, "" },
                    { 7642, "Câştiguri din investiţii pe termen scurt cedate", "Conturi de venituri", 7, "P", null, "" },
                    { 7651, "Diferenţe favorabile de curs valutar legate de elementele monetare exprimate în valută", "Conturi de venituri", 7, "P", null, "" },
                    { 7652, "Diferenţe favorabile de curs valutar din evaluarea elementelor monetare care fac parte din investiţia netă într-o entitate străină", "Conturi de venituri", 7, "P", null, "" },
                    { 7812, "Venituri din provizioane", "Conturi de venituri", 7, "P", null, "" },
                    { 7813, "Venituri din ajustări pentru deprecierea imobilizărilor", "Conturi de venituri", 7, "P", null, "" },
                    { 7814, "Venituri din ajustări pentru deprecierea activelor circulante", "Conturi de venituri", 7, "P", null, "" },
                    { 7815, "Venituri din fondul comercial negativ", "Conturi de venituri", 7, "P", null, "" },
                    { 7818, "Venituri din ajustări pentru deprecierea creanţelor reprezentând avansuri acordate furnizorilor", "Conturi de venituri", 7, "P", null, "" },
                    { 7863, "Venituri financiare din ajustări pentru pierderea de valoare a imobilizărilor financiare", "Conturi de venituri", 7, "P", null, "" },
                    { 7864, "Venituri financiare din ajustări pentru pierderea de valoare a activelor circulante", "Conturi de venituri", 7, "P", null, "" },
                    { 7865, "Venituri financiare din amortizarea diferenţelor aferente titlurilor de stat", "Conturi de venituri", 7, "P", null, "" },
                    { 8011, "Giruri şi garanţii acordate", "Conturi speciale", 8, "B", null, "" },
                    { 8018, "Alte angajamente acordate", "Conturi speciale", 8, "B", null, "" },
                    { 8021, "Giruri şi garanţii primite", "Conturi speciale", 8, "B", null, "" },
                    { 8028, "Alte angajamente primite", "Conturi speciale", 8, "B", null, "" },
                    { 8031, "Imobilizări corporale primite cu chirie sau înBaza altor contracte similare", "Conturi speciale", 8, "B", null, "" },
                    { 8032, "Valori materiale primite spre prelucrare sau reparare", "Conturi speciale", 8, "B", null, "" },
                    { 8033, "Valori materiale primite în păstrare sau custodie", "Conturi speciale", 8, "B", null, "" },
                    { 8034, "Debitori scoşi din activ, urmăriţi în continuare", "Conturi speciale", 8, "B", null, "" },
                    { 8035, "Stocuri de natura obiectelor de inventar date în folosinţă", "Conturi speciale", 8, "B", null, "" },
                    { 8036, "Redevenţe, locaţii de gestiune, chirii şi alte datorii asimilate", "Conturi speciale", 8, "B", null, "" },
                    { 8037, "Efecte scontate neajunse la scadenţă", "Conturi speciale", 8, "B", null, "" },
                    { 8038, "Bunuri primite în administrare, concesiune, cu chirie şi alteBunuri similare", "Conturi speciale", 8, "B", null, "" },
                    { 8039, "Alte valori în afaraBilanţului", "Conturi speciale", 8, "B", null, "" },
                    { 8051, "Dobânzi de plătit", "Conturi speciale", 8, "B", null, "" },
                    { 8052, "Dobânzi de încasat", "Conturi speciale", 8, "B", null, "" }
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
                name: "IX_CompanyUser_UsersUserId",
                table: "CompanyUser",
                column: "UsersUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralChartOfAccounts_CompanyChartOfAccountsId",
                table: "GeneralChartOfAccounts",
                column: "CompanyChartOfAccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_CompanyId",
                table: "Inventory",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_InventoryId",
                table: "Products",
                column: "InventoryId");

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
                name: "IX_Transactions_InventoryId",
                table: "Transactions",
                column: "InventoryId");

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
                name: "CompanyUser");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "RoleUserCompanyRole");

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
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CompanyChartOfAccounts");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
