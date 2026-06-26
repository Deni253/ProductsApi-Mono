using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.Service.Migrations
{
    /// <inheritdoc />
    public partial class SeedData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("21afa39e-fc53-492b-829b-5ee4fbe93cf8"), "golf clubs and bags", "Golf Equipment" });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "IsActive", "Name", "Price", "StockQuantity" },
                values: new object[] { new Guid("02d69507-7869-4487-a9f5-e1780a7f856b"), new Guid("21afa39e-fc53-492b-829b-5ee4fbe93cf8"), new DateTime(2026, 6, 25, 17, 31, 24, 766, DateTimeKind.Utc).AddTicks(7790), true, "Yellow Golf Club", 29.989999999999998, 20 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "products",
                keyColumn: "Id",
                keyValue: new Guid("02d69507-7869-4487-a9f5-e1780a7f856b"));

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("21afa39e-fc53-492b-829b-5ee4fbe93cf8"));
        }
    }
}
