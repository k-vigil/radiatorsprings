using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RadiatorSprings.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "document_type",
                table: "Customers",
                newName: "DocumentType");

            migrationBuilder.RenameColumn(
                name: "document_number",
                table: "Customers",
                newName: "DocumentNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DocumentType",
                table: "Customers",
                newName: "document_type");

            migrationBuilder.RenameColumn(
                name: "DocumentNumber",
                table: "Customers",
                newName: "document_number");
        }
    }
}
