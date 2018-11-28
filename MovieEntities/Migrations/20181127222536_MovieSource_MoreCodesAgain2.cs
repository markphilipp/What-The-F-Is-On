using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieEntities.Migrations
{
    public partial class MovieSource_MoreCodesAgain2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "EPIX");

            migrationBuilder.UpdateData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "ABC Family");

            migrationBuilder.UpdateData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "Tribeca Shortlist");

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 35, "indieflixshorts", "Indie Flix Shorts" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.UpdateData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "epix");

            migrationBuilder.UpdateData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 33,
                column: "Name",
                value: "abc_family");

            migrationBuilder.UpdateData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "tribeca_shortlist");
        }
    }
}
