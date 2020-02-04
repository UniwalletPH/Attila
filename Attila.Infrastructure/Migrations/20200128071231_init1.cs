using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Attila.Infrastructure.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_EquipmentDelivery",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    ReceiptImage = table.Column<byte[]>(nullable: true),
                    DeliveryPrice = table.Column<decimal>(nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EquipmentDelivery", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_EquipmentDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Unit = table.Column<byte>(nullable: false),
                    EquipmentType = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EquipmentDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_EquipmentInventory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncodingDate = table.Column<DateTime>(nullable: false),
                    EncodedBy = table.Column<long>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ItemPrice = table.Column<decimal>(nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EquipmentInventory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_EventClient",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EventClient", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_EventEquipments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EventEquipments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_EventPackageDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    NumberOfGuest = table.Column<int>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false),
                    Duration = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EventPackageDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_EventPaymentStatus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(nullable: false),
                    DateOfPayment = table.Column<DateTime>(nullable: false),
                    ReferenceNumber = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EventPaymentStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_FoodDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Specification = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Unit = table.Column<byte>(nullable: false),
                    FoodType = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_FoodDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_FoodInventory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    EncodingDate = table.Column<DateTime>(nullable: false),
                    EncodedBy = table.Column<long>(nullable: false),
                    ItemPrice = table.Column<decimal>(nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_FoodInventory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_FoodRestock",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecieptImage = table.Column<byte[]>(nullable: true),
                    DeliveryTime = table.Column<DateTime>(nullable: false),
                    DeliveryPrice = table.Column<decimal>(nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_FoodRestock", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PackageAdditionalDurationRequest",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PackageAdditionalDurationRequest", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_User",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Role = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PackageAdditionalEquipmentRequest",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentID = table.Column<int>(nullable: true),
                    Rate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PackageAdditionalEquipmentRequest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_PackageAdditionalEquipmentRequest_tbl_EventEquipments_EquipmentID",
                        column: x => x.EquipmentID,
                        principalTable: "tbl_EventEquipments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_EventDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    EventName = table.Column<string>(nullable: true),
                    Type = table.Column<byte>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    EventDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    ClientID = table.Column<int>(nullable: true),
                    EventCoordinatorID = table.Column<int>(nullable: true),
                    PackageID = table.Column<int>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EventDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_EventDetails_tbl_EventClient_ClientID",
                        column: x => x.ClientID,
                        principalTable: "tbl_EventClient",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_EventDetails_tbl_User_EventCoordinatorID",
                        column: x => x.EventCoordinatorID,
                        principalTable: "tbl_User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_EventDetails_tbl_EventPackageDetails_PackageID",
                        column: x => x.PackageID,
                        principalTable: "tbl_EventPackageDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserMap",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: true),
                    ParentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserMap", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_UserMap_tbl_User_ParentID",
                        column: x => x.ParentID,
                        principalTable: "tbl_User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_UserMap_tbl_User_UserID",
                        column: x => x.UserID,
                        principalTable: "tbl_User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_tbl_PackageAdditionalEquipmentRequest_EquipmentID",
                table: "tbl_PackageAdditionalEquipmentRequest",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserMap_ParentID",
                table: "tbl_UserMap",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserMap_UserID",
                table: "tbl_UserMap",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_EquipmentDelivery");

            migrationBuilder.DropTable(
                name: "tbl_EquipmentDetails");

            migrationBuilder.DropTable(
                name: "tbl_EquipmentInventory");

            migrationBuilder.DropTable(
                name: "tbl_EventDetails");

            migrationBuilder.DropTable(
                name: "tbl_EventPaymentStatus");

            migrationBuilder.DropTable(
                name: "tbl_FoodDetails");

            migrationBuilder.DropTable(
                name: "tbl_FoodInventory");

            migrationBuilder.DropTable(
                name: "tbl_FoodRestock");

            migrationBuilder.DropTable(
                name: "tbl_PackageAdditionalDurationRequest");

            migrationBuilder.DropTable(
                name: "tbl_PackageAdditionalEquipmentRequest");

            migrationBuilder.DropTable(
                name: "tbl_UserMap");

            migrationBuilder.DropTable(
                name: "tbl_EventClient");

            migrationBuilder.DropTable(
                name: "tbl_EventPackageDetails");

            migrationBuilder.DropTable(
                name: "tbl_EventEquipments");

            migrationBuilder.DropTable(
                name: "tbl_User");
        }
    }
}
