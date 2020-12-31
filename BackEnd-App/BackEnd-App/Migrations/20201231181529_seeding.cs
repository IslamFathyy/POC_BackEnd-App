using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_App.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FlightLevel",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1", "Business" },
                    { "2", "Economy" },
                    { "3", "VIP" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethod",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "1", "Credit Card" },
                    { "2", "Pay Cash" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FlightLevel",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "FlightLevel",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "FlightLevel",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "PaymentMethod",
                keyColumn: "Id",
                keyValue: "2");
        }
    }
}
