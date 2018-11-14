using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieEntities.Mapping.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ratings",
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
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    MovieRatingId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieSource_Ratings_MovieRatingId",
                        column: x => x.MovieRatingId,
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieSource_MovieRatingId",
                table: "MovieSource",
                column: "MovieRatingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieSource");

            migrationBuilder.DropTable(
                name: "Ratings");
        }
    }
}
