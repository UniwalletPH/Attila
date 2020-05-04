using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Attila.DbMigration.Migrations
{
    public partial class AddedEventFeeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventFee",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EventID = table.Column<int>(nullable: false),
                    Discription = table.Column<string>(nullable: true),
                    Item = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "DECIMAL(20,8)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "DECIMAL(20,8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventFee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventFee_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventFee_EventID",
                table: "EventFee",
                column: "EventID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventFee");
        }
    }
}
