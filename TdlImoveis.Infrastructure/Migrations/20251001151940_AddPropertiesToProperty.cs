using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TdlImoveis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertiesToProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CEP",
                table: "Properties",
                newName: "PostalCode");

            migrationBuilder.AddColumn<string>(
                name: "Neighboorhood",
                table: "Properties",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Neighboorhood",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Properties",
                newName: "CEP");
        }
    }
}
