using Microsoft.EntityFrameworkCore.Migrations;

namespace Attila.DbMigration.Migrations
{
    public partial class addedNewProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Messages",
                table: "Notifications",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EstimatedPrice",
                table: "EquipmentRequestCollections",
                type: "DECIMAL(20,8)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Messages",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "EstimatedPrice",
                table: "EquipmentRequestCollections");
        }
    }
}
