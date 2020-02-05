using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Attila.Infrastructure.Migrations
{
    public partial class a : Migration
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
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UnitType = table.Column<byte>(nullable: false),
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
                    Quantity = table.Column<int>(nullable: false),
                    EncodingDate = table.Column<DateTime>(nullable: false),
                    ItemPrice = table.Column<decimal>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    EquipmentDetailsID = table.Column<int>(nullable: false),
                    EquipmentDeliveryID = table.Column<int>(nullable: false)
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
                name: "tbl_EventDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    EventName = table.Column<string>(nullable: true),
                    Type = table.Column<byte>(nullable: false),
                    EventStatus = table.Column<byte>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    EventDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    EventPackageDetailsID = table.Column<int>(nullable: false),
                    EventClientID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_EventDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_EventEquipments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentDetailsID = table.Column<int>(nullable: false),
                    EventDetailsID = table.Column<int>(nullable: false)
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
                    Remarks = table.Column<string>(nullable: true),
                    EventDetailsID = table.Column<int>(nullable: false)
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
                    ItemPrice = table.Column<decimal>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    FoodDetailsID = table.Column<int>(nullable: false),
                    FoodRestockID = table.Column<int>(nullable: false)
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
                    Rate = table.Column<decimal>(nullable: false),
                    EventDetailsID = table.Column<int>(nullable: false)
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
                name: "tbl_UserMap",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    EventDetailsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserMap", x => x.ID);
                });

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
                    table.ForeignKey(
                        name: "FK_tbl_EquipmentRestockRequest_tbl_EquipmentDetails_EquipmentDetailsID",
                        column: x => x.EquipmentDetailsID,
                        principalTable: "tbl_EquipmentDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_tbl_EventEquipmentRequest_tbl_EquipmentDetails_EquipmentDetailsID",
                        column: x => x.EquipmentDetailsID,
                        principalTable: "tbl_EquipmentDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PackageAdditionalEquipmentRequest",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentsDetailsID = table.Column<int>(nullable: false),
                    EquipmentDetailsID = table.Column<int>(nullable: true),
                    Rate = table.Column<decimal>(nullable: false),
                    EventDetailsID = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PackageAdditionalEquipmentRequest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_PackageAdditionalEquipmentRequest_tbl_EquipmentDetails_EquipmentDetailsID",
                        column: x => x.EquipmentDetailsID,
                        principalTable: "tbl_EquipmentDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                    FoodDetailsID = table.Column<int>(nullable: true),
                    Status = table.Column<byte>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_FoodRestockRequest", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_FoodRestockRequest_tbl_FoodDetails_FoodDetailsID",
                        column: x => x.FoodDetailsID,
                        principalTable: "tbl_FoodDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EquipmentRestockRequest_EquipmentDetailsID",
                table: "tbl_EquipmentRestockRequest",
                column: "EquipmentDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_EventEquipmentRequest_EquipmentDetailsID",
                table: "tbl_EventEquipmentRequest",
                column: "EquipmentDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_FoodRestockRequest_FoodDetailsID",
                table: "tbl_FoodRestockRequest",
                column: "FoodDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_PackageAdditionalEquipmentRequest_EquipmentDetailsID",
                table: "tbl_PackageAdditionalEquipmentRequest",
                column: "EquipmentDetailsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_EquipmentDelivery");

            migrationBuilder.DropTable(
                name: "tbl_EquipmentInventory");

            migrationBuilder.DropTable(
                name: "tbl_EquipmentRestockRequest");

            migrationBuilder.DropTable(
                name: "tbl_EventClient");

            migrationBuilder.DropTable(
                name: "tbl_EventDetails");

            migrationBuilder.DropTable(
                name: "tbl_EventEquipmentRequest");

            migrationBuilder.DropTable(
                name: "tbl_EventEquipments");

            migrationBuilder.DropTable(
                name: "tbl_EventPackageDetails");

            migrationBuilder.DropTable(
                name: "tbl_EventPaymentStatus");

            migrationBuilder.DropTable(
                name: "tbl_FoodInventory");

            migrationBuilder.DropTable(
                name: "tbl_FoodRestock");

            migrationBuilder.DropTable(
                name: "tbl_FoodRestockRequest");

            migrationBuilder.DropTable(
                name: "tbl_PackageAdditionalDurationRequest");

            migrationBuilder.DropTable(
                name: "tbl_PackageAdditionalEquipmentRequest");

            migrationBuilder.DropTable(
                name: "tbl_User");

            migrationBuilder.DropTable(
                name: "tbl_UserMap");

            migrationBuilder.DropTable(
                name: "tbl_FoodDetails");

            migrationBuilder.DropTable(
                name: "tbl_EquipmentDetails");
        }
    }
}
