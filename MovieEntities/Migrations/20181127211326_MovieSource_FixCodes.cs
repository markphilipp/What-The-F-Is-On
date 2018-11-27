using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieEntities.Migrations
{
    public partial class MovieSource_FixCodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Code",
                value: "netflix");

            migrationBuilder.UpdateData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: "hulu_plus");

            migrationBuilder.UpdateData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "Code",
                value: "amazon_prime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "Code",
                value: null);

            migrationBuilder.UpdateData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "Code",
                value: null);
        }
    }
}
