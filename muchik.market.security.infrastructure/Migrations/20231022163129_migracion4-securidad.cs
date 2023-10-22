using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace muchik.market.security.infrastructure.Migrations
{
    public partial class migracion4securidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "user",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "user",
                newName: "customerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "role",
                table: "user",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "customerId",
                table: "user",
                newName: "CustomerId");
        }
    }
}
