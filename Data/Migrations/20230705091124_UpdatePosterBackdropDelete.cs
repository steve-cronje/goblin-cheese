using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace goblin_cheese.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePosterBackdropDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Backdrop_Movie_MovieId",
                table: "Movie_Backdrop");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Poster_Movie_MovieId",
                table: "Movie_Poster");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Backdrop_Movie_MovieId",
                table: "Movie_Backdrop",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Poster_Movie_MovieId",
                table: "Movie_Poster",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Backdrop_Movie_MovieId",
                table: "Movie_Backdrop");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Poster_Movie_MovieId",
                table: "Movie_Poster");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Backdrop_Movie_MovieId",
                table: "Movie_Backdrop",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Poster_Movie_MovieId",
                table: "Movie_Poster",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id");
        }
    }
}
