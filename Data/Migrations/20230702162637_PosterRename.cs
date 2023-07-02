using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace goblin_cheese.Migrations
{
    /// <inheritdoc />
    public partial class PosterRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Poster_Movie_MovieId",
                table: "Poster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Poster",
                table: "Poster");

            migrationBuilder.RenameTable(
                name: "Poster",
                newName: "Movie_Poster");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie_Poster",
                table: "Movie_Poster",
                column: "MovieId");

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
                name: "FK_Movie_Poster_Movie_MovieId",
                table: "Movie_Poster");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie_Poster",
                table: "Movie_Poster");

            migrationBuilder.RenameTable(
                name: "Movie_Poster",
                newName: "Poster");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Poster",
                table: "Poster",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Poster_Movie_MovieId",
                table: "Poster",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
