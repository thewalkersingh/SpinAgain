using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SpinAgain.Web.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "Brand", "CC", "ImageUrl", "MeterReading", "ModelName", "Price", "RegistrationNo" },
                values: new object[,]
                {
                    { 1, "TVS", 200m, "", 0, "Apache RTR 200", 175000m, "ABC123" },
                    { 2, "Yamaha", 150m, "", 0, "FZ V4", 155000m, "DEF456" },
                    { 3, "Bajaj", 200m, "", 0, "Pulsar 200", 160000m, "GHI789" },
                    { 4, "Yamaha", 155m, "", 0, "MT-15", 172000m, "JKL012" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Bikes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
