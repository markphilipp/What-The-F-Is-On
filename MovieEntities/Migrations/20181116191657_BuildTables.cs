using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieEntities.Migrations
{
    public partial class BuildTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieRatings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Slug = table.Column<string>(nullable: true),
                    ContentType = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    ImdbRating = table.Column<decimal>(nullable: true),
                    RottenTomatoesRating = table.Column<decimal>(nullable: true),
                    HasPoster = table.Column<bool>(nullable: false),
                    HasBackdrop = table.Column<bool>(nullable: false),
                    ReleasedOn = table.Column<DateTime>(nullable: false),
                    Classification = table.Column<string>(nullable: true),
                    OnServices = table.Column<bool>(nullable: false),
                    OnFree = table.Column<bool>(nullable: false),
                    OnRentPurchase = table.Column<bool>(nullable: false),
                    Watchlisted = table.Column<bool>(nullable: false),
                    Seen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRatings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieSources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    MovieRatingId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieSources_MovieRatings_MovieRatingId",
                        column: x => x.MovieRatingId,
                        principalTable: "MovieRatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "MovieRatingId", "Name" },
                values: new object[] { 1, null, "Netflix" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "MovieRatingId", "Name" },
                values: new object[] { 2, null, "Hulu Plus" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "MovieRatingId", "Name" },
                values: new object[] { 3, null, "Amazon Prime" });

            migrationBuilder.CreateIndex(
                name: "IX_MovieSources_MovieRatingId",
                table: "MovieSources",
                column: "MovieRatingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieSources");

            migrationBuilder.DropTable(
                name: "MovieRatings");
        }
    }
}
