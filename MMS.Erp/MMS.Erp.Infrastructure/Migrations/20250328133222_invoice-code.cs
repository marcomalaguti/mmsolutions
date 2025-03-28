using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMS.Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class invoicecode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SequenceNumber",
                table: "Invoices");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Invoices");

            migrationBuilder.AddColumn<int>(
                name: "SequenceNumber",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
