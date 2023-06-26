using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace goblin_cheese.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGoblinUserGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_AspNetUsers_GoblinUserId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_GoblinUserId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "GoblinUserId",
                table: "Game");

            migrationBuilder.AddColumn<DateTime>(
                name: "SignupDate",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameGoblinUser",
                columns: table => new
                {
                    FavedById = table.Column<string>(type: "text", nullable: false),
                    FavouriteGamesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGoblinUser", x => new { x.FavedById, x.FavouriteGamesId });
                    table.ForeignKey(
                        name: "FK_GameGoblinUser_AspNetUsers_FavedById",
                        column: x => x.FavedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGoblinUser_Game_FavouriteGamesId",
                        column: x => x.FavouriteGamesId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameGoblinUser_FavouriteGamesId",
                table: "GameGoblinUser",
                column: "FavouriteGamesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGoblinUser");

            migrationBuilder.DropColumn(
                name: "SignupDate",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "GoblinUserId",
                table: "Game",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_GoblinUserId",
                table: "Game",
                column: "GoblinUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_AspNetUsers_GoblinUserId",
                table: "Game",
                column: "GoblinUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
