using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla_API.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataVillas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "VillaId", "Amenity", "CreatedDate", "Details", "ImageUrl", "Occupancy", "Rate", "Sqft", "UpdateDate", "VillaName" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2025, 12, 23, 7, 54, 55, 614, DateTimeKind.Local).AddTicks(5122), "This is the Royal Villa", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg", 4, 200.0, 550, new DateTime(2025, 12, 23, 7, 54, 55, 614, DateTimeKind.Local).AddTicks(5179), "Royal Villa" },
                    { 2, "", new DateTime(2025, 12, 23, 7, 54, 55, 614, DateTimeKind.Local).AddTicks(5183), "This is the Premium Pool Villa", "", 4, 300.0, 550, new DateTime(2025, 12, 23, 7, 54, 55, 614, DateTimeKind.Local).AddTicks(5185), "Premium Pool Villa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "VillaId",
                keyValue: 2);
        }
    }
}
