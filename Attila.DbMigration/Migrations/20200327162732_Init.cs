using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Attila.DbMigration.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientDetails",
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
                    table.PrimaryKey("PK_ClientDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RentalFee = table.Column<decimal>(type: "DECIMAL(20,8)", nullable: false),
                    UnitType = table.Column<byte>(nullable: false),
                    EquipmentType = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FoodDetails",
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
                    table.PrimaryKey("PK_FoodDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MenuCategories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PackageMenuDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RatePerHead = table.Column<decimal>(type: "DECIMAL(20,8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageMenuDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SupplierDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    ContactPersonName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: false),
                    Position = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Role = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuCategoryID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Menus_MenuCategories_MenuCategoryID",
                        column: x => x.MenuCategoryID,
                        principalTable: "MenuCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageEquipments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentDetailsID = table.Column<int>(nullable: false),
                    PackageMenuDetailsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageEquipments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PackageEquipments_EquipmentDetails_EquipmentDetailsID",
                        column: x => x.EquipmentDetailsID,
                        principalTable: "EquipmentDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageEquipments_PackageMenuDetails_PackageMenuDetailsID",
                        column: x => x.PackageMenuDetailsID,
                        principalTable: "PackageMenuDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    ReceiptImage = table.Column<byte[]>(nullable: true),
                    DeliveryPrice = table.Column<decimal>(type: "DECIMAL(20,8)", nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    SupplierDetailsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DeliveryDetails_SupplierDetails_SupplierDetailsID",
                        column: x => x.SupplierDetailsID,
                        principalTable: "SupplierDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentRestockRequests",
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
                    table.PrimaryKey("PK_EquipmentRestockRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EquipmentRestockRequests_EquipmentDetails_EquipmentDetailsID",
                        column: x => x.EquipmentDetailsID,
                        principalTable: "EquipmentDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentRestockRequests_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventDetails",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Theme = table.Column<string>(nullable: true),
                    EventName = table.Column<string>(nullable: true),
                    Type = table.Column<byte>(nullable: false),
                    EventStatus = table.Column<byte>(nullable: false),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    EventDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    PackageDetailsID = table.Column<int>(nullable: false),
                    EventClientID = table.Column<int>(nullable: false),
                    NumberOfGuests = table.Column<int>(nullable: false),
                    ProgramStart = table.Column<TimeSpan>(nullable: false),
                    EntryTime = table.Column<TimeSpan>(nullable: false),
                    ServingTime = table.Column<TimeSpan>(nullable: false),
                    ServingType = table.Column<byte>(nullable: false),
                    VenueType = table.Column<byte>(nullable: false),
                    LocationType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventDetails_ClientDetails_EventClientID",
                        column: x => x.EventClientID,
                        principalTable: "ClientDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventDetails_PackageMenuDetails_PackageDetailsID",
                        column: x => x.PackageDetailsID,
                        principalTable: "PackageMenuDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventDetails_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodRestockRequests",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    DateTimeRequest = table.Column<DateTime>(nullable: false),
                    FoodDetailsID = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    UserID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRestockRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FoodRestockRequests_FoodDetails_FoodDetailsID",
                        column: x => x.FoodDetailsID,
                        principalTable: "FoodDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodRestockRequests_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Username = table.Column<string>(maxLength: 120, nullable: false),
                    Salt = table.Column<byte[]>(maxLength: 500, nullable: false),
                    Password = table.Column<byte[]>(maxLength: 500, nullable: false),
                    IsTemporaryPassword = table.Column<bool>(nullable: false),
                    TemporaryPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_ID",
                        column: x => x.ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PackageMenus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageMenuDetailsID = table.Column<int>(nullable: false),
                    MenuID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageMenus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PackageMenus_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PackageMenus_PackageMenuDetails_PackageMenuDetailsID",
                        column: x => x.PackageMenuDetailsID,
                        principalTable: "PackageMenuDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentInventories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    EquipmentDetailsID = table.Column<int>(nullable: false),
                    EquipmentRestockID = table.Column<int>(nullable: false),
                    EncodingDate = table.Column<DateTime>(nullable: false),
                    ItemPrice = table.Column<decimal>(type: "DECIMAL(20,8)", nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentInventories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EquipmentInventories_EquipmentDetails_EquipmentDetailsID",
                        column: x => x.EquipmentDetailsID,
                        principalTable: "EquipmentDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentInventories_DeliveryDetails_EquipmentRestockID",
                        column: x => x.EquipmentRestockID,
                        principalTable: "DeliveryDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentInventories_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodInventories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    EncodingDate = table.Column<DateTime>(nullable: false),
                    ItemPrice = table.Column<decimal>(type: "DECIMAL(20,8)", nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    FoodDetailsID = table.Column<int>(nullable: false),
                    FoodRestockID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodInventories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FoodInventories_FoodDetails_FoodDetailsID",
                        column: x => x.FoodDetailsID,
                        principalTable: "FoodDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodInventories_DeliveryDetails_FoodRestockID",
                        column: x => x.FoodRestockID,
                        principalTable: "DeliveryDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodInventories_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventAdditionalDurationRequests",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<TimeSpan>(nullable: false),
                    EventDetailsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAdditionalDurationRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventAdditionalDurationRequests_EventDetails_EventDetailsID",
                        column: x => x.EventDetailsID,
                        principalTable: "EventDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventAdditionalEquipmentRequests",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentDetailsID = table.Column<int>(nullable: false),
                    EventDetailsID = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAdditionalEquipmentRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventAdditionalEquipmentRequests_EquipmentDetails_EquipmentDetailsID",
                        column: x => x.EquipmentDetailsID,
                        principalTable: "EquipmentDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventAdditionalEquipmentRequests_EventDetails_EventDetailsID",
                        column: x => x.EventDetailsID,
                        principalTable: "EventDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventEquipments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentDetailsID = table.Column<int>(nullable: false),
                    EventDetailsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEquipments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventEquipments_EquipmentDetails_EquipmentDetailsID",
                        column: x => x.EquipmentDetailsID,
                        principalTable: "EquipmentDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventEquipments_EventDetails_EventDetailsID",
                        column: x => x.EventDetailsID,
                        principalTable: "EventDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventMenus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuID = table.Column<int>(nullable: false),
                    EventDetailsID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventMenus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventMenus_EventDetails_EventDetailsID",
                        column: x => x.EventDetailsID,
                        principalTable: "EventDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventMenus_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentStatus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventDetailsID = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "DECIMAL(20,8)", nullable: false),
                    DateOfPayment = table.Column<DateTime>(nullable: false),
                    ReferenceNumber = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PaymentStatus_EventDetails_EventDetailsID",
                        column: x => x.EventDetailsID,
                        principalTable: "EventDetails",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "ContactNumber", "Email", "Name", "Position", "Role", "UID" },
                values: new object[] { -1, null, "admin@acs.com", "Admin", null, (byte)2, new Guid("00000000-0000-0000-0000-000000000000") });

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "ID", "IsTemporaryPassword", "Password", "Salt", "TemporaryPassword", "Username" },
                values: new object[] { -1, true, new byte[] { 0, 65, 68, 77, 73, 78, 45, 83, 65, 76, 84, 45, 49, 50, 51, 52, 33, 152, 156, 47, 115, 252, 177, 181, 237, 49, 172, 91, 121, 81, 188, 196, 100, 45, 157, 169, 124, 209, 176, 77, 87, 192, 4, 80, 245, 135, 176, 31, 123 }, new byte[] { 65, 68, 77, 73, 78, 45, 83, 65, 76, 84, 45, 49, 50, 51, 52, 33, 64, 35, 36 }, "admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDetails_SupplierDetailsID",
                table: "DeliveryDetails",
                column: "SupplierDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentInventories_EquipmentDetailsID",
                table: "EquipmentInventories",
                column: "EquipmentDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentInventories_EquipmentRestockID",
                table: "EquipmentInventories",
                column: "EquipmentRestockID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentInventories_UserID",
                table: "EquipmentInventories",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentRestockRequests_EquipmentDetailsID",
                table: "EquipmentRestockRequests",
                column: "EquipmentDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentRestockRequests_UserID",
                table: "EquipmentRestockRequests",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_EventAdditionalDurationRequests_EventDetailsID",
                table: "EventAdditionalDurationRequests",
                column: "EventDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_EventAdditionalEquipmentRequests_EquipmentDetailsID",
                table: "EventAdditionalEquipmentRequests",
                column: "EquipmentDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_EventAdditionalEquipmentRequests_EventDetailsID",
                table: "EventAdditionalEquipmentRequests",
                column: "EventDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_EventDetails_EventClientID",
                table: "EventDetails",
                column: "EventClientID");

            migrationBuilder.CreateIndex(
                name: "IX_EventDetails_PackageDetailsID",
                table: "EventDetails",
                column: "PackageDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_EventDetails_UserID",
                table: "EventDetails",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_EventEquipments_EquipmentDetailsID",
                table: "EventEquipments",
                column: "EquipmentDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_EventEquipments_EventDetailsID",
                table: "EventEquipments",
                column: "EventDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_EventMenus_EventDetailsID",
                table: "EventMenus",
                column: "EventDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_EventMenus_MenuID",
                table: "EventMenus",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodInventories_FoodDetailsID",
                table: "FoodInventories",
                column: "FoodDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodInventories_FoodRestockID",
                table: "FoodInventories",
                column: "FoodRestockID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodInventories_UserID",
                table: "FoodInventories",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRestockRequests_FoodDetailsID",
                table: "FoodRestockRequests",
                column: "FoodDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRestockRequests_UserID",
                table: "FoodRestockRequests",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_MenuCategoryID",
                table: "Menus",
                column: "MenuCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PackageEquipments_EquipmentDetailsID",
                table: "PackageEquipments",
                column: "EquipmentDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_PackageEquipments_PackageMenuDetailsID",
                table: "PackageEquipments",
                column: "PackageMenuDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_PackageMenus_MenuID",
                table: "PackageMenus",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_PackageMenus_PackageMenuDetailsID",
                table: "PackageMenus",
                column: "PackageMenuDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentStatus_EventDetailsID",
                table: "PaymentStatus",
                column: "EventDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_Username",
                table: "UserLogins",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UID",
                table: "Users",
                column: "UID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipmentInventories");

            migrationBuilder.DropTable(
                name: "EquipmentRestockRequests");

            migrationBuilder.DropTable(
                name: "EventAdditionalDurationRequests");

            migrationBuilder.DropTable(
                name: "EventAdditionalEquipmentRequests");

            migrationBuilder.DropTable(
                name: "EventEquipments");

            migrationBuilder.DropTable(
                name: "EventMenus");

            migrationBuilder.DropTable(
                name: "FoodInventories");

            migrationBuilder.DropTable(
                name: "FoodRestockRequests");

            migrationBuilder.DropTable(
                name: "PackageEquipments");

            migrationBuilder.DropTable(
                name: "PackageMenus");

            migrationBuilder.DropTable(
                name: "PaymentStatus");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "DeliveryDetails");

            migrationBuilder.DropTable(
                name: "FoodDetails");

            migrationBuilder.DropTable(
                name: "EquipmentDetails");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "EventDetails");

            migrationBuilder.DropTable(
                name: "SupplierDetails");

            migrationBuilder.DropTable(
                name: "MenuCategories");

            migrationBuilder.DropTable(
                name: "ClientDetails");

            migrationBuilder.DropTable(
                name: "PackageMenuDetails");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
