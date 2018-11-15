using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieEntities.Mapping.Migrations
{
    public partial class FixSourcePropertyType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieSource");

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    MovieRatingId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sources_Ratings_MovieRatingId",
                        column: x => x.MovieRatingId,
                        principalTable: "Ratings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "MovieRatingId", "Name" },
                values: new object[] { 1, null, "Netflix" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "MovieRatingId", "Name" },
                values: new object[] { 2, null, "Hulu Plus" });

            migrationBuilder.InsertData(
                table: "Sources",
                columns: new[] { "Id", "MovieRatingId", "Name" },
                values: new object[] { 3, null, "Amazon Prime" });

            migrationBuilder.CreateIndex(
                name: "IX_Sources_MovieRatingId",
                table: "Sources",
                column: "MovieRatingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sources");

            migrationBuilder.CreateTable(
                name: "MovieSource",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovieRatingId = table.Column<Guid>(nullable: true),
                    Name = table.Column<string>(nullable: true)
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
    }
}
