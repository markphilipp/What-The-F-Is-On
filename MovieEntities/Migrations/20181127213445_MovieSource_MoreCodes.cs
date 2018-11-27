using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieEntities.Migrations
{
    public partial class MovieSource_MoreCodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 25, "disneynow", "Disney Now" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 26, "abc_tveverywhere", "ABC TVEverywhere" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 27, "syfy_tveverywhere", "SYFY TVEverywhere" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 28, "comedycentral_tveverywhere", "Comedy Central TVEverywhere" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 29, "doc_club", "DOC Club" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 30, "sundancenowdocclub", "Sundance Now DOC Club" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 31, "nbc_tveverywhere", "NBC TVEverywhere" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 31);
        }
    }
}
