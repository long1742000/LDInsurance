using Microsoft.EntityFrameworkCore.Migrations;

namespace LDInsurance.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seat",
                table: "VehicleTypes");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "VehicleTypes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "VehicleTypes");

            migrationBuilder.AddColumn<int>(
                name: "Seat",
                table: "VehicleTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
