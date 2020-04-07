using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Attila.DbMigration.Migrations
{
    public partial class AddedFixData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquipmentRestockRequests_Equipments_EquipmentID",
                table: "EquipmentRestockRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_EventAdditionalEquipmentRequests_Equipments_EquipmentID",
                table: "EventAdditionalEquipmentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodRestockRequests_Foods_FoodID",
                table: "FoodRestockRequests");

            migrationBuilder.DropIndex(
                name: "IX_FoodRestockRequests_FoodID",
                table: "FoodRestockRequests");

            migrationBuilder.DropIndex(
                name: "IX_EquipmentRestockRequests_EquipmentID",
                table: "EquipmentRestockRequests");

            migrationBuilder.DropColumn(
                name: "FoodID",
                table: "FoodRestockRequests");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "FoodRestockRequests");

            migrationBuilder.DropColumn(
                name: "EquipmentID",
                table: "EquipmentRestockRequests");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "EquipmentRestockRequests");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryID",
                table: "Foods",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentID",
                table: "EventAdditionalEquipmentRequests",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryID",
                table: "Equipments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentRestockRequestID",
                table: "Deliveries",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoodRestockRequestID",
                table: "Deliveries",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EquipmentRequestCollections",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EquipmentID = table.Column<int>(nullable: false),
                    EquipmentRestockRequestID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentRequestCollections", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EquipmentRequestCollections_Equipments_EquipmentID",
                        column: x => x.EquipmentID,
                        principalTable: "Equipments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentRequestCollections_EquipmentRestockRequests_EquipmentRestockRequestID",
                        column: x => x.EquipmentRestockRequestID,
                        principalTable: "EquipmentRestockRequests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventAdditionalDishRequests",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EventID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventAdditionalDishRequests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventAdditionalDishRequests_Events_EventID",
                        column: x => x.EventID,
                        principalTable: "Events",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventEquipmentRequestCollections",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EquipmentID = table.Column<int>(nullable: false),
                    EventAdditionalEquipmentRequestID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEquipmentRequestCollections", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventEquipmentRequestCollections_Equipments_EquipmentID",
                        column: x => x.EquipmentID,
                        principalTable: "Equipments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventEquipmentRequestCollections_EventAdditionalEquipmentRequests_EventAdditionalEquipmentRequestID",
                        column: x => x.EventAdditionalEquipmentRequestID,
                        principalTable: "EventAdditionalEquipmentRequests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodRequestCollections",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    FoodID = table.Column<int>(nullable: false),
                    FoodRestockRequestID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRequestCollections", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FoodRequestCollections_Foods_FoodID",
                        column: x => x.FoodID,
                        principalTable: "Foods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodRequestCollections_FoodRestockRequests_FoodRestockRequestID",
                        column: x => x.FoodRestockRequestID,
                        principalTable: "FoodRestockRequests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventDishRequests",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    AdditionalDishID = table.Column<int>(nullable: false),
                    DishID = table.Column<int>(nullable: false)
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

            migrationBuilder.InsertData(
                table: "DishCategories",
                columns: new[] { "ID", "Category", "CreatedOn" },
                values: new object[,]
                {
                    { 1, "Pork", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "PastaNoodles", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "Beverage", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "Salad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "Appetizer", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "Soup", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "Dessert", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Starch", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Vegetable", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Poultry", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Beef", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Seafood", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "EventPackages",
                columns: new[] { "ID", "Code", "CreatedOn", "Description", "Name", "RatePerHead" },
                values: new object[,]
                {
                    { 7, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "900/HEAD ", 900m },
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "400/HEAD", 400m },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "450/HEAD", 450m },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "500/HEAD", 500m },
                    { 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "600/HEAD", 600m },
                    { 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "700/HEAD ", 700m },
                    { 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "800/HEAD ", 800m },
                    { 8, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "1000/HEAD ", 1000m }
                });

            migrationBuilder.InsertData(
                table: "Dishes",
                columns: new[] { "ID", "CreatedOn", "Description", "DishCategoryID", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, " Porchetta" },
                    { 142, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Cha Gio" },
                    { 143, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Vegetable Samosa" },
                    { 144, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Bacon Croquettes" },
                    { 145, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Laing Wrap" },
                    { 146, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Sausage & Cheese" },
                    { 147, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Chicken Empanadita" },
                    { 148, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Beef Empanadita" },
                    { 149, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Spiced Nuts" },
                    { 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Parmesan Grissini" },
                    { 151, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Smoked Cheese Sticks" },
                    { 152, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Spanakopita" },
                    { 153, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Bacon & Mushroom Rolls" },
                    { 154, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Liver & Banana Skewer" },
                    { 155, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Bacon & Cheese Rolls" },
                    { 156, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Salmon & Cheese Puffs" },
                    { 157, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Fried Bacon" },
                    { 158, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Camaron Rebosado" },
                    { 159, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Smoked Cheese & Tuna Quesadilla" },
                    { 160, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 9, "Gochujang Chicken Salad" },
                    { 161, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 9, "Caesar Salad" },
                    { 162, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 9, "Caesar Salad" },
                    { 163, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 9, "Tapa Salad" },
                    { 164, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 9, "Raspberry Salad" },
                    { 141, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Thai Spring Roll" },
                    { 140, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Spinach Quiche" },
                    { 139, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Sausage Bruschetta" },
                    { 138, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 8, "Dinakdakan Tart" },
                    { 114, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, "Fish Tausi" },
                    { 115, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, "Fish Kebab" },
                    { 116, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, "Fish Souvlaki" },
                    { 117, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, "Fish Cacciatore" },
                    { 118, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, "Fish in Aligue" },
                    { 119, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, "Seafood Halabos" },
                    { 120, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, "Steamed Fish in Sweet Soy" },
                    { 121, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, "Clam Bake" },
                    { 122, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 7, "Chicken Sotanghon Soup" },
                    { 123, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 7, "Minestrone" },
                    { 124, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 7, "Spinach & Tofu" },
                    { 165, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 9, "Greek Salad" },
                    { 125, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 7, "Chicken & Corn Soup" },
                    { 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 7, "Molo Soup Tom Yum" },
                    { 128, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 7, "Chicken Noodle Soup" },
                    { 129, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 7, "Chicken Chowder" },
                    { 130, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 7, "Tomato Soup" },
                    { 131, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 7, "Chicken & Macaroni" },
                    { 132, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 7, "Arroz Caldo" },
                    { 133, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 7, "Pumpkin Soup" },
                    { 134, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 7, "Seafood Chowder" },
                    { 135, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 7, "Bacon & Lentil Soup" },
                    { 136, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 7, "Mussels & Tomato Soup" },
                    { 137, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 7, "Mushroom Soup" },
                    { 126, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 7, "Miso Soup" },
                    { 166, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Coconut Macaroon" },
                    { 167, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Maja Blanca" },
                    { 168, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Dulce De Leche" },
                    { 197, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 11, "House Blend Iced Tea" },
                    { 198, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 11, "Cucumber Lemon" },
                    { 199, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 11, "Orange Juice" },
                    { 200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 11, " Pineapple Juice" },
                    { 201, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, "Pancit Bihon" },
                    { 202, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, "Pancit Canton" },
                    { 203, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, "Pancit Sotanghon" },
                    { 204, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, "Chicken & Chorizo" },
                    { 205, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, "Carbonara" },
                    { 206, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, "Pomodoro" },
                    { 207, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, "Bolognese" },
                    { 196, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Black Sesame Cream Puffs" },
                    { 208, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, "Spaghetti" },
                    { 210, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, "Chicken Pesto" },
                    { 211, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, "Pad Thai" },
                    { 212, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, "Japchae" },
                    { 213, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, "Tinapa Pasta" },
                    { 214, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, " Vegetable Bolognese" },
                    { 215, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, "Pancit Habhab" },
                    { 216, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, "Crab Fat Pasta" },
                    { 217, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, "Chicken Alfredo" },
                    { 218, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, "Seafood Marinara" },
                    { 219, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, "Olive and Anchovy Pasta" },
                    { 220, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, "Cha Misua" },
                    { 209, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, "Kung Pao Chicken" },
                    { 113, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, "Tinolang Tahong" },
                    { 195, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Chocolate Cream Puffs" },
                    { 193, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Blueberry Cheesecake" },
                    { 169, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Calamansi Buttercake" },
                    { 170, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Coffee Jelly" },
                    { 171, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Mango Sago" },
                    { 172, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Almond Tofu" },
                    { 173, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Mandarin Orange Tart" },
                    { 174, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Tart Chocolat" },
                    { 175, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Signature Chocolate Cake" },
                    { 176, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "New Orleans Doughnut (Beignet)" },
                    { 177, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Green Tea Tiramisu" },
                    { 178, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Chocolate Tiramisu" },
                    { 179, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, " Mango Float" },
                    { 194, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Tocino Del Cielo" },
                    { 180, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Strawberries & Cream Puff" },
                    { 182, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Crème Brulee" },
                    { 183, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Pannacotta" },
                    { 184, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Mango Pannacotta" },
                    { 185, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Tres Leches" },
                    { 186, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Fruit Salad" },
                    { 187, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Bomboloni" },
                    { 188, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Chocolate Mousse" },
                    { 189, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Tofu Mousse" },
                    { 190, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Raspberry Taho" },
                    { 191, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Smores Cheesecake" },
                    { 192, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Strawberry Cheesecake" },
                    { 181, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 10, "Coffee Cream Puff" },
                    { 112, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, "Seafood Casserole" },
                    { 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, "Thai Fish Cakes" },
                    { 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, "Mussels in White Wine" },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, "South American Stir-Fried" },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, "Beef Rosemary Roast Beef" },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, "Beef Bourguignon" },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, "Cuban Roast Beef" },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, "Beef Salisbury" },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, "Galbi Jjim" },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, "Beef Rendang" },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, "Beef Stroganoff" },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, "Beef & Broccoli" },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, "Mongolian Beef" },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, "Beef in Aligue" },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, "Beef Korma" },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, "Beef Kaldereta" },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Boneless Chicken BBQ" },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Chicken Inasal" },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Chicken Pastel" },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Chicken Tandoori" },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Tex-Mex Grilled Chicken" },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Chicken Kebab" },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Chicken Cacciatore" },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Chicken Galantine" },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Lemon Rosemary Chicken" },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Chicken Satay" },
                    { 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Chicken Yakitori" },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, "Beef Pochero" },
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Chicken Sambal" },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, "Italian Beef Stew" },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, "Beef Kare Kare" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "Vietnamese Glazed Pork" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "Pork Cassoulet" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "Beer Braised Pork" },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "Apple Roast Pork Belly " },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "3 Hour Roasted Belly" },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "Pork Binagoongan" },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "Soy Anise Pork Chop" },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "Pork Barbecue" },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "Lechon Kawali " },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "Sinigang na Lechon Kawali" },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "Sisig" },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, "Beef Curry" },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "Pork Dinakdakan" },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "Pork Humba" },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "Pork Hamonado" },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "Pork Ribs in Black Bean Sauce" },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "Barbecue Ribs" },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "House Smoked Liempo" },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "Oriental Roast Pork" },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "Balsamic Pork Tenderloin" },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "Sinigang na Lechon Kawali" },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "Twice Cooked Pork in Tamarind Sauce" },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, "Beef Pares" },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 2, " Bistek Tagalog" },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 1, "Pork Ala Cubana" },
                    { 221, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, "Mushroom & Truffle Pasta" },
                    { 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Chicken Pesto" },
                    { 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Buttermilk Fried Chicken" },
                    { 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Vegetable Kare Kare" },
                    { 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Tofu Binagoongan" },
                    { 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Vegetable Pesto" },
                    { 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 5, "Steamed Rice" },
                    { 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 5, "Pandan Steamed Rice" },
                    { 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 5, "Garlic Rice" },
                    { 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 5, "Mexican Rice" },
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 5, "Java Rice" },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 5, "Chinese Fried Rice" },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 5, "Tinapa Rice" },
                    { 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 5, "Bagoong Rice" },
                    { 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Mushroom & Water Chestnut" },
                    { 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 5, "Aligue Rice" },
                    { 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 5, "Mashed Potato" },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 5, "Potato Fries" },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, "Fish Laksa" },
                    { 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, "Fish Fingers" },
                    { 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, "Clams De Manille" },
                    { 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, "Mussels Halabos" },
                    { 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, "Sweet & Sour Fish" },
                    { 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, "Seafood Gumbo" },
                    { 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, "Seafood Sambal" },
                    { 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, "Sinaing na Tulingan" },
                    { 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 6, "Vegetable Stuffed Squid" },
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 5, "Vegetable Fried Rice" },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Orange Chicken" },
                    { 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Apple Kimchi" },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Vegetable Chimichurri" },
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Lechon Manok" },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Garlic Fried Chicken" },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Chicken Florentine" },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Chicken Souvlaki" },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Chicken Teriyaki" },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Chicken Cordon Bleu" },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 3, "Chicken, Mushroom & Tofu" },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Honey Ginger & Tofu" },
                    { 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Eggplant Cups" },
                    { 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Beans & Mushroom" },
                    { 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Chopseuy" },
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Patatas Bravas" },
                    { 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Pakbet" },
                    { 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Lentil Curry" },
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Corn & Cabbage" },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Vegetable Casserole" },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Cajun Roasted Potato" },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Vegetable Parmesan" },
                    { 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Stir Fried Mushroom & Tomyao" },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Vegetable Kebab" },
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Sriracha Tofu" },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Tofu Spring Roll" },
                    { 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Mushroom & Tofu" },
                    { 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Buttered Vegetable" },
                    { 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 4, "Gising Gising" },
                    { 222, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 12, "Cheesy Taco Pasta" }
                });

            migrationBuilder.InsertData(
                table: "EventPackageDishes",
                columns: new[] { "ID", "CreatedOn", "DishID", "EventPackageID" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 506, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 144, 6 },
                    { 655, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 144, 7 },
                    { 992, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 144, 8 },
                    { 507, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 145, 6 },
                    { 656, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 145, 7 },
                    { 993, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 145, 8 },
                    { 508, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 146, 6 },
                    { 657, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 146, 7 },
                    { 994, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 146, 8 },
                    { 509, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 147, 6 },
                    { 658, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 147, 7 },
                    { 995, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 147, 8 },
                    { 510, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 148, 6 },
                    { 659, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 148, 7 },
                    { 996, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 148, 8 },
                    { 511, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 149, 6 },
                    { 660, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 149, 7 },
                    { 997, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 149, 8 },
                    { 512, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 150, 6 },
                    { 661, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 150, 7 },
                    { 998, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 150, 8 },
                    { 513, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 151, 6 },
                    { 662, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 151, 7 },
                    { 999, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 151, 8 },
                    { 663, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 152, 7 },
                    { 1000, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 152, 8 },
                    { 664, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 153, 7 },
                    { 1001, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 153, 8 },
                    { 665, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 154, 7 },
                    { 991, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 143, 8 },
                    { 1002, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 154, 8 },
                    { 654, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 143, 7 },
                    { 990, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 142, 8 },
                    { 370, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 131, 5 },
                    { 498, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 131, 6 },
                    { 646, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 131, 7 },
                    { 979, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 131, 8 },
                    { 371, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 132, 5 },
                    { 499, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 132, 6 },
                    { 645, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 132, 7 },
                    { 980, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 132, 8 },
                    { 981, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 133, 8 },
                    { 982, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 134, 8 },
                    { 983, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 135, 8 },
                    { 647, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 136, 7 },
                    { 984, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 136, 8 },
                    { 648, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 137, 7 },
                    { 985, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 137, 8 },
                    { 500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 138, 6 },
                    { 649, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 138, 7 },
                    { 986, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 138, 8 },
                    { 501, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 139, 6 },
                    { 650, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 139, 7 },
                    { 987, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 139, 8 },
                    { 502, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 140, 6 },
                    { 651, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 140, 7 },
                    { 988, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 140, 8 },
                    { 503, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 141, 6 },
                    { 652, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 141, 7 },
                    { 989, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 141, 8 },
                    { 504, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 142, 6 },
                    { 653, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 142, 7 },
                    { 505, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 143, 6 },
                    { 666, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 155, 7 },
                    { 1003, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 155, 8 },
                    { 667, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 156, 7 },
                    { 616, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 168, 6 },
                    { 816, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 168, 7 },
                    { 1016, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 168, 8 },
                    { 50, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 169, 1 },
                    { 121, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 169, 2 },
                    { 229, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 169, 3 },
                    { 339, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 169, 4 },
                    { 467, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 169, 5 },
                    { 617, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 169, 6 },
                    { 817, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 169, 7 },
                    { 1017, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 169, 8 },
                    { 51, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 170, 1 },
                    { 122, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 170, 2 },
                    { 230, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 170, 3 },
                    { 340, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 170, 4 },
                    { 468, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 170, 5 },
                    { 618, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 170, 6 },
                    { 818, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 170, 7 },
                    { 1018, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 170, 8 },
                    { 52, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 171, 1 },
                    { 123, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 171, 2 },
                    { 231, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 171, 3 },
                    { 341, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 171, 4 },
                    { 469, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 171, 5 },
                    { 619, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 171, 6 },
                    { 819, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 171, 7 },
                    { 1019, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 171, 8 },
                    { 53, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 172, 1 },
                    { 124, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 172, 2 },
                    { 466, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 168, 5 },
                    { 338, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 168, 4 },
                    { 228, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 168, 3 },
                    { 120, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 168, 2 },
                    { 1004, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 156, 8 },
                    { 668, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 157, 7 },
                    { 1005, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 157, 8 },
                    { 669, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 158, 7 },
                    { 1006, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 158, 8 },
                    { 670, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 159, 7 },
                    { 1007, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 159, 8 },
                    { 1008, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 160, 8 },
                    { 1009, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 161, 8 },
                    { 1010, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 162, 8 },
                    { 1011, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 163, 8 },
                    { 1012, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 164, 8 },
                    { 1013, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 165, 8 },
                    { 47, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 166, 1 },
                    { 978, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 130, 8 },
                    { 118, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 166, 2 },
                    { 336, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 166, 4 },
                    { 464, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 166, 5 },
                    { 614, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 166, 6 },
                    { 814, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 166, 7 },
                    { 1014, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 166, 8 },
                    { 48, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 167, 1 },
                    { 119, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 167, 2 },
                    { 227, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 167, 3 },
                    { 337, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 167, 4 },
                    { 465, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 167, 5 },
                    { 615, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 167, 6 },
                    { 815, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 167, 7 },
                    { 1015, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 167, 8 },
                    { 49, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 168, 1 },
                    { 226, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 166, 3 },
                    { 644, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 130, 7 },
                    { 497, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 130, 6 },
                    { 369, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 130, 5 },
                    { 954, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 8 },
                    { 174, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 3 },
                    { 269, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 4 },
                    { 397, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 5 },
                    { 539, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 6 },
                    { 696, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 7 },
                    { 955, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 107, 8 },
                    { 175, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 3 },
                    { 270, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 4 },
                    { 398, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 5 },
                    { 540, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 6 },
                    { 697, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 7 },
                    { 956, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 108, 8 },
                    { 176, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 3 },
                    { 271, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 4 },
                    { 399, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 5 },
                    { 541, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 6 },
                    { 698, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 7 },
                    { 957, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 109, 8 },
                    { 177, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 3 },
                    { 272, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 4 },
                    { 400, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 5 },
                    { 542, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 6 },
                    { 699, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 7 },
                    { 958, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 110, 8 },
                    { 178, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 3 },
                    { 273, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 4 },
                    { 401, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 5 },
                    { 543, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 6 },
                    { 695, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 7 },
                    { 538, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 6 },
                    { 396, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 5 },
                    { 268, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 4 },
                    { 263, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 4 },
                    { 391, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 5 },
                    { 533, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 6 },
                    { 690, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 7 },
                    { 949, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 8 },
                    { 169, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 3 },
                    { 264, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 4 },
                    { 392, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 5 },
                    { 534, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 6 },
                    { 691, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 7 },
                    { 950, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 102, 8 },
                    { 170, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 3 },
                    { 265, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 4 },
                    { 393, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 5 },
                    { 700, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 7 },
                    { 535, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 6 },
                    { 951, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 8 },
                    { 171, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 3 },
                    { 266, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 4 },
                    { 394, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 5 },
                    { 536, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 6 },
                    { 693, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 7 },
                    { 952, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 104, 8 },
                    { 172, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 3 },
                    { 267, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 4 },
                    { 395, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 5 },
                    { 537, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 6 },
                    { 694, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 7 },
                    { 953, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 105, 8 },
                    { 173, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 106, 3 },
                    { 692, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 103, 7 },
                    { 232, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 172, 3 },
                    { 959, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 111, 8 },
                    { 274, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 4 },
                    { 361, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 122, 5 },
                    { 489, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 122, 6 },
                    { 639, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 122, 7 },
                    { 970, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 122, 8 },
                    { 362, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 123, 5 },
                    { 490, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 123, 6 },
                    { 640, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 123, 7 },
                    { 971, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 123, 8 },
                    { 363, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 124, 5 },
                    { 491, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 124, 6 },
                    { 641, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 124, 7 },
                    { 972, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 124, 8 },
                    { 364, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 125, 5 },
                    { 492, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 125, 6 },
                    { 973, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 125, 8 },
                    { 365, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 126, 5 },
                    { 493, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 126, 6 },
                    { 974, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 126, 8 },
                    { 366, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 127, 5 },
                    { 494, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 127, 6 },
                    { 975, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 127, 8 },
                    { 367, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 128, 5 },
                    { 495, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 128, 6 },
                    { 642, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 128, 7 },
                    { 976, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 128, 8 },
                    { 368, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 129, 5 },
                    { 496, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 129, 6 },
                    { 643, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 129, 7 },
                    { 977, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 129, 8 },
                    { 969, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 121, 8 },
                    { 710, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 121, 7 },
                    { 553, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 121, 6 },
                    { 968, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 120, 8 },
                    { 402, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 5 },
                    { 544, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 6 },
                    { 701, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 7 },
                    { 960, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 8 },
                    { 180, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 3 },
                    { 275, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 4 },
                    { 403, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 5 },
                    { 545, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 6 },
                    { 702, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 7 },
                    { 961, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 113, 8 },
                    { 546, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 6 },
                    { 703, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 7 },
                    { 962, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 114, 8 },
                    { 547, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 6 },
                    { 179, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 112, 3 },
                    { 704, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 7 },
                    { 548, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 116, 6 },
                    { 705, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 116, 7 },
                    { 964, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 116, 8 },
                    { 549, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 117, 6 },
                    { 706, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 117, 7 },
                    { 965, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 117, 8 },
                    { 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 118, 6 },
                    { 707, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 118, 7 },
                    { 966, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 118, 8 },
                    { 551, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 119, 6 },
                    { 708, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 119, 7 },
                    { 967, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 119, 8 },
                    { 552, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 120, 6 },
                    { 709, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 120, 7 },
                    { 963, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 115, 8 },
                    { 342, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 172, 4 },
                    { 470, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 172, 5 },
                    { 620, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 172, 6 },
                    { 450, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 201, 5 },
                    { 599, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 201, 6 },
                    { 780, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 201, 7 },
                    { 1049, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 201, 8 },
                    { 144, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 202, 2 },
                    { 322, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 202, 4 },
                    { 451, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 202, 5 },
                    { 600, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 202, 6 },
                    { 781, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 202, 7 },
                    { 1050, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 202, 8 },
                    { 145, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 203, 2 },
                    { 323, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 203, 4 },
                    { 452, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 203, 5 },
                    { 601, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 203, 6 },
                    { 782, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 203, 7 },
                    { 1051, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 203, 8 },
                    { 146, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 204, 2 },
                    { 324, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 204, 4 },
                    { 453, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 204, 5 },
                    { 602, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 204, 6 },
                    { 783, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 204, 7 },
                    { 1052, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 204, 8 },
                    { 147, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 205, 2 },
                    { 325, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 205, 4 },
                    { 454, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 205, 5 },
                    { 603, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 205, 6 },
                    { 784, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 205, 7 },
                    { 1053, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 205, 8 },
                    { 148, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 206, 2 },
                    { 321, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 201, 4 },
                    { 143, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 201, 2 },
                    { 1048, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200, 8 },
                    { 848, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200, 7 },
                    { 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 197, 1 },
                    { 139, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 197, 2 },
                    { 247, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 197, 3 },
                    { 357, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 197, 4 },
                    { 485, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 197, 5 },
                    { 635, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 197, 6 },
                    { 845, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 197, 7 },
                    { 1045, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 197, 8 },
                    { 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 198, 1 },
                    { 140, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 198, 2 },
                    { 248, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 198, 3 },
                    { 358, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 198, 4 },
                    { 486, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 198, 5 },
                    { 636, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 198, 6 },
                    { 326, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 206, 4 },
                    { 846, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 198, 7 },
                    { 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 199, 1 },
                    { 141, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 199, 2 },
                    { 249, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 199, 3 },
                    { 359, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 199, 4 },
                    { 487, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 199, 5 },
                    { 637, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 199, 6 },
                    { 847, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 199, 7 },
                    { 1047, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 199, 8 },
                    { 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200, 1 },
                    { 142, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200, 2 },
                    { 250, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200, 3 },
                    { 360, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200, 4 },
                    { 488, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200, 5 },
                    { 638, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 200, 6 },
                    { 1046, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 198, 8 },
                    { 1044, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 196, 8 },
                    { 455, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 206, 5 },
                    { 785, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 206, 7 },
                    { 610, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 212, 6 },
                    { 791, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 212, 7 },
                    { 1060, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 212, 8 },
                    { 155, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 213, 2 },
                    { 333, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 213, 4 },
                    { 462, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 213, 5 },
                    { 611, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 213, 6 },
                    { 792, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 213, 7 },
                    { 1061, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 213, 8 },
                    { 156, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 214, 2 },
                    { 334, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 214, 4 },
                    { 463, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 214, 5 },
                    { 612, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 214, 6 },
                    { 793, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 214, 7 },
                    { 1062, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 214, 8 },
                    { 794, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 215, 7 },
                    { 1063, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 215, 8 },
                    { 795, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 216, 7 },
                    { 1064, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 216, 8 },
                    { 796, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 217, 7 },
                    { 1065, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 217, 8 },
                    { 797, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 218, 7 },
                    { 1066, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 218, 8 },
                    { 798, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 219, 7 },
                    { 1067, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 219, 8 },
                    { 799, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 220, 7 },
                    { 1068, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 220, 8 },
                    { 800, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 221, 7 },
                    { 1069, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 221, 8 },
                    { 461, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 212, 5 },
                    { 332, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 212, 4 },
                    { 154, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 212, 2 },
                    { 1059, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 211, 8 },
                    { 1054, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 206, 8 },
                    { 149, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 207, 2 },
                    { 327, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 207, 4 },
                    { 456, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 207, 5 },
                    { 605, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 207, 6 },
                    { 786, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 207, 7 },
                    { 1055, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 207, 8 },
                    { 150, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 208, 2 },
                    { 328, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 208, 4 },
                    { 457, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 208, 5 },
                    { 606, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 208, 6 },
                    { 787, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 208, 7 },
                    { 1056, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 208, 8 },
                    { 151, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 209, 2 },
                    { 604, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 206, 6 },
                    { 329, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 209, 4 },
                    { 607, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 209, 6 },
                    { 788, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 209, 7 },
                    { 1057, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 209, 8 },
                    { 152, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 210, 2 },
                    { 330, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 210, 4 },
                    { 459, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 210, 5 },
                    { 608, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 210, 6 },
                    { 789, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 210, 7 },
                    { 1058, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 210, 8 },
                    { 153, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 211, 2 },
                    { 331, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 211, 4 },
                    { 460, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 211, 5 },
                    { 609, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 211, 6 },
                    { 790, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 211, 7 },
                    { 458, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 209, 5 },
                    { 168, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 101, 3 },
                    { 844, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 196, 7 },
                    { 843, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 195, 7 },
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 177, 1 },
                    { 129, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 177, 2 },
                    { 237, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 177, 3 },
                    { 347, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 177, 4 },
                    { 475, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 177, 5 },
                    { 625, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 177, 6 },
                    { 825, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 177, 7 },
                    { 1025, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 177, 8 },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 178, 1 },
                    { 130, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 178, 2 },
                    { 238, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 178, 3 },
                    { 348, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 178, 4 },
                    { 476, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 178, 5 },
                    { 626, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 178, 6 },
                    { 826, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 178, 7 },
                    { 1026, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 178, 8 },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 179, 1 },
                    { 131, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 179, 2 },
                    { 239, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 179, 3 },
                    { 349, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 179, 4 },
                    { 477, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 179, 5 },
                    { 627, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 179, 6 },
                    { 827, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 179, 7 },
                    { 1027, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 179, 8 },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 180, 1 },
                    { 132, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 180, 2 },
                    { 240, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 180, 3 },
                    { 350, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 180, 4 },
                    { 478, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 180, 5 },
                    { 1024, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 176, 8 },
                    { 824, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 176, 7 },
                    { 624, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 176, 6 },
                    { 474, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 176, 5 },
                    { 820, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 172, 7 },
                    { 1020, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 172, 8 },
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 173, 1 },
                    { 125, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 173, 2 },
                    { 233, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 173, 3 },
                    { 343, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 173, 4 },
                    { 471, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 173, 5 },
                    { 621, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 173, 6 },
                    { 821, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 173, 7 },
                    { 1021, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 173, 8 },
                    { 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 174, 1 },
                    { 126, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 174, 2 },
                    { 234, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 174, 3 },
                    { 344, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 174, 4 },
                    { 628, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 180, 6 },
                    { 472, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 174, 5 },
                    { 822, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 174, 7 },
                    { 1022, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 174, 8 },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 175, 1 },
                    { 127, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 175, 2 },
                    { 235, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 175, 3 },
                    { 345, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 175, 4 },
                    { 473, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 175, 5 },
                    { 623, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 175, 6 },
                    { 823, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 175, 7 },
                    { 1023, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 175, 8 },
                    { 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 176, 1 },
                    { 128, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 176, 2 },
                    { 236, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 176, 3 },
                    { 346, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 176, 4 },
                    { 622, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 174, 6 },
                    { 1043, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 195, 8 },
                    { 828, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 180, 7 },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 181, 1 },
                    { 355, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 185, 4 },
                    { 483, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 185, 5 },
                    { 633, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 185, 6 },
                    { 833, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 185, 7 },
                    { 1033, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 185, 8 },
                    { 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 186, 1 },
                    { 138, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 186, 2 },
                    { 246, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 186, 3 },
                    { 356, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 186, 4 },
                    { 484, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 186, 5 },
                    { 634, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 186, 6 },
                    { 834, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 186, 7 },
                    { 1034, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 186, 8 },
                    { 835, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 187, 7 },
                    { 1035, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 187, 8 },
                    { 836, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 188, 7 },
                    { 1036, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 188, 8 },
                    { 837, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 189, 7 },
                    { 1037, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 189, 8 },
                    { 838, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 190, 7 },
                    { 1038, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 190, 8 },
                    { 839, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 191, 7 },
                    { 1039, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 191, 8 },
                    { 840, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 192, 7 },
                    { 1040, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 192, 8 },
                    { 841, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 193, 7 },
                    { 1041, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 193, 8 },
                    { 842, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 194, 7 },
                    { 1042, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 194, 8 },
                    { 245, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 185, 3 },
                    { 137, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 185, 2 },
                    { 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 185, 1 },
                    { 1032, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 184, 8 },
                    { 133, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 181, 2 },
                    { 241, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 181, 3 },
                    { 351, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 181, 4 },
                    { 479, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 181, 5 },
                    { 629, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 181, 6 },
                    { 829, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 181, 7 },
                    { 1029, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 181, 8 },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 182, 1 },
                    { 134, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 182, 2 },
                    { 242, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 182, 3 },
                    { 352, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 182, 4 },
                    { 480, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 182, 5 },
                    { 630, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 182, 6 },
                    { 830, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 182, 7 },
                    { 1028, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 180, 8 },
                    { 1030, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 182, 8 },
                    { 135, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 183, 2 },
                    { 243, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 183, 3 },
                    { 353, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 183, 4 },
                    { 481, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 183, 5 },
                    { 631, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 183, 6 },
                    { 831, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 183, 7 }
                });

            migrationBuilder.InsertData(
                table: "EventPackageDishes",
                columns: new[] { "ID", "CreatedOn", "DishID", "EventPackageID" },
                values: new object[,]
                {
                    { 1031, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 183, 8 },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 184, 1 },
                    { 136, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 184, 2 },
                    { 244, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 184, 3 },
                    { 354, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 184, 4 },
                    { 482, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 184, 5 },
                    { 632, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 184, 6 },
                    { 832, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 184, 7 },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 183, 1 },
                    { 948, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 8 },
                    { 813, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 7 },
                    { 947, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 8 },
                    { 517, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 6 },
                    { 674, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 7 },
                    { 875, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 8 },
                    { 161, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 3 },
                    { 256, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 4 },
                    { 376, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 5 },
                    { 518, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 6 },
                    { 675, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 7 },
                    { 876, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 28, 8 },
                    { 162, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, 3 },
                    { 257, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, 4 },
                    { 377, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, 5 },
                    { 519, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, 6 },
                    { 676, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, 7 },
                    { 877, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 29, 8 },
                    { 163, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 3 },
                    { 258, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 4 },
                    { 378, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 5 },
                    { 520, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 6 },
                    { 677, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 7 },
                    { 878, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30, 8 },
                    { 164, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, 3 },
                    { 259, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, 4 },
                    { 379, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, 5 },
                    { 521, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, 6 },
                    { 678, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, 7 },
                    { 879, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 31, 8 },
                    { 165, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 3 },
                    { 260, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 4 },
                    { 375, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 5 },
                    { 255, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 4 },
                    { 160, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 27, 3 },
                    { 874, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, 8 },
                    { 865, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 8 },
                    { 728, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 7 },
                    { 866, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18, 8 },
                    { 729, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, 7 },
                    { 867, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 19, 8 },
                    { 730, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 7 },
                    { 868, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20, 8 },
                    { 731, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 7 },
                    { 869, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 21, 8 },
                    { 732, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 7 },
                    { 870, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 22, 8 },
                    { 733, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 7 },
                    { 871, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 23, 8 },
                    { 157, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 3 },
                    { 380, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 5 },
                    { 252, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 4 },
                    { 514, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 6 },
                    { 671, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 7 },
                    { 872, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 8 },
                    { 158, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 3 },
                    { 253, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 4 },
                    { 373, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 5 },
                    { 515, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 6 },
                    { 672, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 7 },
                    { 873, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25, 8 },
                    { 159, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, 3 },
                    { 254, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, 4 },
                    { 374, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, 5 },
                    { 516, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, 6 },
                    { 673, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 26, 7 },
                    { 372, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 24, 5 },
                    { 727, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 7 },
                    { 522, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 6 },
                    { 880, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 8 },
                    { 687, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 7 },
                    { 888, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 8 },
                    { 389, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 41, 5 },
                    { 531, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 41, 6 },
                    { 688, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 41, 7 },
                    { 889, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 41, 8 },
                    { 390, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, 5 },
                    { 532, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, 6 },
                    { 689, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, 7 },
                    { 890, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 42, 8 },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 1 },
                    { 89, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 2 },
                    { 198, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 3 },
                    { 293, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 4 },
                    { 421, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 5 },
                    { 571, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 6 },
                    { 734, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 7 },
                    { 891, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 43, 8 },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 1 },
                    { 90, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 2 },
                    { 199, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 3 },
                    { 294, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 4 },
                    { 422, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 5 },
                    { 572, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 6 },
                    { 735, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 7 },
                    { 892, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 44, 8 },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 1 },
                    { 91, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 2 },
                    { 200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 3 },
                    { 530, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 6 },
                    { 388, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40, 5 },
                    { 887, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 8 },
                    { 686, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 7 },
                    { 166, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 3 },
                    { 261, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 4 },
                    { 381, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 5 },
                    { 523, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 6 },
                    { 680, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 7 },
                    { 881, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 33, 8 },
                    { 167, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, 3 },
                    { 262, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, 4 },
                    { 382, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, 5 },
                    { 524, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, 6 },
                    { 681, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, 7 },
                    { 882, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 34, 8 },
                    { 383, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, 5 },
                    { 525, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, 6 },
                    { 679, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 32, 7 },
                    { 682, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, 7 },
                    { 384, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 36, 5 },
                    { 526, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 36, 6 },
                    { 683, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 36, 7 },
                    { 884, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 36, 8 },
                    { 385, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, 5 },
                    { 527, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, 6 },
                    { 684, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, 7 },
                    { 885, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 37, 8 },
                    { 386, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, 5 },
                    { 528, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, 6 },
                    { 685, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, 7 },
                    { 886, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 38, 8 },
                    { 387, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 5 },
                    { 529, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 39, 6 },
                    { 883, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 35, 8 },
                    { 295, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 4 },
                    { 570, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 6 },
                    { 292, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 4 },
                    { 280, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 4 },
                    { 408, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5 },
                    { 558, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 6 },
                    { 715, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 7 },
                    { 853, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 8 },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 77, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 2 },
                    { 186, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 3 },
                    { 281, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 4 },
                    { 409, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 5 },
                    { 559, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 6 },
                    { 716, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 7 },
                    { 854, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 8 },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 1 },
                    { 78, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 2 },
                    { 187, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 3 },
                    { 282, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 4 },
                    { 410, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 5 },
                    { 560, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 6 },
                    { 717, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 7 },
                    { 855, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 8 },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 1 },
                    { 79, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 2 },
                    { 188, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 3 },
                    { 283, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 4 },
                    { 411, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 5 },
                    { 561, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 6 },
                    { 718, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 7 },
                    { 856, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 8 },
                    { 185, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 3 },
                    { 76, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 2 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 852, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 8 },
                    { 72, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 181, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 },
                    { 276, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4 },
                    { 404, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5 },
                    { 554, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 6 },
                    { 711, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 7 },
                    { 849, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 8 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 73, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 182, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3 },
                    { 277, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 4 },
                    { 405, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 5 },
                    { 555, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 6 },
                    { 712, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 7 },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 1 },
                    { 850, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 8 },
                    { 74, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 },
                    { 183, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 },
                    { 278, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4 },
                    { 406, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 5 },
                    { 556, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 6 },
                    { 713, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 7 },
                    { 851, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 8 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 75, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 2 },
                    { 184, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3 },
                    { 279, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4 },
                    { 407, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 5 },
                    { 557, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 6 },
                    { 714, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 7 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 420, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 5 },
                    { 80, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 2 },
                    { 284, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 4 },
                    { 723, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 7 },
                    { 861, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 8 },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 1 },
                    { 85, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 2 },
                    { 194, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 3 },
                    { 289, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 4 },
                    { 417, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 5 },
                    { 567, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 6 },
                    { 724, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 7 },
                    { 862, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 8 },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 1 },
                    { 86, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 2 },
                    { 195, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 3 },
                    { 290, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 4 },
                    { 418, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 5 },
                    { 568, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 6 },
                    { 725, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 7 },
                    { 863, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 8 },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 1 },
                    { 87, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 2 },
                    { 196, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 3 },
                    { 291, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 4 },
                    { 419, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 5 },
                    { 569, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 6 },
                    { 726, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 7 },
                    { 864, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 8 },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 1 },
                    { 88, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 2 },
                    { 197, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 3 },
                    { 566, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 6 },
                    { 416, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 5 },
                    { 288, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 4 },
                    { 193, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 3 },
                    { 412, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 5 },
                    { 562, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 6 },
                    { 719, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 7 },
                    { 857, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 8 },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1 },
                    { 81, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 2 },
                    { 190, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 3 },
                    { 285, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 4 },
                    { 413, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 5 },
                    { 563, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 6 },
                    { 720, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 7 },
                    { 858, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 8 },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 1 },
                    { 82, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 2 },
                    { 189, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 3 },
                    { 191, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 3 },
                    { 414, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 5 },
                    { 564, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 6 },
                    { 721, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 7 },
                    { 859, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 8 },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 1 },
                    { 83, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 2 },
                    { 192, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 3 },
                    { 287, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 4 },
                    { 415, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 5 },
                    { 565, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 6 },
                    { 722, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 7 },
                    { 860, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 8 },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 1 },
                    { 84, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 2 },
                    { 286, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 4 },
                    { 801, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 222, 7 },
                    { 423, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 5 },
                    { 736, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 7 },
                    { 592, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 6 },
                    { 764, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 7 },
                    { 921, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 8 },
                    { 40, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 74, 1 },
                    { 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 74, 2 },
                    { 220, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 74, 3 },
                    { 315, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 74, 4 },
                    { 443, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 74, 5 },
                    { 593, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 74, 6 },
                    { 765, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 74, 7 },
                    { 922, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 74, 8 },
                    { 41, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, 1 },
                    { 112, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, 2 },
                    { 221, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, 3 },
                    { 316, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, 4 },
                    { 444, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, 5 },
                    { 594, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, 6 },
                    { 766, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, 7 },
                    { 923, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 75, 8 },
                    { 42, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 76, 1 },
                    { 113, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 76, 2 },
                    { 222, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 76, 3 },
                    { 317, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 76, 4 },
                    { 445, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 76, 5 },
                    { 595, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 76, 6 },
                    { 767, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 76, 7 },
                    { 924, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 76, 8 },
                    { 43, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 77, 1 },
                    { 114, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 77, 2 },
                    { 442, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 5 },
                    { 314, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 4 },
                    { 219, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 3 },
                    { 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 2 },
                    { 310, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 69, 4 },
                    { 438, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 69, 5 },
                    { 588, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 69, 6 },
                    { 760, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 69, 7 },
                    { 917, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 69, 8 },
                    { 36, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70, 1 },
                    { 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70, 2 },
                    { 216, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70, 3 },
                    { 311, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70, 4 },
                    { 439, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70, 5 },
                    { 589, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70, 6 },
                    { 761, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70, 7 },
                    { 918, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 70, 8 },
                    { 37, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 71, 1 },
                    { 223, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 77, 3 },
                    { 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 71, 2 },
                    { 312, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 71, 4 },
                    { 440, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 71, 5 },
                    { 590, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 71, 6 },
                    { 762, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 71, 7 },
                    { 919, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 71, 8 },
                    { 38, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 1 },
                    { 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 2 },
                    { 218, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 3 },
                    { 313, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 4 },
                    { 441, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 5 },
                    { 591, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 6 },
                    { 763, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 7 },
                    { 920, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 72, 8 },
                    { 39, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 73, 1 },
                    { 217, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 71, 3 },
                    { 215, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 69, 3 },
                    { 318, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 77, 4 },
                    { 596, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 77, 6 },
                    { 779, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, 7 },
                    { 936, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 88, 8 },
                    { 46, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 1 },
                    { 117, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 2 },
                    { 251, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 3 },
                    { 335, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 4 },
                    { 449, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 5 },
                    { 613, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 6 },
                    { 802, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 7 },
                    { 937, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 89, 8 },
                    { 803, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 7 },
                    { 938, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 8 },
                    { 804, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 91, 7 },
                    { 939, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 91, 8 },
                    { 805, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 7 },
                    { 940, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 92, 8 },
                    { 806, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 7 },
                    { 941, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 93, 8 },
                    { 807, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 94, 7 },
                    { 942, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 94, 8 },
                    { 808, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 95, 7 },
                    { 943, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 95, 8 },
                    { 809, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 96, 7 },
                    { 944, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 96, 8 },
                    { 810, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, 7 },
                    { 945, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 97, 8 },
                    { 811, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 98, 7 },
                    { 946, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 98, 8 },
                    { 812, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 99, 7 },
                    { 935, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 8 },
                    { 778, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 87, 7 },
                    { 934, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 8 },
                    { 777, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 86, 7 },
                    { 768, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 77, 7 },
                    { 925, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 77, 8 },
                    { 44, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78, 1 },
                    { 115, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78, 2 },
                    { 224, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78, 3 },
                    { 319, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78, 4 },
                    { 447, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78, 5 },
                    { 597, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78, 6 },
                    { 769, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78, 7 },
                    { 926, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 78, 8 },
                    { 45, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 1 },
                    { 116, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 2 },
                    { 225, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 3 },
                    { 320, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 4 },
                    { 446, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 77, 5 },
                    { 448, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 5 },
                    { 770, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 7 },
                    { 927, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 8 },
                    { 771, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 7 },
                    { 928, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 8 },
                    { 772, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 81, 7 },
                    { 929, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 81, 8 },
                    { 773, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 7 },
                    { 930, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 82, 8 },
                    { 774, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 7 },
                    { 931, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 83, 8 },
                    { 775, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 84, 7 },
                    { 932, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 84, 8 },
                    { 776, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, 7 },
                    { 933, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 85, 8 },
                    { 598, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 79, 6 },
                    { 573, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 6 },
                    { 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 69, 2 },
                    { 916, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 68, 8 },
                    { 96, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 2 },
                    { 205, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 3 },
                    { 300, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 4 },
                    { 428, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 5 },
                    { 578, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 6 },
                    { 741, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 7 },
                    { 898, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 8 },
                    { 26, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 51, 1 },
                    { 97, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 51, 2 },
                    { 206, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 51, 3 },
                    { 301, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 51, 4 },
                    { 429, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 51, 5 },
                    { 579, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 51, 6 },
                    { 742, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 51, 7 },
                    { 899, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 51, 8 },
                    { 27, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, 1 },
                    { 98, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, 2 },
                    { 207, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, 3 },
                    { 302, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, 4 },
                    { 430, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, 5 },
                    { 580, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, 6 },
                    { 743, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, 7 },
                    { 900, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 52, 8 },
                    { 28, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 53, 1 },
                    { 99, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 53, 2 },
                    { 208, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 53, 3 },
                    { 303, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 53, 4 },
                    { 431, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 53, 5 },
                    { 581, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 53, 6 },
                    { 25, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50, 1 },
                    { 897, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, 8 },
                    { 740, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, 7 },
                    { 577, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, 6 },
                    { 893, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45, 8 },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 1 },
                    { 92, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 2 },
                    { 201, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 3 },
                    { 296, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 4 },
                    { 424, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 5 },
                    { 574, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 6 },
                    { 737, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 7 },
                    { 894, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 46, 8 },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 47, 1 },
                    { 93, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 47, 2 },
                    { 202, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 47, 3 },
                    { 297, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 47, 4 },
                    { 425, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 47, 5 },
                    { 744, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 53, 7 },
                    { 575, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 47, 6 },
                    { 895, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 47, 8 },
                    { 23, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, 1 },
                    { 94, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, 2 },
                    { 203, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, 3 },
                    { 298, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, 4 },
                    { 426, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, 5 },
                    { 576, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, 6 },
                    { 739, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, 7 },
                    { 896, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 48, 8 },
                    { 24, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, 1 },
                    { 95, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, 2 },
                    { 204, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, 3 },
                    { 299, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, 4 },
                    { 427, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 49, 5 },
                    { 738, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 47, 7 },
                    { 35, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 69, 1 },
                    { 901, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 53, 8 },
                    { 100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, 2 },
                    { 211, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, 3 },
                    { 306, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, 4 },
                    { 434, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, 5 },
                    { 584, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, 6 },
                    { 756, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, 7 },
                    { 913, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, 8 },
                    { 32, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 66, 1 },
                    { 103, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 66, 2 },
                    { 212, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 66, 3 },
                    { 307, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 66, 4 },
                    { 435, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 66, 5 },
                    { 585, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 66, 6 },
                    { 757, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 66, 7 },
                    { 914, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 66, 8 },
                    { 33, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 67, 1 },
                    { 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 67, 2 },
                    { 213, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 67, 3 },
                    { 308, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 67, 4 },
                    { 436, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 67, 5 },
                    { 586, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 67, 6 },
                    { 758, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 67, 7 },
                    { 915, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 67, 8 },
                    { 34, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 68, 1 },
                    { 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 68, 2 },
                    { 214, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 68, 3 },
                    { 309, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 68, 4 },
                    { 437, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 68, 5 },
                    { 587, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 68, 6 },
                    { 759, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 68, 7 },
                    { 102, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, 2 },
                    { 31, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 65, 1 },
                    { 912, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 64, 8 },
                    { 755, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 64, 7 },
                    { 209, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, 3 },
                    { 304, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, 4 },
                    { 432, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, 5 },
                    { 582, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, 6 },
                    { 745, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, 7 },
                    { 902, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, 8 },
                    { 30, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 55, 1 },
                    { 101, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 55, 2 },
                    { 210, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 55, 3 },
                    { 305, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 55, 4 }
                });

            migrationBuilder.InsertData(
                table: "EventPackageDishes",
                columns: new[] { "ID", "CreatedOn", "DishID", "EventPackageID" },
                values: new object[,]
                {
                    { 433, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 55, 5 },
                    { 583, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 55, 6 },
                    { 746, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 55, 7 },
                    { 903, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 55, 8 },
                    { 29, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 54, 1 },
                    { 747, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 56, 7 },
                    { 748, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, 7 },
                    { 905, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 57, 8 },
                    { 749, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 58, 7 },
                    { 906, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 58, 8 },
                    { 750, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 59, 7 },
                    { 907, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 59, 8 },
                    { 751, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 60, 7 },
                    { 908, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 60, 8 },
                    { 752, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 61, 7 },
                    { 909, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 61, 8 },
                    { 753, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 62, 7 },
                    { 910, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 62, 8 },
                    { 754, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 63, 7 },
                    { 911, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 63, 8 },
                    { 904, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 56, 8 },
                    { 1070, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 222, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Foods_DeliveryID",
                table: "Foods",
                column: "DeliveryID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipments_DeliveryID",
                table: "Equipments",
                column: "DeliveryID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentRequestCollections_EquipmentID",
                table: "EquipmentRequestCollections",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentRequestCollections_EquipmentRestockRequestID",
                table: "EquipmentRequestCollections",
                column: "EquipmentRestockRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_EventAdditionalDishRequests_EventID",
                table: "EventAdditionalDishRequests",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_EventDishRequests_AdditionalDishID",
                table: "EventDishRequests",
                column: "AdditionalDishID");

            migrationBuilder.CreateIndex(
                name: "IX_EventDishRequests_DishID",
                table: "EventDishRequests",
                column: "DishID");

            migrationBuilder.CreateIndex(
                name: "IX_EventEquipmentRequestCollections_EquipmentID",
                table: "EventEquipmentRequestCollections",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_EventEquipmentRequestCollections_EventAdditionalEquipmentRequestID",
                table: "EventEquipmentRequestCollections",
                column: "EventAdditionalEquipmentRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRequestCollections_FoodID",
                table: "FoodRequestCollections",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodRequestCollections_FoodRestockRequestID",
                table: "FoodRequestCollections",
                column: "FoodRestockRequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipments_Deliveries_DeliveryID",
                table: "Equipments",
                column: "DeliveryID",
                principalTable: "Deliveries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventAdditionalEquipmentRequests_Equipments_EquipmentID",
                table: "EventAdditionalEquipmentRequests",
                column: "EquipmentID",
                principalTable: "Equipments",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Deliveries_DeliveryID",
                table: "Foods",
                column: "DeliveryID",
                principalTable: "Deliveries",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipments_Deliveries_DeliveryID",
                table: "Equipments");

            migrationBuilder.DropForeignKey(
                name: "FK_EventAdditionalEquipmentRequests_Equipments_EquipmentID",
                table: "EventAdditionalEquipmentRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Deliveries_DeliveryID",
                table: "Foods");

            migrationBuilder.DropTable(
                name: "EquipmentRequestCollections");

            migrationBuilder.DropTable(
                name: "EventDishRequests");

            migrationBuilder.DropTable(
                name: "EventEquipmentRequestCollections");

            migrationBuilder.DropTable(
                name: "FoodRequestCollections");

            migrationBuilder.DropTable(
                name: "EventAdditionalDishRequests");

            migrationBuilder.DropIndex(
                name: "IX_Foods_DeliveryID",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Equipments_DeliveryID",
                table: "Equipments");

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 407);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 409);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 411);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 412);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 413);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 414);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 415);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 416);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 417);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 418);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 419);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 420);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 421);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 422);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 423);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 424);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 425);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 426);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 427);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 428);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 429);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 430);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 431);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 432);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 433);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 434);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 435);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 436);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 437);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 438);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 439);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 440);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 441);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 442);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 443);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 444);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 445);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 446);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 447);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 448);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 449);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 450);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 451);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 452);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 453);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 454);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 455);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 456);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 457);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 458);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 459);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 460);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 461);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 462);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 463);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 464);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 465);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 466);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 467);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 468);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 469);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 470);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 471);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 472);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 473);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 474);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 475);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 476);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 477);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 478);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 479);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 480);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 481);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 482);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 483);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 484);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 485);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 486);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 487);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 488);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 489);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 490);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 491);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 492);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 493);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 494);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 495);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 496);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 497);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 498);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 499);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 500);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 502);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 503);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 504);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 505);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 506);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 507);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 508);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 509);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 510);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 511);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 512);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 513);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 514);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 515);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 516);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 517);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 518);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 519);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 520);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 521);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 522);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 523);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 524);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 525);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 526);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 527);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 528);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 529);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 530);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 531);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 532);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 533);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 534);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 535);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 536);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 537);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 538);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 539);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 540);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 541);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 542);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 543);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 544);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 545);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 546);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 547);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 548);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 549);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 550);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 551);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 552);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 553);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 554);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 555);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 556);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 557);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 558);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 559);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 560);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 561);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 562);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 563);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 564);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 565);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 566);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 567);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 568);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 569);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 570);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 571);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 572);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 573);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 574);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 575);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 576);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 577);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 578);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 579);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 580);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 581);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 582);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 583);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 584);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 585);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 586);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 587);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 588);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 589);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 590);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 591);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 592);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 593);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 594);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 595);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 596);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 597);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 598);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 599);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 600);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 601);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 602);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 603);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 604);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 605);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 606);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 607);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 608);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 609);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 610);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 611);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 612);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 613);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 614);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 615);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 616);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 617);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 618);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 619);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 620);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 621);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 622);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 623);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 624);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 625);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 626);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 627);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 628);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 629);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 630);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 631);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 632);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 633);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 634);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 635);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 636);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 637);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 638);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 639);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 640);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 641);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 642);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 643);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 644);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 645);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 646);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 647);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 648);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 649);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 650);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 651);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 652);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 653);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 654);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 655);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 656);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 657);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 658);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 659);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 660);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 661);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 662);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 663);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 664);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 665);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 666);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 667);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 668);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 669);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 670);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 671);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 672);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 673);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 674);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 675);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 676);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 677);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 678);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 679);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 680);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 681);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 682);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 683);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 684);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 685);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 686);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 687);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 688);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 689);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 690);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 691);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 692);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 693);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 694);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 695);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 696);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 697);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 698);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 699);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 700);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 701);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 702);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 703);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 704);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 705);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 706);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 707);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 708);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 709);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 710);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 711);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 712);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 713);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 714);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 715);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 716);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 717);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 718);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 719);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 720);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 721);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 722);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 723);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 724);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 725);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 726);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 727);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 728);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 729);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 730);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 731);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 732);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 733);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 734);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 735);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 736);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 737);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 738);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 739);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 740);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 741);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 742);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 743);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 744);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 745);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 746);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 747);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 748);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 749);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 750);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 751);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 752);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 753);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 754);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 755);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 756);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 757);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 758);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 759);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 760);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 761);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 762);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 763);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 764);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 765);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 766);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 767);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 768);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 769);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 770);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 771);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 772);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 773);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 774);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 775);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 776);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 777);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 778);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 779);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 780);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 781);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 782);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 783);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 784);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 785);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 786);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 787);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 788);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 789);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 790);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 791);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 792);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 793);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 794);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 795);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 796);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 797);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 798);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 799);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 800);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 801);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 802);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 803);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 804);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 805);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 806);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 807);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 808);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 809);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 810);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 811);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 812);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 813);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 814);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 815);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 816);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 817);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 818);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 819);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 820);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 821);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 822);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 823);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 824);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 825);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 826);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 827);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 828);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 829);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 830);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 831);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 832);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 833);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 834);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 835);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 836);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 837);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 838);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 839);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 840);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 841);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 842);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 843);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 844);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 845);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 846);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 847);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 848);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 849);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 850);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 851);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 852);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 853);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 854);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 855);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 856);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 857);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 858);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 859);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 860);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 861);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 862);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 863);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 864);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 865);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 866);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 867);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 868);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 869);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 870);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 871);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 872);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 873);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 874);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 875);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 876);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 877);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 878);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 879);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 880);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 881);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 882);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 883);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 884);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 885);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 886);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 887);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 888);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 889);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 890);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 891);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 892);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 893);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 894);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 895);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 896);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 897);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 898);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 899);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 900);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 901);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 902);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 903);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 904);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 905);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 906);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 907);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 908);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 909);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 910);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 911);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 912);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 913);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 914);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 915);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 916);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 917);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 918);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 919);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 920);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 921);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 922);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 923);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 924);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 925);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 926);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 927);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 928);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 929);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 930);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 931);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 932);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 933);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 934);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 935);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 936);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 937);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 938);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 939);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 940);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 941);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 942);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 943);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 944);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 945);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 946);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 947);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 948);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 949);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 950);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 951);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 952);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 953);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 954);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 955);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 956);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 957);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 958);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 959);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 960);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 961);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 962);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 963);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 964);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 965);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 966);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 967);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 968);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 969);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 970);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 971);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 972);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 973);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 974);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 975);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 976);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 977);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 978);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 979);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 980);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 981);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 982);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 983);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 984);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 985);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 986);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 987);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 988);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 989);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 990);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 991);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 992);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 993);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 994);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 995);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 996);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 997);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 998);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 999);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1013);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1014);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1015);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1016);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1017);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1018);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1019);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1020);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1021);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1022);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1023);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1024);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1025);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1026);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1027);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1028);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1029);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1030);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1031);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1032);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1033);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1034);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1035);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1036);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1037);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1038);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1039);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1040);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1041);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1042);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1043);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1044);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1045);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1046);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1047);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1048);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1049);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1050);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1051);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1052);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1053);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1054);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1055);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1056);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1057);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1058);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1059);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1060);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1061);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1062);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1063);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1064);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1065);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1066);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1067);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1068);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1069);

            migrationBuilder.DeleteData(
                table: "EventPackageDishes",
                keyColumn: "ID",
                keyValue: 1070);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Dishes",
                keyColumn: "ID",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "EventPackages",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EventPackages",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EventPackages",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EventPackages",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EventPackages",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EventPackages",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EventPackages",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EventPackages",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DishCategories",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DishCategories",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DishCategories",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DishCategories",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DishCategories",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DishCategories",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DishCategories",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DishCategories",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DishCategories",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DishCategories",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DishCategories",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "DishCategories",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "DeliveryID",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "DeliveryID",
                table: "Equipments");

            migrationBuilder.DropColumn(
                name: "EquipmentRestockRequestID",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "FoodRestockRequestID",
                table: "Deliveries");

            migrationBuilder.AddColumn<int>(
                name: "FoodID",
                table: "FoodRestockRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "FoodRestockRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentID",
                table: "EventAdditionalEquipmentRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentID",
                table: "EquipmentRestockRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "EquipmentRestockRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FoodRestockRequests_FoodID",
                table: "FoodRestockRequests",
                column: "FoodID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentRestockRequests_EquipmentID",
                table: "EquipmentRestockRequests",
                column: "EquipmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_EquipmentRestockRequests_Equipments_EquipmentID",
                table: "EquipmentRestockRequests",
                column: "EquipmentID",
                principalTable: "Equipments",
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
                name: "FK_FoodRestockRequests_Foods_FoodID",
                table: "FoodRestockRequests",
                column: "FoodID",
                principalTable: "Foods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
