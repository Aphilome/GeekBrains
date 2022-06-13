using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Timesheets.Data.Migrations
{
    public partial class RenameInvoiceColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccauntNumber",
                table: "Invoices",
                newName: "AccountNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountNumber",
                table: "Invoices",
                newName: "AccauntNumber");
        }
    }
}
