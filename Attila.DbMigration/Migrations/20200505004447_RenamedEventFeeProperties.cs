using Microsoft.EntityFrameworkCore.Migrations;

namespace Attila.DbMigration.Migrations
{
    public partial class RenamedEventFeeProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventFee_Events_EventID",
                table: "EventFee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventFee",
                table: "EventFee");

            migrationBuilder.DropColumn(
                name: "Discription",
                table: "EventFee");

            migrationBuilder.RenameTable(
                name: "EventFee",
                newName: "EventFees");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "EventFees",
                newName: "PricePerQuantity");

            migrationBuilder.RenameIndex(
                name: "IX_EventFee_EventID",
                table: "EventFees",
                newName: "IX_EventFees_EventID");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "EventFees",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventFees",
                table: "EventFees",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventFees_Events_EventID",
                table: "EventFees",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventFees_Events_EventID",
                table: "EventFees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventFees",
                table: "EventFees");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "EventFees");

            migrationBuilder.RenameTable(
                name: "EventFees",
                newName: "EventFee");

            migrationBuilder.RenameColumn(
                name: "PricePerQuantity",
                table: "EventFee",
                newName: "Price");

            migrationBuilder.RenameIndex(
                name: "IX_EventFees_EventID",
                table: "EventFee",
                newName: "IX_EventFee_EventID");

            migrationBuilder.AddColumn<string>(
                name: "Discription",
                table: "EventFee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventFee",
                table: "EventFee",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EventFee_Events_EventID",
                table: "EventFee",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
