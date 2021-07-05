using Microsoft.EntityFrameworkCore.Migrations;

namespace LDInsurance.Migrations
{
    public partial class update3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "InsuranceRegistrations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceRegistrations_AccountID",
                table: "InsuranceRegistrations",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_InsuranceRegistrations_Accounts_AccountID",
                table: "InsuranceRegistrations",
                column: "AccountID",
                principalTable: "Accounts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InsuranceRegistrations_Accounts_AccountID",
                table: "InsuranceRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_InsuranceRegistrations_AccountID",
                table: "InsuranceRegistrations");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "InsuranceRegistrations");
        }
    }
}
