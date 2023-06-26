using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace goblin_cheese.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GoblinUserId",
                table: "Game",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GoblinName",
                table: "AspNetUsers",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GoblinName",
                table: "AspNetUsers");
        }
    }
}
