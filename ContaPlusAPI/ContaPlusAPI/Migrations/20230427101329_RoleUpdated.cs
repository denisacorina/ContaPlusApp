using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContaPlusAPI.Migrations
{
    /// <inheritdoc />
    public partial class RoleUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyRoles_Roles_RoleId",
                table: "UserCompanyRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserCompanyRoles_RoleId",
                table: "UserCompanyRoles");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserCompanyRoles");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "UserCompanyRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanyRoles_RoleId",
                table: "UserCompanyRoles",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyRoles_Roles_RoleId",
                table: "UserCompanyRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
