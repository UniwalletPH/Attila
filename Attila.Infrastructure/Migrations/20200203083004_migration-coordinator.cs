using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Attila.Infrastructure.Migrations
{
    public partial class migrationcoordinator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_EventDetails_tbl_EventClient_ClientID",
                table: "tbl_EventDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_EventDetails_tbl_User_EventCoordinatorID",
                table: "tbl_EventDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_EventDetails_tbl_EventPackageDetails_PackageID",
                table: "tbl_EventDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_PackageAdditionalEquipmentRequest_tbl_EventEquipments_EquipmentID",
                table: "tbl_PackageAdditionalEquipmentRequest");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_UserMap_tbl_User_ParentID",
                table: "tbl_UserMap");

            migrationBuilder.DropForeignKey(
                name: "FK_tbl_UserMap_tbl_User_UserID",
                table: "tbl_UserMap");

            migrationBuilder.DropIndex(
                name: "IX_tbl_UserMap_ParentID",
                table: "tbl_UserMap");

            migrationBuilder.DropIndex(
                name: "IX_tbl_UserMap_UserID",
                table: "tbl_UserMap");

            migrationBuilder.DropIndex(
                name: "IX_tbl_PackageAdditionalEquipmentRequest_EquipmentID",
                table: "tbl_PackageAdditionalEquipmentRequest");

            migrationBuilder.DropIndex(
                name: "IX_tbl_EventDetails_ClientID",
                table: "tbl_EventDetails");

            migrationBuilder.DropIndex(
                name: "IX_tbl_EventDetails_EventCoordinatorID",
                table: "tbl_EventDetails");

            migrationBuilder.DropIndex(
                name: "IX_tbl_EventDetails_PackageID",
                table: "tbl_EventDetails");

            migrationBuilder.DropColumn(
                name: "ParentID",
                table: "tbl_UserMap");

            migrationBuilder.DropColumn(
                name: "EquipmentID",
                table: "tbl_PackageAdditionalEquipmentRequest");

            migrationBuilder.DropColumn(
                name: "EncodedBy",
                table: "tbl_FoodInventory");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "tbl_EventDetails");

            migrationBuilder.DropColumn(
                name: "EventCoordinatorID",
                table: "tbl_EventDetails");

            migrationBuilder.DropColumn(
                name: "PackageID",
                table: "tbl_EventDetails");

            migrationBuilder.DropColumn(
                name: "EncodedBy",
                table: "tbl_EquipmentInventory");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "tbl_EquipmentDetails");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "tbl_UserMap",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventDetailsID",
                table: "tbl_UserMap",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventDetailsID",
                table: "tbl_PackageAdditionalEquipmentRequest",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventEquipmentsID",
                table: "tbl_PackageAdditionalEquipmentRequest",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "tbl_PackageAdditionalEquipmentRequest",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "EventDetailsID",
                table: "tbl_PackageAdditionalDurationRequest",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FoodDetailsID",
                table: "tbl_FoodInventory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FoodRestockID",
                table: "tbl_FoodInventory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "tbl_FoodInventory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentDetailsID",
                table: "tbl_EventEquipments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventClientID",
                table: "tbl_EventDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventEquipmentsID",
                table: "tbl_EventDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventPackageDetailsID",
                table: "tbl_EventDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventPaymentStatusID",
                table: "tbl_EventDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte>(
                name: "EventStatus",
                table: "tbl_EventDetails",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "EventTeamID",
                table: "tbl_EventDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PackageAdditionalDurationRequestID",
                table: "tbl_EventDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PackageAdditionalEquipmentRequestID",
                table: "tbl_EventDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "tbl_EventDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentDeliveryID",
                table: "tbl_EquipmentInventory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentDetailsID",
                table: "tbl_EquipmentInventory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "tbl_EquipmentInventory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "tbl_EquipmentDetails",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<byte>(
                name: "UnitType",
                table: "tbl_EquipmentDetails",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "tbl_EquipmentRestockRequest",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    DateTimeRequest = table.Column<DateTime>(nullable: false),
                    EquipmentDetailsID = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EquipmentRestockRequest", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_EventEquipmentRequest",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDetailsID = table.Column<int>(nullable: false),
                    EquipmentDetailsID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EventEquipmentRequest", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_FoodRestockRequest",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    DateTimeRequest = table.Column<DateTime>(nullable: false),
                    FoodsDetailsID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_FoodRestockRequest", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_EquipmentRestockRequest");

            migrationBuilder.DropTable(
                name: "tbl_EventEquipmentRequest");

            migrationBuilder.DropTable(
                name: "tbl_FoodRestockRequest");

            migrationBuilder.DropColumn(
                name: "EventDetailsID",
                table: "tbl_UserMap");

            migrationBuilder.DropColumn(
                name: "EventDetailsID",
                table: "tbl_PackageAdditionalEquipmentRequest");

            migrationBuilder.DropColumn(
                name: "EventEquipmentsID",
                table: "tbl_PackageAdditionalEquipmentRequest");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "tbl_PackageAdditionalEquipmentRequest");

            migrationBuilder.DropColumn(
                name: "EventDetailsID",
                table: "tbl_PackageAdditionalDurationRequest");

            migrationBuilder.DropColumn(
                name: "FoodDetailsID",
                table: "tbl_FoodInventory");

            migrationBuilder.DropColumn(
                name: "FoodRestockID",
                table: "tbl_FoodInventory");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "tbl_FoodInventory");

            migrationBuilder.DropColumn(
                name: "EquipmentDetailsID",
                table: "tbl_EventEquipments");

            migrationBuilder.DropColumn(
                name: "EventClientID",
                table: "tbl_EventDetails");

            migrationBuilder.DropColumn(
                name: "EventEquipmentsID",
                table: "tbl_EventDetails");

            migrationBuilder.DropColumn(
                name: "EventPackageDetailsID",
                table: "tbl_EventDetails");

            migrationBuilder.DropColumn(
                name: "EventPaymentStatusID",
                table: "tbl_EventDetails");

            migrationBuilder.DropColumn(
                name: "EventStatus",
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

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "tbl_EventDetails");

            migrationBuilder.DropColumn(
                name: "EquipmentDeliveryID",
                table: "tbl_EquipmentInventory");

            migrationBuilder.DropColumn(
                name: "EquipmentDetailsID",
                table: "tbl_EquipmentInventory");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "tbl_EquipmentInventory");

            migrationBuilder.DropColumn(
                name: "UnitType",
                table: "tbl_EquipmentDetails");

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "tbl_UserMap",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ParentID",
                table: "tbl_UserMap",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentID",
                table: "tbl_PackageAdditionalEquipmentRequest",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EncodedBy",
                table: "tbl_FoodInventory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "ClientID",
                table: "tbl_EventDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventCoordinatorID",
                table: "tbl_EventDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PackageID",
                table: "tbl_EventDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EncodedBy",
                table: "tbl_EquipmentInventory",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "tbl_EquipmentDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Unit",
                table: "tbl_EquipmentDetails",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserMap_ParentID",
                table: "tbl_UserMap",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserMap_UserID",
                table: "tbl_UserMap",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_PackageAdditionalEquipmentRequest_EquipmentID",
                table: "tbl_PackageAdditionalEquipmentRequest",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EventDetails_ClientID",
                table: "tbl_EventDetails",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EventDetails_EventCoordinatorID",
                table: "tbl_EventDetails",
                column: "EventCoordinatorID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EventDetails_PackageID",
                table: "tbl_EventDetails",
                column: "PackageID");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_EventDetails_tbl_EventClient_ClientID",
                table: "tbl_EventDetails",
                column: "ClientID",
                principalTable: "tbl_EventClient",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_EventDetails_tbl_User_EventCoordinatorID",
                table: "tbl_EventDetails",
                column: "EventCoordinatorID",
                principalTable: "tbl_User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_EventDetails_tbl_EventPackageDetails_PackageID",
                table: "tbl_EventDetails",
                column: "PackageID",
                principalTable: "tbl_EventPackageDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_PackageAdditionalEquipmentRequest_tbl_EventEquipments_EquipmentID",
                table: "tbl_PackageAdditionalEquipmentRequest",
                column: "EquipmentID",
                principalTable: "tbl_EventEquipments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_UserMap_tbl_User_ParentID",
                table: "tbl_UserMap",
                column: "ParentID",
                principalTable: "tbl_User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_UserMap_tbl_User_UserID",
                table: "tbl_UserMap",
                column: "UserID",
                principalTable: "tbl_User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
