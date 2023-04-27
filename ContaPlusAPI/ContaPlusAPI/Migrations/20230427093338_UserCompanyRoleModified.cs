using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContaPlusAPI.Migrations
{
    /// <inheritdoc />
    public partial class UserCompanyRoleModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyRole_Companies_CompanyId",
                table: "UserCompanyRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyRole_Roles_RoleId",
                table: "UserCompanyRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyRole_Users_UserId",
                table: "UserCompanyRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCompanyRole",
                table: "UserCompanyRole");

            migrationBuilder.RenameTable(
                name: "UserCompanyRole",
                newName: "UserCompanyRoles");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompanyRole_UserId",
                table: "UserCompanyRoles",
                newName: "IX_UserCompanyRoles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompanyRole_RoleId",
                table: "UserCompanyRoles",
                newName: "IX_UserCompanyRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompanyRole_CompanyId",
                table: "UserCompanyRoles",
                newName: "IX_UserCompanyRoles_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCompanyRoles",
                table: "UserCompanyRoles",
                column: "UserCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyRoles_Companies_CompanyId",
                table: "UserCompanyRoles",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyRoles_Roles_RoleId",
                table: "UserCompanyRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyRoles_Users_UserId",
                table: "UserCompanyRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyRoles_Companies_CompanyId",
                table: "UserCompanyRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyRoles_Roles_RoleId",
                table: "UserCompanyRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyRoles_Users_UserId",
                table: "UserCompanyRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCompanyRoles",
                table: "UserCompanyRoles");

            migrationBuilder.RenameTable(
                name: "UserCompanyRoles",
                newName: "UserCompanyRole");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompanyRoles_UserId",
                table: "UserCompanyRole",
                newName: "IX_UserCompanyRole_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompanyRoles_RoleId",
                table: "UserCompanyRole",
                newName: "IX_UserCompanyRole_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompanyRoles_CompanyId",
                table: "UserCompanyRole",
                newName: "IX_UserCompanyRole_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCompanyRole",
                table: "UserCompanyRole",
                column: "UserCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyRole_Companies_CompanyId",
                table: "UserCompanyRole",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyRole_Roles_RoleId",
                table: "UserCompanyRole",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyRole_Users_UserId",
                table: "UserCompanyRole",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
