using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Attila.DbMigration.Migrations
{
    public partial class AddedSeederForPresentation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Returned",
                table: "EquipmentTracking",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ID", "Address", "Contact", "CreatedOn", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "Cavite, Philippines", "090909090909", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "vincentdagpin@uniwallet.ph", "Vincent Dagpin" },
                    { 2, "Manila, Philippines", "+65877327373", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cherylchan@gmail.com", "Cheryl Chan" },
                    { 3, "Manila, Philippines", "+6523423523", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "peishi@gmail.com", "Pei Shi" },
                    { 4, "Singapore", "+65342642345", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ryx@gmail.com", "Ren Yi Xiang" }
                });

            migrationBuilder.InsertData(
                table: "Equipments",
                columns: new[] { "ID", "Code", "CreatedOn", "DeliveryID", "Description", "EquipmentType", "Name", "RentalFee", "UnitType" },
                values: new object[,]
                {
                    { 1, "PCX-001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, (byte)2, "Monoblock Chair", 50m, (byte)1 },
                    { 2, "QMN-002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, (byte)2, "Monoblock Table", 100m, (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "ID", "Code", "CreatedOn", "DeliveryID", "Description", "FoodType", "Name", "Specification", "Unit" },
                values: new object[,]
                {
                    { 1, "BVN-001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, (byte)2, "Nestle All Purpose Cream", "250 ml", (byte)1 },
                    { 2, "XCM-002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, (byte)2, "Golden Fiesta Palm Oil", "950 ml", (byte)1 },
                    { 3, "MNX-003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, (byte)1, "Red Apples", "N/A", (byte)2 }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "ID", "Address", "ContactNumber", "ContactPersonName", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { 1, "Quezon City", "+639439435435", "Paul Parks", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CSI" },
                    { 2, "Quezon City", "+6392674564564", "Cris Cruz", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UVWoods" },
                    { 3, "Pasig City", "+639465634453", "Angel Tan", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ABC" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: -1,
                column: "UID",
                value: new Guid("00000000-0000-0000-0000-000000000001"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "ContactNumber", "CreatedOn", "Email", "Name", "Position", "Role", "UID" },
                values: new object[,]
                {
                    { -2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "coordinator@acs.com", "Test-Coordinator", null, (byte)2, new Guid("00000000-0000-0000-0000-000000000002") },
                    { -3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "inventory-mgr@acs.com", "Test-Inventory-Manager", null, (byte)4, new Guid("00000000-0000-0000-0000-000000000003") },
                    { -4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "chef@acs.com", "Test-Chef", null, (byte)3, new Guid("00000000-0000-0000-0000-000000000004") }
                });

            migrationBuilder.InsertData(
                table: "Deliveries",
                columns: new[] { "ID", "CreatedOn", "DeliveryDate", "DeliveryPrice", "EquipmentRestockRequestID", "FoodRestockRequestID", "ReceiptImage", "Remarks", "SupplierID" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50000m, null, null, null, null, 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100000m, null, null, null, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserLogins",
                columns: new[] { "ID", "CreatedOn", "IsTemporaryPassword", "Password", "Salt", "TemporaryPassword", "Username" },
                values: new object[,]
                {
                    { -2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new byte[] { 0, 65, 68, 77, 73, 78, 45, 83, 65, 76, 84, 45, 49, 50, 51, 52, 33, 152, 156, 47, 115, 252, 177, 181, 237, 49, 172, 91, 121, 81, 188, 196, 100, 45, 157, 169, 124, 209, 176, 77, 87, 192, 4, 80, 245, 135, 176, 31, 123 }, new byte[] { 65, 68, 77, 73, 78, 45, 83, 65, 76, 84, 45, 49, 50, 51, 52, 33, 64, 35, 36 }, "admin", "test-coordinator" },
                    { -3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new byte[] { 0, 65, 68, 77, 73, 78, 45, 83, 65, 76, 84, 45, 49, 50, 51, 52, 33, 152, 156, 47, 115, 252, 177, 181, 237, 49, 172, 91, 121, 81, 188, 196, 100, 45, 157, 169, 124, 209, 176, 77, 87, 192, 4, 80, 245, 135, 176, 31, 123 }, new byte[] { 65, 68, 77, 73, 78, 45, 83, 65, 76, 84, 45, 49, 50, 51, 52, 33, 64, 35, 36 }, "admin", "test-inventory-manager" },
                    { -4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new byte[] { 0, 65, 68, 77, 73, 78, 45, 83, 65, 76, 84, 45, 49, 50, 51, 52, 33, 152, 156, 47, 115, 252, 177, 181, 237, 49, 172, 91, 121, 81, 188, 196, 100, 45, 157, 169, 124, 209, 176, 77, 87, 192, 4, 80, 245, 135, 176, 31, 123 }, new byte[] { 65, 68, 77, 73, 78, 45, 83, 65, 76, 84, 45, 49, 50, 51, 52, 33, 64, 35, 36 }, "admin", "test-chef" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Deliveries",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipments",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserLogins",
                keyColumn: "ID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "UserLogins",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "UserLogins",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: -2);

            migrationBuilder.DropColumn(
                name: "Returned",
                table: "EquipmentTracking");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: -1,
                column: "UID",
                value: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
