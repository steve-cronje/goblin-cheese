using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace goblin_cheese.Migrations
{
    /// <inheritdoc />
    public partial class RenameBackdrop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieBackdrop_Movie_MovieId",
                table: "MovieBackdrop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieBackdrop",
                table: "MovieBackdrop");

            migrationBuilder.RenameTable(
                name: "MovieBackdrop",
                newName: "Movie_Backdrop");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie_Backdrop",
                table: "Movie_Backdrop",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Backdrop_Movie_MovieId",
                table: "Movie_Backdrop",
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie_Backdrop",
                table: "Movie_Backdrop");

            migrationBuilder.RenameTable(
                name: "Movie_Backdrop",
                newName: "MovieBackdrop");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieBackdrop",
                table: "MovieBackdrop",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieBackdrop_Movie_MovieId",
                table: "MovieBackdrop",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
