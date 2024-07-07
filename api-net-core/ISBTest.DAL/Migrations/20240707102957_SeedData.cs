using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ISBTest.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Phone", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2370b0cc-d432-4608-9ce4-922017f9ee8e"), new DateTime(2024, 7, 7, 10, 29, 57, 356, DateTimeKind.Utc).AddTicks(4073), null, "Joe", "Borg", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3714dabc-2e57-43e3-8eb1-89a0a78ed02f"), new DateTime(2024, 7, 7, 10, 29, 57, 356, DateTimeKind.Utc).AddTicks(4072), null, "Joshua", "Mifsud", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("639812a1-ad91-44ac-946b-c9c0ad0fc908"), new DateTime(2024, 7, 7, 10, 29, 57, 356, DateTimeKind.Utc).AddTicks(4070), null, "Carmen", "Attard", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Property",
                columns: new[] { "Id", "Address", "CreatedAt", "DateOfRegistration", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("872a1a41-cb52-4db9-ac88-4e04ddb5e67d"), "Hcm Maisonette Address", new DateTime(2024, 7, 7, 10, 29, 57, 356, DateTimeKind.Utc).AddTicks(3987), new DateTime(2024, 7, 7, 10, 29, 57, 356, DateTimeKind.Utc).AddTicks(3989), "Hcm Maisonette", "EUR 130000.00", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b456b0aa-57cf-4d84-82e9-6347c3c6dcf1"), "Penhouse", new DateTime(2024, 7, 7, 10, 29, 57, 356, DateTimeKind.Utc).AddTicks(3994), new DateTime(2024, 7, 7, 10, 29, 57, 356, DateTimeKind.Utc).AddTicks(3994), "Penhouse", "EUR 430000.00", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bf987682-1335-4ecb-808d-51c6bf3a7ed3"), "Cantho Maisonette Address", new DateTime(2024, 7, 7, 10, 29, 57, 356, DateTimeKind.Utc).AddTicks(3991), new DateTime(2024, 7, 7, 10, 29, 57, 356, DateTimeKind.Utc).AddTicks(3992), "Cantho Maisonette", "EUR 110000.00", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "OwnershipChange",
                columns: new[] { "EffectiveDate", "PropertyId", "AskingPrice", "ContactId", "SoldPrice", "SoldPriceAtUsd" },
                values: new object[,]
                {
                    { new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("872a1a41-cb52-4db9-ac88-4e04ddb5e67d"), "EUR 130000.00", new Guid("639812a1-ad91-44ac-946b-c9c0ad0fc908"), "EUR 120000.00", "USD 140000.00" },
                    { new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("872a1a41-cb52-4db9-ac88-4e04ddb5e67d"), "EUR 150000.00", new Guid("3714dabc-2e57-43e3-8eb1-89a0a78ed02f"), "EUR 140000.00", "USD 165000.00" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: new Guid("2370b0cc-d432-4608-9ce4-922017f9ee8e"));

            migrationBuilder.DeleteData(
                table: "OwnershipChange",
                keyColumns: new[] { "EffectiveDate", "PropertyId" },
                keyValues: new object[] { new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("872a1a41-cb52-4db9-ac88-4e04ddb5e67d") });

            migrationBuilder.DeleteData(
                table: "OwnershipChange",
                keyColumns: new[] { "EffectiveDate", "PropertyId" },
                keyValues: new object[] { new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("872a1a41-cb52-4db9-ac88-4e04ddb5e67d") });

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "Id",
                keyValue: new Guid("b456b0aa-57cf-4d84-82e9-6347c3c6dcf1"));

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "Id",
                keyValue: new Guid("bf987682-1335-4ecb-808d-51c6bf3a7ed3"));

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: new Guid("3714dabc-2e57-43e3-8eb1-89a0a78ed02f"));

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: new Guid("639812a1-ad91-44ac-946b-c9c0ad0fc908"));

            migrationBuilder.DeleteData(
                table: "Property",
                keyColumn: "Id",
                keyValue: new Guid("872a1a41-cb52-4db9-ac88-4e04ddb5e67d"));
        }
    }
}
