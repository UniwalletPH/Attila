using Microsoft.EntityFrameworkCore.Migrations;

namespace Attila.DbMigration.Migrations
{
    public partial class ModifiedEventTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventAdditionalEquipmentRequests_Equipments_EquipmentID",
                table: "EventAdditionalEquipmentRequests");

            migrationBuilder.DropIndex(
                name: "IX_EventAdditionalEquipmentRequests_EquipmentID",
                table: "EventAdditionalEquipmentRequests");

            migrationBuilder.DropColumn(
                name: "EquipmentID",
                table: "EventAdditionalEquipmentRequests");

            migrationBuilder.AddColumn<decimal>(
                name: "ToPay",
                table: "Events",
                type: "DECIMAL(20,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "EventAdditionalDurationRequests",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ToPay",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "EventAdditionalDurationRequests");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentID",
                table: "EventAdditionalEquipmentRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventAdditionalEquipmentRequests_EquipmentID",
                table: "EventAdditionalEquipmentRequests",
                column: "EquipmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventAdditionalEquipmentRequests_Equipments_EquipmentID",
                table: "EventAdditionalEquipmentRequests",
                column: "EquipmentID",
                principalTable: "Equipments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
