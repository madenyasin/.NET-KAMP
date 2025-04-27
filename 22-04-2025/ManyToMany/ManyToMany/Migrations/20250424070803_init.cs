using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ManyToMany.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kitaplar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ozet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaplar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yazarlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazarlar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KitapYazar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YazarId = table.Column<int>(type: "int", nullable: false),
                    KitapId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitapYazar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KitapYazar_Kitaplar_KitapId",
                        column: x => x.KitapId,
                        principalTable: "Kitaplar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KitapYazar_Yazarlar_YazarId",
                        column: x => x.YazarId,
                        principalTable: "Yazarlar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_KitapYazar_KitapId",
                table: "KitapYazar",
                column: "KitapId");

            migrationBuilder.CreateIndex(
                name: "IX_KitapYazar_YazarId",
                table: "KitapYazar",
                column: "YazarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KitapYazar");

            migrationBuilder.DropTable(
                name: "Kitaplar");

            migrationBuilder.DropTable(
                name: "Yazarlar");
        }
    }
}
