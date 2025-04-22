using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManyToMany.Migrations
{
    /// <inheritdoc />
    public partial class initData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kitaplar",
                columns: new[] { "Id", "Ad", "ISBN", "Ozet" },
                values: new object[,]
                {
                    { 1, "Kara Kitap", "978-975-08-0197-8", "" },
                    { 2, "İnce Memed", "978-975-08-0669-0", "" },
                    { 3, "Kürk Mantolu Madonna", "978-975-08-0870-0", "" }
                });

            migrationBuilder.InsertData(
                table: "Yazarlar",
                columns: new[] { "Id", "Ad", "DogumTarihi", "Soyad" },
                values: new object[,]
                {
                    { 1, "Orhan", new DateTime(1952, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pamuk" },
                    { 2, "Yaşar", new DateTime(1923, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kemal" },
                    { 3, "Sabahattin", new DateTime(1907, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ali" }
                });

            migrationBuilder.InsertData(
                table: "KitapYazar",
                columns: new[] { "Id", "KitapId", "YazarId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 3, 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KitapYazar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "KitapYazar",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "KitapYazar",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Kitaplar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Kitaplar",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kitaplar",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Yazarlar",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Yazarlar",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Yazarlar",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
