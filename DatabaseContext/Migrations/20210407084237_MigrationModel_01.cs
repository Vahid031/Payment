using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class MigrationModel_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "General");

            migrationBuilder.CreateTable(
                name: "Logs",
                schema: "General",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(maxLength: 2000, nullable: true),
                    Type = table.Column<string>(maxLength: 10, nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                schema: "General",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BillingId = table.Column<string>(maxLength: 15, nullable: true),
                    PaymentCode = table.Column<string>(maxLength: 15, nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    ReturnUrl = table.Column<string>(maxLength: 100, nullable: true),
                    Signature = table.Column<string>(maxLength: 300, nullable: true),
                    OriginalUserId = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                schema: "General",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    PaymentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentDetails_Payments_PaymentId",
                        column: x => x.PaymentId,
                        principalSchema: "General",
                        principalTable: "Payments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_PaymentId",
                schema: "General",
                table: "PaymentDetails",
                column: "PaymentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs",
                schema: "General");

            migrationBuilder.DropTable(
                name: "PaymentDetails",
                schema: "General");

            migrationBuilder.DropTable(
                name: "Payments",
                schema: "General");
        }
    }
}
