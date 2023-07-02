using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace goblin_cheese.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBackdrop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Backdrop_Movie_MovieId",
                table: "Movie_Backdrop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie_Backdrop",
                table: "Movie_Backdrop");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Movie_Backdrop",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Movie_Backdrop",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie_Backdrop",
                table: "Movie_Backdrop",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Backdrop_MovieId",
                table: "Movie_Backdrop",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Backdrop_Movie_MovieId",
                table: "Movie_Backdrop",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id");
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

            migrationBuilder.DropIndex(
                name: "IX_Movie_Backdrop_MovieId",
                table: "Movie_Backdrop");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Movie_Backdrop");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "Movie_Backdrop",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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
    }
}
