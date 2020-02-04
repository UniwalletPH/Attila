using Microsoft.EntityFrameworkCore.Migrations;

namespace Attila.Infrastructure.Migrations
{
    public partial class newdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventEquipmentsID",
                table: "tbl_PackageAdditionalEquipmentRequest");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentDetailsID",
                table: "tbl_PackageAdditionalEquipmentRequest",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentsDetailsID",
                table: "tbl_PackageAdditionalEquipmentRequest",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "tbl_PackageAdditionalEquipmentRequest",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FoodDetailsID",
                table: "tbl_FoodRestockRequest",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventDetailsID",
                table: "tbl_EventEquipments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_PackageAdditionalEquipmentRequest_EquipmentDetailsID",
                table: "tbl_PackageAdditionalEquipmentRequest",
                column: "EquipmentDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_FoodRestockRequest_FoodDetailsID",
                table: "tbl_FoodRestockRequest",
                column: "FoodDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EventEquipmentRequest_EquipmentDetailsID",
                table: "tbl_EventEquipmentRequest",
                column: "EquipmentDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EquipmentRestockRequest_EquipmentDetailsID",
                table: "tbl_EquipmentRestockRequest",
                column: "EquipmentDetailsID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_EquipmentRestockRequest_tbl_EquipmentDetails_EquipmentDetailsID",
                table: "tbl_EquipmentRestockRequest",
                column: "EquipmentDetailsID",
                principalTable: "tbl_EquipmentDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_EventEquipmentRequest_tbl_EquipmentDetails_EquipmentDetailsID",
                table: "tbl_EventEquipmentRequest",
                column: "EquipmentDetailsID",
                principalTable: "tbl_EquipmentDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_FoodRestockRequest_tbl_FoodDetails_FoodDetailsID",
                table: "tbl_FoodRestockRequest",
                column: "FoodDetailsID",
                principalTable: "tbl_FoodDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_PackageAdditionalEquipmentRequest_tbl_EquipmentDetails_EquipmentDetailsID",
                table: "tbl_PackageAdditionalEquipmentRequest",
                column: "EquipmentDetailsID",
                principalTable: "tbl_EquipmentDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_EquipmentRestockRequest_tbl_EquipmentDetails_EquipmentDetailsID",
                table: "tbl_EquipmentRestockRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_EventEquipmentRequest_tbl_EquipmentDetails_EquipmentDetailsID",
                table: "tbl_EventEquipmentRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_FoodRestockRequest_tbl_FoodDetails_FoodDetailsID",
                table: "tbl_FoodRestockRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_PackageAdditionalEquipmentRequest_tbl_EquipmentDetails_EquipmentDetailsID",
                table: "tbl_PackageAdditionalEquipmentRequest");

            migrationBuilder.DropIndex(
                name: "IX_tbl_PackageAdditionalEquipmentRequest_EquipmentDetailsID",
                table: "tbl_PackageAdditionalEquipmentRequest");

            migrationBuilder.DropIndex(
                name: "IX_tbl_FoodRestockRequest_FoodDetailsID",
                table: "tbl_FoodRestockRequest");

            migrationBuilder.DropIndex(
                name: "IX_tbl_EventEquipmentRequest_EquipmentDetailsID",
                table: "tbl_EventEquipmentRequest");

            migrationBuilder.DropIndex(
                name: "IX_tbl_EquipmentRestockRequest_EquipmentDetailsID",
                table: "tbl_EquipmentRestockRequest");

            migrationBuilder.DropColumn(
                name: "EquipmentDetailsID",
                table: "tbl_PackageAdditionalEquipmentRequest");

            migrationBuilder.DropColumn(
                name: "EquipmentsDetailsID",
                table: "tbl_PackageAdditionalEquipmentRequest");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "tbl_PackageAdditionalEquipmentRequest");

            migrationBuilder.DropColumn(
                name: "FoodDetailsID",
                table: "tbl_FoodRestockRequest");

            migrationBuilder.DropColumn(
                name: "EventDetailsID",
                table: "tbl_EventEquipments");

            migrationBuilder.AddColumn<int>(
                name: "EventEquipmentsID",
                table: "tbl_PackageAdditionalEquipmentRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
