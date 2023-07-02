using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace goblin_cheese.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TV_Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TV_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieTVGenre",
                columns: table => new
                {
                    GenresId = table.Column<int>(type: "integer", nullable: false),
                    MoviesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieTVGenre", x => new { x.GenresId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_MovieTVGenre_Movie_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieTVGenre_TV_Genre_GenresId",
                        column: x => x.GenresId,
                        principalTable: "TV_Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieTVGenre_MoviesId",
                table: "MovieTVGenre",
                column: "MoviesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieTVGenre");

            migrationBuilder.DropTable(
                name: "TV_Genre");
        }
    }
}
