using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication3.Migrations
{
    /// <inheritdoc />
    public partial class deneme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "fc2e4538-688e-44ef-ab99-7cc997b63920");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "af961b50-16fb-4e01-bd07-28586d03bb22");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "cd567250-a856-4640-873a-ba99fe100796");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86158b6e-7a25-4e75-88c0-0ea42870b682", "AQAAAAIAAYagAAAAECEKpNEdxeQ//X5YKDyy9g3MM1QZDsTsE9YpzJxMkWq00Lu8IlT9kSq9VNY/VvzlSg==", "a272d9cf-f0e5-4d4d-9413-ddd0107dcd6b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f54ddbf4-afb7-4d04-9387-b2020b639361");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "9b5c1ca6-5eb6-4596-a114-c4b434aa611d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "b26914e7-cd13-4373-91a3-564cb2aa0bda");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9df295af-30cb-432a-801b-89cd1e51fe61", "AQAAAAIAAYagAAAAEBipGyGooAZLOtiwEbWM4wzdZFUSS3WiHZUON6Y2n8rFz1jhl2P/ftvana05fVuTbw==", "c2625402-482a-46b7-a8ba-563ccd719831" });
        }
    }
}
