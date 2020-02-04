using Microsoft.EntityFrameworkCore.Migrations;

namespace Attila.Infrastructure.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventEquipmentsID",
                table: "tbl_EventDetails");

            migrationBuilder.DropColumn(
                name: "EventPaymentStatusID",
                table: "tbl_EventDetails");

            migrationBuilder.DropColumn(
                name: "EventTeamID",
                table: "tbl_EventDetails");

            migrationBuilder.DropColumn(
                name: "PackageAdditionalDurationRequestID",
                table: "tbl_EventDetails");

            migrationBuilder.DropColumn(
                name: "PackageAdditionalEquipmentRequestID",
                table: "tbl_EventDetails");

            migrationBuilder.AddColumn<int>(
                name: "EventDetailsID",
                table: "tbl_EventPaymentStatus",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventDetailsID",
                table: "tbl_EventPaymentStatus");

            migrationBuilder.AddColumn<int>(
                name: "EventEquipmentsID",
                table: "tbl_EventDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventPaymentStatusID",
                table: "tbl_EventDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventTeamID",
                table: "tbl_EventDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PackageAdditionalDurationRequestID",
                table: "tbl_EventDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PackageAdditionalEquipmentRequestID",
                table: "tbl_EventDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
