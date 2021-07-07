using Microsoft.EntityFrameworkCore.Migrations;

namespace LDInsurance.Migrations
{
    public partial class update8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InsuranceID",
                table: "TransactionHistory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionHistory_InsuranceID",
                table: "TransactionHistory",
                column: "InsuranceID");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionHistory_Insurances_InsuranceID",
                table: "TransactionHistory",
                column: "InsuranceID",
                principalTable: "Insurances",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionHistory_Insurances_InsuranceID",
                table: "TransactionHistory");

            migrationBuilder.DropIndex(
                name: "IX_TransactionHistory_InsuranceID",
                table: "TransactionHistory");

            migrationBuilder.DropColumn(
                name: "InsuranceID",
                table: "TransactionHistory");
        }
    }
}
