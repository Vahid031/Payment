using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class MigrateModel_03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalUserId",
                schema: "General",
                table: "PaymentDetails");

            migrationBuilder.DropColumn(
                name: "OriginalUserName",
                schema: "General",
                table: "PaymentDetails");

            migrationBuilder.AddColumn<string>(
                name: "OriginalUserId",
                schema: "General",
                table: "Payments",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginalUserName",
                schema: "General",
                table: "Payments",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalUserId",
                schema: "General",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "OriginalUserName",
                schema: "General",
                table: "Payments");

            migrationBuilder.AddColumn<string>(
                name: "OriginalUserId",
                schema: "General",
                table: "PaymentDetails",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginalUserName",
                schema: "General",
                table: "PaymentDetails",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
