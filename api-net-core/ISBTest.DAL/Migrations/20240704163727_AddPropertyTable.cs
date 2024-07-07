using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ISBTest.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfRegistration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Property",
                columns: new[] { "Id", "Address", "CreatedAt", "DateOfRegistration", "Name", "Price", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("872a1a41-cb52-4db9-ac88-4e04ddb5e67d"), "Address 4", new DateTime(2024, 7, 4, 16, 37, 26, 902, DateTimeKind.Utc).AddTicks(7834), new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Name 4", "USD 40000.00", new DateTime(2024, 7, 4, 16, 37, 26, 902, DateTimeKind.Utc).AddTicks(7835) },
                    { new Guid("b456b0aa-57cf-4d84-82e9-6347c3c6dcf1"), "Address 5", new DateTime(2024, 7, 4, 16, 37, 26, 902, DateTimeKind.Utc).AddTicks(7838), new DateTime(2024, 7, 9, 0, 0, 0, 0, DateTimeKind.Utc), "Name 5", "USD 50000.00", new DateTime(2024, 7, 4, 16, 37, 26, 902, DateTimeKind.Utc).AddTicks(7838) },
                    { new Guid("bf987682-1335-4ecb-808d-51c6bf3a7ed3"), "Address 1", new DateTime(2024, 7, 4, 16, 37, 26, 902, DateTimeKind.Utc).AddTicks(7805), new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Name 1", "USD 10000.00", new DateTime(2024, 7, 4, 16, 37, 26, 902, DateTimeKind.Utc).AddTicks(7806) },
                    { new Guid("cbe6114c-7a72-400b-98fa-86d725a8cb22"), "Address 3", new DateTime(2024, 7, 4, 16, 37, 26, 902, DateTimeKind.Utc).AddTicks(7821), new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Utc), "Name 3", "USD 30000.00", new DateTime(2024, 7, 4, 16, 37, 26, 902, DateTimeKind.Utc).AddTicks(7821) },
                    { new Guid("fe9e1bb2-1528-429b-909f-71d7126285e1"), "Address 2", new DateTime(2024, 7, 4, 16, 37, 26, 902, DateTimeKind.Utc).AddTicks(7818), new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Utc), "Name 2", "USD 20000.00", new DateTime(2024, 7, 4, 16, 37, 26, 902, DateTimeKind.Utc).AddTicks(7819) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Property");
        }
    }
}
