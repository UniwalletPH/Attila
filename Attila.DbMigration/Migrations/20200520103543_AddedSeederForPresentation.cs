using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Attila.DbMigration.Migrations
{
    public partial class AddedSeederForPresentation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ID", "Address", "Contact", "CreatedOn", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "Cavite, Philippines", "090909090909", new DateTime(2020, 5, 20, 18, 35, 41, 764, DateTimeKind.Local).AddTicks(5312), "vincentdagpin@uniwallet.ph", "Vincent Dagpin" },
                    { 2, "Manila, Philippines", "+65877327373", new DateTime(2020, 5, 20, 18, 35, 41, 767, DateTimeKind.Local).AddTicks(4585), "cherylchan@gmail.com", "Cheryl Chan" },
                    { 3, "Manila, Philippines", "+6523423523", new DateTime(2020, 5, 20, 18, 35, 41, 767, DateTimeKind.Local).AddTicks(4757), "peishi@gmail.com", "Pei Shi" },
                    { 4, "Singapore", "+65342642345", new DateTime(2020, 5, 20, 18, 35, 41, 767, DateTimeKind.Local).AddTicks(4768), "ryx@gmail.com", "Ren Yi Xiang" }
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
                    { 1, "Quezon City", "+639439435435", "Paul Parks", new DateTime(2020, 5, 20, 18, 35, 41, 892, DateTimeKind.Local).AddTicks(8782), "CSI" },
                    { 2, "Quezon City", "+6392674564564", "Cris Cruz", new DateTime(2020, 5, 20, 18, 35, 41, 892, DateTimeKind.Local).AddTicks(9036), "UVWoods" },
                    { 3, "Pasig City", "+639465634453", "Angel Tan", new DateTime(2020, 5, 20, 18, 35, 41, 892, DateTimeKind.Local).AddTicks(9049), "ABC" }
                });

            migrationBuilder.InsertData(
                table: "Deliveries",
                columns: new[] { "ID", "CreatedOn", "DeliveryDate", "DeliveryPrice", "EquipmentRestockRequestID", "FoodRestockRequestID", "ReceiptImage", "Remarks", "SupplierID" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 20, 18, 35, 41, 768, DateTimeKind.Local).AddTicks(4081), 50000m, null, null, null, null, 1 });

            migrationBuilder.InsertData(
                table: "Deliveries",
                columns: new[] { "ID", "CreatedOn", "DeliveryDate", "DeliveryPrice", "EquipmentRestockRequestID", "FoodRestockRequestID", "ReceiptImage", "Remarks", "SupplierID" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 5, 20, 18, 35, 41, 768, DateTimeKind.Local).AddTicks(5684), 100000m, null, null, null, null, 2 });
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
                table: "Suppliers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
