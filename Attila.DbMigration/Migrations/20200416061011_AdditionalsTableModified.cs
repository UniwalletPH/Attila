using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Attila.DbMigration.Migrations
{
    public partial class AdditionalsTableModified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventDishRequests");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "EventAdditionalEquipmentRequests");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "EventAdditionalDishRequests");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "EventEquipmentRequestCollections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EventDishRequestCollection",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    AdditionalDishID = table.Column<int>(nullable: false),
                    DishID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDishRequestCollection", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventDishRequestCollection_EventAdditionalDishRequests_AdditionalDishID",
                        column: x => x.AdditionalDishID,
                        principalTable: "EventAdditionalDishRequests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventDishRequestCollection_Dishes_DishID",
                        column: x => x.DishID,
                        principalTable: "Dishes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventDishRequestCollection_AdditionalDishID",
                table: "EventDishRequestCollection",
                column: "AdditionalDishID");

            migrationBuilder.CreateIndex(
                name: "IX_EventDishRequestCollection_DishID",
                table: "EventDishRequestCollection",
                column: "DishID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventDishRequestCollection");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "EventEquipmentRequestCollections");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "EventAdditionalEquipmentRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "EventAdditionalDishRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EventDishRequests",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdditionalDishID = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DishID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDishRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventDishRequests_EventAdditionalDishRequests_AdditionalDishID",
                        column: x => x.AdditionalDishID,
                        principalTable: "EventAdditionalDishRequests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventDishRequests_Dishes_DishID",
                        column: x => x.DishID,
                        principalTable: "Dishes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventDishRequests_AdditionalDishID",
                table: "EventDishRequests",
                column: "AdditionalDishID");

            migrationBuilder.CreateIndex(
                name: "IX_EventDishRequests_DishID",
                table: "EventDishRequests",
                column: "DishID");
        }
    }
}
