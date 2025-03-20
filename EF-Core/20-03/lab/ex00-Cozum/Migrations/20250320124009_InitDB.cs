using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ex00_Cozum.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriler",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriler", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "Yayinevi",
                columns: table => new
                {
                    YayineviID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YayinEviAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yayinevi", x => x.YayineviID);
                });

            migrationBuilder.CreateTable(
                name: "Yazarlar",
                columns: table => new
                {
                    YazarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Soyad = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazarlar", x => x.YazarID);
                });

            migrationBuilder.CreateTable(
                name: "Kitaplar",
                columns: table => new
                {
                    KitapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fiyat = table.Column<double>(type: "float", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SayfaSayisi = table.Column<int>(type: "int", nullable: false),
                    BasimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BaskiSayisi = table.Column<int>(type: "int", nullable: false),
                    Ozet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KapakResmiPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriID = table.Column<int>(type: "int", nullable: false),
                    YayineviID = table.Column<int>(type: "int", nullable: false),
                    KagitCinsi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitaplar", x => x.KitapID);
                    table.ForeignKey(
                        name: "FK_Kitaplar_Kategoriler_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategoriler",
                        principalColumn: "KategoriID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kitaplar_Yayinevi_YayineviID",
                        column: x => x.YayineviID,
                        principalTable: "Yayinevi",
                        principalColumn: "YayineviID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Barkodlar",
                columns: table => new
                {
                    BarkodID = table.Column<int>(type: "int", nullable: false),
                    BarkodNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Karekod = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barkodlar", x => x.BarkodID);
                    table.ForeignKey(
                        name: "FK_Barkodlar_Kitaplar_BarkodID",
                        column: x => x.BarkodID,
                        principalTable: "Kitaplar",
                        principalColumn: "KitapID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kitaplarYazarlar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KitapID = table.Column<int>(type: "int", nullable: false),
                    YazarID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kitaplarYazarlar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_kitaplarYazarlar_Kitaplar_KitapID",
                        column: x => x.KitapID,
                        principalTable: "Kitaplar",
                        principalColumn: "KitapID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_kitaplarYazarlar_Yazarlar_YazarID",
                        column: x => x.YazarID,
                        principalTable: "Yazarlar",
                        principalColumn: "YazarID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_KategoriID",
                table: "Kitaplar",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_Kitaplar_YayineviID",
                table: "Kitaplar",
                column: "YayineviID");

            migrationBuilder.CreateIndex(
                name: "IX_kitaplarYazarlar_KitapID",
                table: "kitaplarYazarlar",
                column: "KitapID");

            migrationBuilder.CreateIndex(
                name: "IX_kitaplarYazarlar_YazarID",
                table: "kitaplarYazarlar",
                column: "YazarID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Barkodlar");

            migrationBuilder.DropTable(
                name: "kitaplarYazarlar");

            migrationBuilder.DropTable(
                name: "Kitaplar");

            migrationBuilder.DropTable(
                name: "Yazarlar");

            migrationBuilder.DropTable(
                name: "Kategoriler");

            migrationBuilder.DropTable(
                name: "Yayinevi");
        }
    }
}
