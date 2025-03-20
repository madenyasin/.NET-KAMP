using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ex00_Cozum.Migrations
{
    /// <inheritdoc />
    public partial class cfg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "KapakResmiPath",
                table: "Kitaplar",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "bos.jpg",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Fiyat",
                table: "Kitaplar",
                type: "money",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Kitaplar",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "KapakResmiPath",
                table: "Kitaplar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldDefaultValue: "bos.jpg");

            migrationBuilder.AlterColumn<double>(
                name: "Fiyat",
                table: "Kitaplar",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Kitaplar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200);
        }
    }
}
