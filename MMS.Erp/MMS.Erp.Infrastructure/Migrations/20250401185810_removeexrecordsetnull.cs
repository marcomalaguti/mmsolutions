using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMS.Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeexrecordsetnull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseRecords_ExpenseReports_ExpenseReportId",
                table: "ExpenseRecords");

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseReportId",
                table: "ExpenseRecords",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseRecords_ExpenseReports_ExpenseReportId",
                table: "ExpenseRecords",
                column: "ExpenseReportId",
                principalTable: "ExpenseReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseRecords_ExpenseReports_ExpenseReportId",
                table: "ExpenseRecords");

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseReportId",
                table: "ExpenseRecords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseRecords_ExpenseReports_ExpenseReportId",
                table: "ExpenseRecords",
                column: "ExpenseReportId",
                principalTable: "ExpenseReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
