using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class MigrationModel_04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalKey",
                schema: "General",
                table: "Payments");

            migrationBuilder.AddColumn<string>(
                name: "BilligId",
                schema: "General",
                table: "Payments",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentCode",
                schema: "General",
                table: "Payments",
                maxLength: 15,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BilligId",
                schema: "General",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentCode",
                schema: "General",
                table: "Payments");

            migrationBuilder.AddColumn<string>(
                name: "OriginalKey",
                schema: "General",
                table: "Payments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
