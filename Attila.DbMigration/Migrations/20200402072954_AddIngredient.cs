using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Attila.DbMigration.Migrations
{
    public partial class AddIngredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentInventories_EquipmentDetails_EquipmentDetailsID",
                table: "EquipmentInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentInventories_DeliveryDetails_EquipmentRestockID",
                table: "EquipmentInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentInventories_Users_UserID",
                table: "EquipmentInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentRestockRequests_EquipmentDetails_EquipmentDetailsID",
                table: "EquipmentRestockRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentRestockRequests_Users_UserID",
                table: "EquipmentRestockRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_EventAdditionalDurationRequests_EventDetails_EventDetailsID",
                table: "EventAdditionalDurationRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_EventAdditionalEquipmentRequests_EquipmentDetails_EquipmentDetailsID",
                table: "EventAdditionalEquipmentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_EventAdditionalEquipmentRequests_EventDetails_EventDetailsID",
                table: "EventAdditionalEquipmentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_EventEquipments_EquipmentDetails_EquipmentDetailsID",
                table: "EventEquipments");

            migrationBuilder.DropForeignKey(
                name: "FK_EventEquipments_EventDetails_EventDetailsID",
                table: "EventEquipments");

            migrationBuilder.DropForeignKey(
                name: "FK_EventMenus_EventDetails_EventDetailsID",
                table: "EventMenus");

            migrationBuilder.DropForeignKey(
                name: "FK_EventMenus_Menus_MenuID",
                table: "EventMenus");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodInventories_FoodDetails_FoodDetailsID",
                table: "FoodInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodInventories_DeliveryDetails_FoodRestockID",
                table: "FoodInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodInventories_Users_UserID",
                table: "FoodInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodRestockRequests_FoodDetails_FoodDetailsID",
                table: "FoodRestockRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodRestockRequests_Users_UserID",
                table: "FoodRestockRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserID",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentStatus_EventDetails_EventDetailsID",
                table: "PaymentStatus");

            migrationBuilder.DropTable(
                name: "DeliveryDetails");

            migrationBuilder.DropTable(
                name: "EventDetails");

            migrationBuilder.DropTable(
                name: "FoodDetails");

            migrationBuilder.DropTable(
                name: "PackageEquipments");

            migrationBuilder.DropTable(
                name: "PackageMenus");

            migrationBuilder.DropTable(
                name: "SupplierDetails");

            migrationBuilder.DropTable(
                name: "ClientDetails");

            migrationBuilder.DropTable(
                name: "EquipmentDetails");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "PackageMenuDetails");

            migrationBuilder.DropTable(
                name: "MenuCategories");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_UserID",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_FoodRestockRequests_FoodDetailsID",
                table: "FoodRestockRequests");

            migrationBuilder.DropIndex(
                name: "IX_FoodRestockRequests_UserID",
                table: "FoodRestockRequests");

            migrationBuilder.DropIndex(
                name: "IX_FoodInventories_FoodDetailsID",
                table: "FoodInventories");

            migrationBuilder.DropIndex(
                name: "IX_FoodInventories_FoodRestockID",
                table: "FoodInventories");

            migrationBuilder.DropIndex(
                name: "IX_FoodInventories_UserID",
                table: "FoodInventories");

            migrationBuilder.DropIndex(
                name: "IX_EventMenus_EventDetailsID",
                table: "EventMenus");

            migrationBuilder.DropIndex(
                name: "IX_EventMenus_MenuID",
                table: "EventMenus");

            migrationBuilder.DropIndex(
                name: "IX_EventAdditionalEquipmentRequests_EquipmentDetailsID",
                table: "EventAdditionalEquipmentRequests");

            migrationBuilder.DropIndex(
                name: "IX_EventAdditionalEquipmentRequests_EventDetailsID",
                table: "EventAdditionalEquipmentRequests");

            migrationBuilder.DropIndex(
                name: "IX_EventAdditionalDurationRequests_EventDetailsID",
                table: "EventAdditionalDurationRequests");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentRestockRequests_EquipmentDetailsID",
                table: "EquipmentRestockRequests");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentRestockRequests_UserID",
                table: "EquipmentRestockRequests");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentInventories_EquipmentDetailsID",
                table: "EquipmentInventories");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentInventories_EquipmentRestockID",
                table: "EquipmentInventories");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentInventories_UserID",
                table: "EquipmentInventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentStatus",
                table: "PaymentStatus");

            migrationBuilder.DropIndex(
                name: "IX_PaymentStatus_EventDetailsID",
                table: "PaymentStatus");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "FoodDetailsID",
                table: "FoodRestockRequests");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "FoodRestockRequests");

            migrationBuilder.DropColumn(
                name: "FoodDetailsID",
                table: "FoodInventories");

            migrationBuilder.DropColumn(
                name: "FoodRestockID",
                table: "FoodInventories");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "FoodInventories");

            migrationBuilder.DropColumn(
                name: "EventDetailsID",
                table: "EventMenus");

            migrationBuilder.DropColumn(
                name: "MenuID",
                table: "EventMenus");

            migrationBuilder.DropColumn(
                name: "EquipmentDetailsID",
                table: "EventAdditionalEquipmentRequests");

            migrationBuilder.DropColumn(
                name: "EventDetailsID",
                table: "EventAdditionalEquipmentRequests");

            migrationBuilder.DropColumn(
                name: "EventDetailsID",
                table: "EventAdditionalDurationRequests");

            migrationBuilder.DropColumn(
                name: "EquipmentDetailsID",
                table: "EquipmentRestockRequests");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "EquipmentRestockRequests");

            migrationBuilder.DropColumn(
                name: "EquipmentDetailsID",
                table: "EquipmentInventories");

            migrationBuilder.DropColumn(
                name: "EquipmentRestockID",
                table: "EquipmentInventories");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "EquipmentInventories");

            migrationBuilder.DropColumn(
                name: "EventDetailsID",
                table: "PaymentStatus");

            migrationBuilder.RenameTable(
                name: "PaymentStatus",
                newName: "PaymentStatuses");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "UserLogins",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Notifications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TargetUserID",
                table: "Notifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "FoodRestockRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "FoodID",
                table: "FoodRestockRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoryManagerID",
                table: "FoodRestockRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "FoodInventories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeliveryID",
                table: "FoodInventories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FoodID",
                table: "FoodInventories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoryManagerID",
                table: "FoodInventories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "EventMenus",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DishID",
                table: "EventMenus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "EventMenus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "EventEquipments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "EventAdditionalEquipmentRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EquipmentID",
                table: "EventAdditionalEquipmentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "EventAdditionalEquipmentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "EventAdditionalDurationRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "EventAdditionalDurationRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "EquipmentRestockRequests",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EquipmentID",
                table: "EquipmentRestockRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoryManagerID",
                table: "EquipmentRestockRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "EquipmentInventories",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeliveryID",
                table: "EquipmentInventories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentID",
                table: "EquipmentInventories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoryManagerID",
                table: "EquipmentInventories",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "PaymentStatuses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EventID",
                table: "PaymentStatuses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentStatuses",
                table: "PaymentStatuses",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DishCategories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Equipments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RentalFee = table.Column<decimal>(type: "DECIMAL(20,8)", nullable: false),
                    UnitType = table.Column<byte>(nullable: false),
                    EquipmentType = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EventPackages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RatePerHead = table.Column<decimal>(type: "DECIMAL(20,8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPackages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Specification = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Unit = table.Column<byte>(nullable: false),
                    FoodType = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    ContactPersonName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DishCategoryID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Dishes_DishCategories_DishCategoryID",
                        column: x => x.DishCategoryID,
                        principalTable: "DishCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventPackageEquipments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EquipmentID = table.Column<int>(nullable: false),
                    EventPackageID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPackageEquipments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventPackageEquipments_Equipments_EquipmentID",
                        column: x => x.EquipmentID,
                        principalTable: "Equipments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventPackageEquipments_EventPackages_EventPackageID",
                        column: x => x.EventPackageID,
                        principalTable: "EventPackages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EventPackageID = table.Column<int>(nullable: false),
                    ClientID = table.Column<int>(nullable: false),
                    CoordinatorID = table.Column<int>(nullable: false),
                    Theme = table.Column<string>(nullable: true),
                    EventName = table.Column<string>(nullable: true),
                    Type = table.Column<byte>(nullable: false),
                    EventStatus = table.Column<byte>(nullable: false),
                    BookingDate = table.Column<DateTime>(nullable: false),
                    EventDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Events", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Events_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Users_CoordinatorID",
                        column: x => x.CoordinatorID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_EventPackages_EventPackageID",
                        column: x => x.EventPackageID,
                        principalTable: "EventPackages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    SupplierID = table.Column<int>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false),
                    ReceiptImage = table.Column<byte[]>(nullable: true),
                    DeliveryPrice = table.Column<decimal>(type: "DECIMAL(20,8)", nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Deliveries_Suppliers_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Suppliers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventPackageDishes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EventPackageID = table.Column<int>(nullable: false),
                    DishID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPackageDishes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventPackageDishes_Dishes_DishID",
                        column: x => x.DishID,
                        principalTable: "Dishes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventPackageDishes_EventPackages_EventPackageID",
                        column: x => x.EventPackageID,
                        principalTable: "EventPackages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DishID = table.Column<int>(nullable: false),
                    FoodID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ingredients_Dishes_DishID",
                        column: x => x.DishID,
                        principalTable: "Dishes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ingredients_Foods_FoodID",
                        column: x => x.FoodID,
                        principalTable: "Foods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: -1,
                column: "Role",
                value: (byte)1);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TargetUserID",
                table: "Notifications",
                column: "TargetUserID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRestockRequests_FoodID",
                table: "FoodRestockRequests",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRestockRequests_InventoryManagerID",
                table: "FoodRestockRequests",
                column: "InventoryManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodInventories_DeliveryID",
                table: "FoodInventories",
                column: "DeliveryID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodInventories_FoodID",
                table: "FoodInventories",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodInventories_InventoryManagerID",
                table: "FoodInventories",
                column: "InventoryManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_EventMenus_DishID",
                table: "EventMenus",
                column: "DishID");

            migrationBuilder.CreateIndex(
                name: "IX_EventMenus_EventID",
                table: "EventMenus",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventAdditionalEquipmentRequests_EquipmentID",
                table: "EventAdditionalEquipmentRequests",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_EventAdditionalEquipmentRequests_EventID",
                table: "EventAdditionalEquipmentRequests",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventAdditionalDurationRequests_EventID",
                table: "EventAdditionalDurationRequests",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentRestockRequests_EquipmentID",
                table: "EquipmentRestockRequests",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentRestockRequests_InventoryManagerID",
                table: "EquipmentRestockRequests",
                column: "InventoryManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentInventories_DeliveryID",
                table: "EquipmentInventories",
                column: "DeliveryID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentInventories_EquipmentID",
                table: "EquipmentInventories",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentInventories_InventoryManagerID",
                table: "EquipmentInventories",
                column: "InventoryManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentStatuses_EventID",
                table: "PaymentStatuses",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_SupplierID",
                table: "Deliveries",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_DishCategoryID",
                table: "Dishes",
                column: "DishCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPackageDishes_DishID",
                table: "EventPackageDishes",
                column: "DishID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPackageDishes_EventPackageID",
                table: "EventPackageDishes",
                column: "EventPackageID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPackageEquipments_EquipmentID",
                table: "EventPackageEquipments",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_EventPackageEquipments_EventPackageID",
                table: "EventPackageEquipments",
                column: "EventPackageID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ClientID",
                table: "Events",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CoordinatorID",
                table: "Events",
                column: "CoordinatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventPackageID",
                table: "Events",
                column: "EventPackageID");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_DishID",
                table: "Ingredients",
                column: "DishID");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_FoodID",
                table: "Ingredients",
                column: "FoodID");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentInventories_Deliveries_DeliveryID",
                table: "EquipmentInventories",
                column: "DeliveryID",
                principalTable: "Deliveries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentInventories_Equipments_EquipmentID",
                table: "EquipmentInventories",
                column: "EquipmentID",
                principalTable: "Equipments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentInventories_Users_InventoryManagerID",
                table: "EquipmentInventories",
                column: "InventoryManagerID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentRestockRequests_Equipments_EquipmentID",
                table: "EquipmentRestockRequests",
                column: "EquipmentID",
                principalTable: "Equipments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentRestockRequests_Users_InventoryManagerID",
                table: "EquipmentRestockRequests",
                column: "InventoryManagerID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventAdditionalDurationRequests_Events_EventID",
                table: "EventAdditionalDurationRequests",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventAdditionalEquipmentRequests_Equipments_EquipmentID",
                table: "EventAdditionalEquipmentRequests",
                column: "EquipmentID",
                principalTable: "Equipments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventAdditionalEquipmentRequests_Events_EventID",
                table: "EventAdditionalEquipmentRequests",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventEquipments_Equipments_EquipmentDetailsID",
                table: "EventEquipments",
                column: "EquipmentDetailsID",
                principalTable: "Equipments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventEquipments_Events_EventDetailsID",
                table: "EventEquipments",
                column: "EventDetailsID",
                principalTable: "Events",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventMenus_Dishes_DishID",
                table: "EventMenus",
                column: "DishID",
                principalTable: "Dishes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventMenus_Events_EventID",
                table: "EventMenus",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodInventories_Deliveries_DeliveryID",
                table: "FoodInventories",
                column: "DeliveryID",
                principalTable: "Deliveries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodInventories_Foods_FoodID",
                table: "FoodInventories",
                column: "FoodID",
                principalTable: "Foods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodInventories_Users_InventoryManagerID",
                table: "FoodInventories",
                column: "InventoryManagerID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodRestockRequests_Foods_FoodID",
                table: "FoodRestockRequests",
                column: "FoodID",
                principalTable: "Foods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodRestockRequests_Users_InventoryManagerID",
                table: "FoodRestockRequests",
                column: "InventoryManagerID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_TargetUserID",
                table: "Notifications",
                column: "TargetUserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentStatuses_Events_EventID",
                table: "PaymentStatuses",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentInventories_Deliveries_DeliveryID",
                table: "EquipmentInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentInventories_Equipments_EquipmentID",
                table: "EquipmentInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentInventories_Users_InventoryManagerID",
                table: "EquipmentInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentRestockRequests_Equipments_EquipmentID",
                table: "EquipmentRestockRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentRestockRequests_Users_InventoryManagerID",
                table: "EquipmentRestockRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_EventAdditionalDurationRequests_Events_EventID",
                table: "EventAdditionalDurationRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_EventAdditionalEquipmentRequests_Equipments_EquipmentID",
                table: "EventAdditionalEquipmentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_EventAdditionalEquipmentRequests_Events_EventID",
                table: "EventAdditionalEquipmentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_EventEquipments_Equipments_EquipmentDetailsID",
                table: "EventEquipments");

            migrationBuilder.DropForeignKey(
                name: "FK_EventEquipments_Events_EventDetailsID",
                table: "EventEquipments");

            migrationBuilder.DropForeignKey(
                name: "FK_EventMenus_Dishes_DishID",
                table: "EventMenus");

            migrationBuilder.DropForeignKey(
                name: "FK_EventMenus_Events_EventID",
                table: "EventMenus");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodInventories_Deliveries_DeliveryID",
                table: "FoodInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodInventories_Foods_FoodID",
                table: "FoodInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodInventories_Users_InventoryManagerID",
                table: "FoodInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodRestockRequests_Foods_FoodID",
                table: "FoodRestockRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodRestockRequests_Users_InventoryManagerID",
                table: "FoodRestockRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_TargetUserID",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentStatuses_Events_EventID",
                table: "PaymentStatuses");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "EventPackageDishes");

            migrationBuilder.DropTable(
                name: "EventPackageEquipments");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Equipments");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "EventPackages");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "DishCategories");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_TargetUserID",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_FoodRestockRequests_FoodID",
                table: "FoodRestockRequests");

            migrationBuilder.DropIndex(
                name: "IX_FoodRestockRequests_InventoryManagerID",
                table: "FoodRestockRequests");

            migrationBuilder.DropIndex(
                name: "IX_FoodInventories_DeliveryID",
                table: "FoodInventories");

            migrationBuilder.DropIndex(
                name: "IX_FoodInventories_FoodID",
                table: "FoodInventories");

            migrationBuilder.DropIndex(
                name: "IX_FoodInventories_InventoryManagerID",
                table: "FoodInventories");

            migrationBuilder.DropIndex(
                name: "IX_EventMenus_DishID",
                table: "EventMenus");

            migrationBuilder.DropIndex(
                name: "IX_EventMenus_EventID",
                table: "EventMenus");

            migrationBuilder.DropIndex(
                name: "IX_EventAdditionalEquipmentRequests_EquipmentID",
                table: "EventAdditionalEquipmentRequests");

            migrationBuilder.DropIndex(
                name: "IX_EventAdditionalEquipmentRequests_EventID",
                table: "EventAdditionalEquipmentRequests");

            migrationBuilder.DropIndex(
                name: "IX_EventAdditionalDurationRequests_EventID",
                table: "EventAdditionalDurationRequests");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentRestockRequests_EquipmentID",
                table: "EquipmentRestockRequests");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentRestockRequests_InventoryManagerID",
                table: "EquipmentRestockRequests");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentInventories_DeliveryID",
                table: "EquipmentInventories");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentInventories_EquipmentID",
                table: "EquipmentInventories");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentInventories_InventoryManagerID",
                table: "EquipmentInventories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentStatuses",
                table: "PaymentStatuses");

            migrationBuilder.DropIndex(
                name: "IX_PaymentStatuses_EventID",
                table: "PaymentStatuses");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "UserLogins");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "TargetUserID",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "FoodRestockRequests");

            migrationBuilder.DropColumn(
                name: "FoodID",
                table: "FoodRestockRequests");

            migrationBuilder.DropColumn(
                name: "InventoryManagerID",
                table: "FoodRestockRequests");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "FoodInventories");

            migrationBuilder.DropColumn(
                name: "DeliveryID",
                table: "FoodInventories");

            migrationBuilder.DropColumn(
                name: "FoodID",
                table: "FoodInventories");

            migrationBuilder.DropColumn(
                name: "InventoryManagerID",
                table: "FoodInventories");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "EventMenus");

            migrationBuilder.DropColumn(
                name: "DishID",
                table: "EventMenus");

            migrationBuilder.DropColumn(
                name: "EventID",
                table: "EventMenus");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "EventEquipments");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "EventAdditionalEquipmentRequests");

            migrationBuilder.DropColumn(
                name: "EquipmentID",
                table: "EventAdditionalEquipmentRequests");

            migrationBuilder.DropColumn(
                name: "EventID",
                table: "EventAdditionalEquipmentRequests");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "EventAdditionalDurationRequests");

            migrationBuilder.DropColumn(
                name: "EventID",
                table: "EventAdditionalDurationRequests");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "EquipmentRestockRequests");

            migrationBuilder.DropColumn(
                name: "EquipmentID",
                table: "EquipmentRestockRequests");

            migrationBuilder.DropColumn(
                name: "InventoryManagerID",
                table: "EquipmentRestockRequests");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "EquipmentInventories");

            migrationBuilder.DropColumn(
                name: "DeliveryID",
                table: "EquipmentInventories");

            migrationBuilder.DropColumn(
                name: "EquipmentID",
                table: "EquipmentInventories");

            migrationBuilder.DropColumn(
                name: "InventoryManagerID",
                table: "EquipmentInventories");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "PaymentStatuses");

            migrationBuilder.DropColumn(
                name: "EventID",
                table: "PaymentStatuses");

            migrationBuilder.RenameTable(
                name: "PaymentStatuses",
                newName: "PaymentStatus");

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "Notifications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FoodDetailsID",
                table: "FoodRestockRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "FoodRestockRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FoodDetailsID",
                table: "FoodInventories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FoodRestockID",
                table: "FoodInventories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "FoodInventories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventDetailsID",
                table: "EventMenus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MenuID",
                table: "EventMenus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentDetailsID",
                table: "EventAdditionalEquipmentRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventDetailsID",
                table: "EventAdditionalEquipmentRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventDetailsID",
                table: "EventAdditionalDurationRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentDetailsID",
                table: "EquipmentRestockRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "EquipmentRestockRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentDetailsID",
                table: "EquipmentInventories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentRestockID",
                table: "EquipmentInventories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "EquipmentInventories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EventDetailsID",
                table: "PaymentStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentStatus",
                table: "PaymentStatus",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "ClientDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EquipmentType = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RentalFee = table.Column<decimal>(type: "DECIMAL(20,8)", nullable: false),
                    UnitType = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FoodDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FoodType = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MenuCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PackageMenuDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPersonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuCategoryID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "EventDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EventClientID = table.Column<int>(type: "int", nullable: false),
                    EventDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationType = table.Column<int>(type: "int", nullable: false),
                    NumberOfGuests = table.Column<int>(type: "int", nullable: false),
                    PackageDetailsID = table.Column<int>(type: "int", nullable: false),
                    ProgramStart = table.Column<TimeSpan>(type: "time", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServingTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ServingType = table.Column<byte>(type: "tinyint", nullable: false),
                    Theme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    VenueType = table.Column<byte>(type: "tinyint", nullable: false)
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
                name: "PackageEquipments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentDetailsID = table.Column<int>(type: "int", nullable: false),
                    PackageMenuDetailsID = table.Column<int>(type: "int", nullable: false)
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
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryPrice = table.Column<decimal>(type: "DECIMAL(20,8)", nullable: false),
                    ReceiptImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierDetailsID = table.Column<int>(type: "int", nullable: false)
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
                name: "PackageMenus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    PackageMenuDetailsID = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: -1,
                column: "Role",
                value: (byte)2);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserID",
                table: "Notifications",
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
                name: "IX_EventMenus_EventDetailsID",
                table: "EventMenus",
                column: "EventDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_EventMenus_MenuID",
                table: "EventMenus",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_EventAdditionalEquipmentRequests_EquipmentDetailsID",
                table: "EventAdditionalEquipmentRequests",
                column: "EquipmentDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_EventAdditionalEquipmentRequests_EventDetailsID",
                table: "EventAdditionalEquipmentRequests",
                column: "EventDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_EventAdditionalDurationRequests_EventDetailsID",
                table: "EventAdditionalDurationRequests",
                column: "EventDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentRestockRequests_EquipmentDetailsID",
                table: "EquipmentRestockRequests",
                column: "EquipmentDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentRestockRequests_UserID",
                table: "EquipmentRestockRequests",
                column: "UserID");

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
                name: "IX_PaymentStatus_EventDetailsID",
                table: "PaymentStatus",
                column: "EventDetailsID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryDetails_SupplierDetailsID",
                table: "DeliveryDetails",
                column: "SupplierDetailsID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentInventories_EquipmentDetails_EquipmentDetailsID",
                table: "EquipmentInventories",
                column: "EquipmentDetailsID",
                principalTable: "EquipmentDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentInventories_DeliveryDetails_EquipmentRestockID",
                table: "EquipmentInventories",
                column: "EquipmentRestockID",
                principalTable: "DeliveryDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentInventories_Users_UserID",
                table: "EquipmentInventories",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentRestockRequests_EquipmentDetails_EquipmentDetailsID",
                table: "EquipmentRestockRequests",
                column: "EquipmentDetailsID",
                principalTable: "EquipmentDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentRestockRequests_Users_UserID",
                table: "EquipmentRestockRequests",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventAdditionalDurationRequests_EventDetails_EventDetailsID",
                table: "EventAdditionalDurationRequests",
                column: "EventDetailsID",
                principalTable: "EventDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventAdditionalEquipmentRequests_EquipmentDetails_EquipmentDetailsID",
                table: "EventAdditionalEquipmentRequests",
                column: "EquipmentDetailsID",
                principalTable: "EquipmentDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventAdditionalEquipmentRequests_EventDetails_EventDetailsID",
                table: "EventAdditionalEquipmentRequests",
                column: "EventDetailsID",
                principalTable: "EventDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventEquipments_EquipmentDetails_EquipmentDetailsID",
                table: "EventEquipments",
                column: "EquipmentDetailsID",
                principalTable: "EquipmentDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventEquipments_EventDetails_EventDetailsID",
                table: "EventEquipments",
                column: "EventDetailsID",
                principalTable: "EventDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventMenus_EventDetails_EventDetailsID",
                table: "EventMenus",
                column: "EventDetailsID",
                principalTable: "EventDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventMenus_Menus_MenuID",
                table: "EventMenus",
                column: "MenuID",
                principalTable: "Menus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodInventories_FoodDetails_FoodDetailsID",
                table: "FoodInventories",
                column: "FoodDetailsID",
                principalTable: "FoodDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodInventories_DeliveryDetails_FoodRestockID",
                table: "FoodInventories",
                column: "FoodRestockID",
                principalTable: "DeliveryDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodInventories_Users_UserID",
                table: "FoodInventories",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodRestockRequests_FoodDetails_FoodDetailsID",
                table: "FoodRestockRequests",
                column: "FoodDetailsID",
                principalTable: "FoodDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodRestockRequests_Users_UserID",
                table: "FoodRestockRequests",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserID",
                table: "Notifications",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentStatus_EventDetails_EventDetailsID",
                table: "PaymentStatus",
                column: "EventDetailsID",
                principalTable: "EventDetails",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
