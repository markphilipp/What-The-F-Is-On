using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieEntities.Migrations
{
    public partial class MovieSource_AddCodeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "MovieSources",
                nullable: true);

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 4, "hbo", "HBO" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 22, "watch_tcm", "TCM" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 21, "ifc", "IFC" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 20, "tnt", "TNT" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 19, "tbs", "TBS" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 18, "sundance_tveverywhere", "Sundance TVEverywhere" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 17, "lifetime_tveverywhere", "Lifetime TVEverywhere" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 16, "hallmark_everywhere", "Hallmark everywhere" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 15, "fox_tveverywhere", "Fox TVEverywhere" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 23, "#any#", "Any" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 14, "fx_tveverywhere", "Fx TVEverywhere" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 12, "film_struck", "Film Struck" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 11, "acorntv", "Acorntv" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 10, "fandor", "Fandor" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 9, "cbs_all_access", "CBS All Access" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 8, "cinemax", "Cinemax" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 7, "mubi", "Mubi" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 6, "starz", "Starz" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 5, "showtime", "Showtime" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 13, "shudder", "Shudder" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[] { 24, "#free#", "Free" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "MovieSources",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DropColumn(
                name: "Code",
                table: "MovieSources");
        }
    }
}
