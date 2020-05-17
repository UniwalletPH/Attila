using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Attila.DbMigration.Migrations
{
    public partial class EquipmentTrackingEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EquipmentTracking",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EventID = table.Column<int>(nullable: false),
                    EquipmentID = table.Column<int>(nullable: false),
                    InventoryManagerID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    TrackingDate = table.Column<DateTime>(nullable: false),
                    TrackingAction = table.Column<byte>(nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTracking", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EquipmentTracking_Equipments_EquipmentID",
                        column: x => x.EquipmentID,
                        principalTable: "Equipments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentTracking_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentTracking_Users_InventoryManagerID",
                        column: x => x.InventoryManagerID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTracking_EquipmentID",
                table: "EquipmentTracking",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTracking_EventID",
                table: "EquipmentTracking",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTracking_InventoryManagerID",
                table: "EquipmentTracking",
                column: "InventoryManagerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentTracking");
        }
    }
}
