using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieEntities.Migrations
{
    public partial class Recreate : Migration
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
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieRatingSource",
                columns: table => new
                {
                    RatingId = table.Column<Guid>(nullable: false),
                    SourceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRatingSource", x => new { x.RatingId, x.SourceId });
                    table.ForeignKey(
                        name: "FK_MovieRatingSource_MovieRatings_RatingId",
                        column: x => x.RatingId,
                        principalTable: "MovieRatings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieRatingSource_MovieSources_SourceId",
                        column: x => x.SourceId,
                        principalTable: "MovieSources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Netflix" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Hulu Plus" });

            migrationBuilder.InsertData(
                table: "MovieSources",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Amazon Prime" });

            migrationBuilder.CreateIndex(
                name: "IX_MovieRatingSource_SourceId",
                table: "MovieRatingSource",
                column: "SourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieRatingSource");

            migrationBuilder.DropTable(
                name: "MovieRatings");

            migrationBuilder.DropTable(
                name: "MovieSources");
        }
    }
}
