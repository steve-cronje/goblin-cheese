using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace goblin_cheese.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCover : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverUrl",
                table: "Game",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverUrl",
                table: "Game");
        }
    }
}
