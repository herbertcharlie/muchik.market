using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace muchik.market.pay.infrastructure.Migrations
{
    public partial class Migracion1Api : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "pay",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false),
                    invoice_id = table.Column<string>(type: "varchar(250)", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pay", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pay");
        }
    }
}
