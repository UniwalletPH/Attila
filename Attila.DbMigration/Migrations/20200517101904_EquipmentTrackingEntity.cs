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
                    EventAdditionalEquipmentRequestID = table.Column<int>(nullable: false),
                    EquipmentID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentTracking_EventAdditionalEquipmentRequests_EventAdditionalEquipmentRequestID",
                        column: x => x.EventAdditionalEquipmentRequestID,
                        principalTable: "EventAdditionalEquipmentRequests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentTracking_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentTracking_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTracking_EquipmentID",
                table: "EquipmentTracking",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTracking_EventAdditionalEquipmentRequestID",
                table: "EquipmentTracking",
                column: "EventAdditionalEquipmentRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTracking_EventID",
                table: "EquipmentTracking",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentTracking_UserID",
                table: "EquipmentTracking",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentTracking");
        }
    }
}
