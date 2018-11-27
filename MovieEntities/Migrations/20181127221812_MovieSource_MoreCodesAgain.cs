using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieEntities.Migrations
{
    public partial class MovieSource_MoreCodesAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 32, "epix", "epix" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 33, "abc_family", "abc_family" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 34, "tribeca_shortlist", "tribeca_shortlist" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 34);
        }
    }
}
