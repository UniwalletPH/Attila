using Microsoft.EntityFrameworkCore.Migrations;

namespace Attila.DbMigration.Migrations
{
    public partial class AddedNewProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "EquipmentRestockRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "EquipmentRestockRequests");
        }
    }
}
