using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRegister.Migrations
{
    /// <inheritdoc />
    public partial class FixTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_OrganizationalUnits_OrganizationalUnitId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrganizationalUnits",
                table: "OrganizationalUnits");

            migrationBuilder.RenameTable(
                name: "OrganizationalUnits",
                newName: "Organization");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organization",
                table: "Organization",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Organization_OrganizationalUnitId",
                table: "Employees",
                column: "OrganizationalUnitId",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Organization_OrganizationalUnitId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organization",
                table: "Organization");

            migrationBuilder.RenameTable(
                name: "Organization",
                newName: "OrganizationalUnits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrganizationalUnits",
                table: "OrganizationalUnits",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_OrganizationalUnits_OrganizationalUnitId",
                table: "Employees",
                column: "OrganizationalUnitId",
                principalTable: "OrganizationalUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
