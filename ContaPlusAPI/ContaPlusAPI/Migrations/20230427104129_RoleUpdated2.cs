using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContaPlusAPI.Migrations
{
    /// <inheritdoc />
    public partial class RoleUpdated2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_UserCompanyRoles_UserCompanyRoleUserCompanyId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_UserCompanyRoleUserCompanyId",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UserCompanyRoleUserCompanyId",
                table: "Roles");

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

            migrationBuilder.CreateIndex(
                name: "IX_RoleUserCompanyRole_RolesUserCompanyId",
                table: "RoleUserCompanyRole",
                column: "RolesUserCompanyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleUserCompanyRole");

            migrationBuilder.AddColumn<Guid>(
                name: "UserCompanyRoleUserCompanyId",
                table: "Roles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "UserCompanyRoleUserCompanyId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "UserCompanyRoleUserCompanyId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "UserCompanyRoleUserCompanyId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserCompanyRoleUserCompanyId",
                table: "Roles",
                column: "UserCompanyRoleUserCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_UserCompanyRoles_UserCompanyRoleUserCompanyId",
                table: "Roles",
                column: "UserCompanyRoleUserCompanyId",
                principalTable: "UserCompanyRoles",
                principalColumn: "UserCompanyId");
        }
    }
}
