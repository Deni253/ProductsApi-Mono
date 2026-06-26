using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApi.Service.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("aa640f87-912d-417e-b063-98c40ac1df62"), "Electronic devices", "Electronics" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: new Guid("aa640f87-912d-417e-b063-98c40ac1df62"));
        }
    }
}
