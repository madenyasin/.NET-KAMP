using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Markalar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Markalar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uyeler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sifre = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uyeler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Araclar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plaka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarkaId = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Renk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EkleyenUyeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Araclar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Araclar_Markalar_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "Markalar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Araclar_Uyeler_EkleyenUyeId",
                        column: x => x.EkleyenUyeId,
                        principalTable: "Uyeler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Markalar",
                columns: new[] { "Id", "Ad" },
                values: new object[,]
                {
                    { 1, "Toyota" },
                    { 2, "Ford" },
                    { 3, "BMW" },
                    { 4, "Mercedes" },
                    { 5, "Honda" }
                });

            migrationBuilder.InsertData(
                table: "Uyeler",
                columns: new[] { "Id", "Ad", "KullaniciAdi", "Sifre", "Soyad" },
                values: new object[,]
                {
                    { 1, "Ahmet", "ahmet", "5e0d21b7723e1daea751aac90f6f028d", "Yılmaz" },
                    { 2, "Mehmet", "mehmet", "a394b545e6dc8a9309386a106ac6d307", "Kaya" },
                    { 3, "Ayşe", "ayse", "00de791f6f87549e6241ff25f32c64c0", "Demir" },
                    { 4, "Fatma", "fatma", "e7ce460319aee03a64d74aecf950cb6d", "Çelik" },
                    { 5, "Ali", "ali", "6695be8f704b8f2a2239330412bd857d", "Şahin" }
                });

            migrationBuilder.InsertData(
                table: "Araclar",
                columns: new[] { "Id", "Aciklama", "EkleyenUyeId", "Fiyat", "MarkaId", "Model", "Plaka", "Renk" },
                values: new object[,]
                {
                    { 1, "2020 model, az kullanılmış", 1, 250000m, 1, "Corolla", "34ABC123", "Beyaz" },
                    { 2, "2018 model, full paket", 2, 180000m, 2, "Focus", "06XYZ456", "Siyah" },
                    { 3, "2021 model, 20.000 km", 3, 450000m, 3, "320i", "35DEF789", "Mavi" },
                    { 4, "2022 model, premium paket", 1, 520000m, 4, "C200", "16GHI012", "Gri" },
                    { 5, "2019 model, hibrit", 2, 320000m, 5, "Civic", "07JKL345", "Kırmızı" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Araclar_EkleyenUyeId",
                table: "Araclar",
                column: "EkleyenUyeId");

            migrationBuilder.CreateIndex(
                name: "IX_Araclar_MarkaId",
                table: "Araclar",
                column: "MarkaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Araclar");

            migrationBuilder.DropTable(
                name: "Markalar");

            migrationBuilder.DropTable(
                name: "Uyeler");
        }
    }
}
