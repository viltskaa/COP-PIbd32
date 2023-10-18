using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseDataBaseImplement.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Subdivisions_SubdivisionId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_SubdivisionId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "SubdivisionId",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Subdivision",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Subdivision",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "SubdivisionId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SubdivisionId",
                table: "Employees",
                column: "SubdivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Subdivisions_SubdivisionId",
                table: "Employees",
                column: "SubdivisionId",
                principalTable: "Subdivisions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
