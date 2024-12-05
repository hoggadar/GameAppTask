using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameAppTaskDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixCascadeDelete3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_AspNetUsers_UserId",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_BoardGames_BoardGameId",
                table: "Favourites");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_AspNetUsers_UserId",
                table: "Favourites",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_BoardGames_BoardGameId",
                table: "Favourites",
                column: "BoardGameId",
                principalTable: "BoardGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_AspNetUsers_UserId",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_BoardGames_BoardGameId",
                table: "Favourites");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_AspNetUsers_UserId",
                table: "Favourites",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_BoardGames_BoardGameId",
                table: "Favourites",
                column: "BoardGameId",
                principalTable: "BoardGames",
                principalColumn: "Id");
        }
    }
}
