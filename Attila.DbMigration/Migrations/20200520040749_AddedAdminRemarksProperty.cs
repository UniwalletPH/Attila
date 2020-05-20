using Microsoft.EntityFrameworkCore.Migrations;

namespace Attila.DbMigration.Migrations
{
    public partial class AddedAdminRemarksProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminRemarks",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminRemarks",
                table: "Events");
        }
    }
}
