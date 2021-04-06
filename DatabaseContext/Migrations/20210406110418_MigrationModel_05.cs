using Microsoft.EntityFrameworkCore.Migrations;

namespace Domain.Migrations
{
    public partial class MigrationModel_05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalUserName",
                schema: "General",
                table: "Payments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OriginalUserName",
                schema: "General",
                table: "Payments",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }
    }
}
