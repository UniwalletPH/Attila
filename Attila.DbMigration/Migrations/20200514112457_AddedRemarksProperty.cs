using Microsoft.EntityFrameworkCore.Migrations;

namespace Attila.DbMigration.Migrations
{
    public partial class AddedRemarksProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "FoodRestockRequests",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "FoodRestockRequests");
        }
    }
}
