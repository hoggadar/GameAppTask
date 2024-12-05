﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameAppTaskDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixCascadeDelete5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_BoardGames_BoardGameId",
                table: "Favourites");

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
                name: "FK_Favourites_BoardGames_BoardGameId",
                table: "Favourites");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_BoardGames_BoardGameId",
                table: "Favourites",
                column: "BoardGameId",
                principalTable: "BoardGames",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
