using Microsoft.EntityFrameworkCore.Migrations;

namespace LDInsurance.Migrations
{
    public partial class updateep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Confirm",
                table: "Expenses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportID",
                table: "Expenses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ReportID",
                table: "Expenses",
                column: "ReportID");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Reports_ReportID",
                table: "Expenses",
                column: "ReportID",
                principalTable: "Reports",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Reports_ReportID",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_ReportID",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "Confirm",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ReportID",
                table: "Expenses");
        }
    }
}
