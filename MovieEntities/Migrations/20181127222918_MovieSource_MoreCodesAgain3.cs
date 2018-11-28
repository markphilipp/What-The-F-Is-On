using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieEntities.Migrations
{
    public partial class MovieSource_MoreCodesAgain3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 36, "hallmark_movies_now", "Hallmark Movies Now" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 37, "monstersnightmares", "Monsters Nightmares" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 38, "realeyz", "RealEYZ" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 39, "warriorsgangsters", "Warriors Gangsters" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 39);
        }
    }
}
