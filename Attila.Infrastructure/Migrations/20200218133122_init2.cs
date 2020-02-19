using Microsoft.EntityFrameworkCore.Migrations;

namespace Attila.Infrastructure.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_EquipmentDelivery",
                table: "tbl_EquipmentDelivery");

            migrationBuilder.RenameTable(
                name: "tbl_EquipmentDelivery",
                newName: "tbl_EquipmentRestock");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_EquipmentRestock",
                table: "tbl_EquipmentRestock",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_EquipmentRestock",
                table: "tbl_EquipmentRestock");

            migrationBuilder.RenameTable(
                name: "tbl_EquipmentRestock",
                newName: "tbl_EquipmentDelivery");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_EquipmentDelivery",
                table: "tbl_EquipmentDelivery",
                column: "ID");
        }
    }
}
